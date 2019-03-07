using System;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using System.Text;

// ASN.1 BER encoding library by Malcolm Crowe at the University of the West of Scotland
// See http://cis.paisley.ac.uk/crow-ci0
// This is version 0 of the library, please advise me about any bugs
// mailto:malcolm.crowe@paisley.ac.uk

// Restrictions: It is assumed that no encoding has a length greater than 2^31-1.
// UNIVERSAL TYPES
// Some of the more unusual Universal encodings are supported but not fully implemented
// Should you require these types, as an alternative to changing this code
// you can catch the exception that is thrown and examine the contents yourself.
// APPLICATION TYPES
// If you want to handle Application types systematically, you can derive a class from
// Universal, and provide the Creator and Creators methods for your class
// You will see an example of how to do this in the Snmplib
// CONTEXT AND PRIVATE TYPES
// Ad hoc coding can be used for these, as an alterative to derive a class as above.

namespace X690 // all references here are to ITU-X.690-12/97
{
    public class OctetString // This namespace has its own concept of string
    {
        public byte[] octVal = null;
        public OctetString(byte[] b)
        {
            octVal = b;
        }
        public OctetString(byte[] b, uint a, uint n)
        {
            octVal = new byte[n];
            for (int j = 0; j < n; j++)
                octVal[j] = b[a + j];
        }
        public OctetString(string s)
        {
            octVal = new byte[s.Length];
            for (int j = 0; j < s.Length; j++)
                octVal[j] = (byte)s[j];
        }
        static public implicit operator string(OctetString x)
        {
            if (x == null)
                return null;
            int n = x.octVal.Length;
            if (n == 0)
                return "";
            StringBuilder sb = new StringBuilder(n, n);
            for (int j = 0; j < n; j++)
                sb.Append((char)x.octVal[j]);
            return sb.ToString();
        }
        public override string ToString()
        {
            if (octVal.Length == 8 || octVal.Length == 11) // may be a date
            {
                uint yr = octVal[0];
                yr = yr * 256 + octVal[1];
                uint mo = octVal[2];
                uint dy = octVal[3];
                if (yr < 2005 && yr > 1990 && mo < 13 && dy < 32)
                    return "" + dy + "/" + mo + "/" + yr;
            }
            return (string)this;
        }
        static public OctetString operator +(OctetString a, OctetString b)
        {
            int j;
            byte[] r = new byte[a.octVal.Length + b.octVal.Length];
            for (j = 0; j < a.octVal.Length; j++)
                r[j] = a.octVal[j];
            for (j = 0; j < b.octVal.Length; j++)
                r[j + a.octVal.Length] = b.octVal[j];
            return new OctetString(r);
        }
    }
    public class Integer // This namespace has its own concept of Integer
    {
        public byte[] octVal = null;
        public Integer(byte[] b)
        {
            octVal = b;
        }
        public Integer(int iVal)
        {
            if (iVal >= -127 && iVal <= 127)
            {
                octVal = new byte[1];
                octVal[0] = (byte)iVal;
            }
            else
            {
                ArrayList v = new ArrayList();
                int n = iVal;
                while (n != 0 && n != -1)
                {
                    if (n < 256 && n >= 128)
                    {
                        v.Add((byte)n);
                        v.Add((byte)0);
                        break;
                    }
                    v.Add((byte)(n & 0xff));
                    n >>= 8;
                }
                octVal = new byte[v.Count];
                int len = 0;
                for (int j = v.Count - 1; j >= 0; j--)
                    octVal[len++] = (byte)v[j];
            }
        }
        public Integer(long i64Val)
        {
            if (i64Val >= -127 && i64Val <= 127)
            {
                octVal = new byte[1];
                octVal[0] = (byte)i64Val;
            }
            else
            {
                ArrayList v = new ArrayList();
                System.Int64 n = i64Val;
                while (n != 0 && n != -1)
                {
                    if (n < 256 && n >= 128)
                    {
                        v.Add((byte)n);
                        v.Add((byte)0);
                        break;
                    }
                    v.Add((byte)(n & 0xff));
                    n >>= 8;
                }
                octVal = new byte[v.Count];
                int len = 0;
                for (int j = v.Count - 1; j >= 0; j--)
                    octVal[len++] = (byte)v[j];
            }
        }
        static public implicit operator int(Integer x)
        {
            if (x.octVal.Length > 4)
                throw (new Exception("truncation error for 32-bit integer coding"));
            int iVal = ((x.octVal[0] & 0x80) == 0x80) ? -1 : 0; // sign extended! Guy McIlroy
            for (int j = 0; j < x.octVal.Length; j++)
                iVal = (iVal << 8) | (int)x.octVal[j];
            return iVal;
        }
        static public implicit operator long(Integer x)
        {
            if (x.octVal.Length > 8)
                throw (new Exception("truncation error for 64-bit integer coding"));
            long i64Val = ((x.octVal[0] & 0x80) == 0x80) ? -1 : 0; // sign extended! Guy McIlroy
            for (int j = 0; j < x.octVal.Length; j++)
                i64Val = (i64Val << 8) | (long)x.octVal[j];
            return i64Val;
        }
        public override string ToString()
        {
            return ((long)this).ToString();
        }
    }
    public class Real
    {
        public byte[] octVal = null;
        public Real(byte[] b)
        {
            octVal = b;
        }
        public Real(double b)
        {
            if (b == 0.0)
            {
                octVal = new byte[0];
                return;
            }
            string s = b.ToString("E"); // hope this is acceptable..
            octVal = new byte[s.Length + 1];
            octVal[0] = 0x0;
            new ASCIIEncoding().GetBytes(s, 0, s.Length, octVal, 1);
        }
        static public implicit operator double(Real x)
        {
            if (x.octVal.Length == 0)
                return 0.0;
            if ((x.octVal[0] & 0x80) != 0) // 8.5.5 binary encoding
            {
                byte c = x.octVal[0];
                int s = ((c & 0x40) != 0) ? -1 : 1;
                int t = c & 0x30;
                int b = (t == 0) ? 2 : (t == 1) ? 8 : 16;
                if (t == 3)
                    throw (new Exception("X690:8.5.5.2 reserved encoding"));
                int f = (c & 0xc) >> 2;
                f = 1 << f;
                int p = 1;
                int h = (c & 0x3) + 1;
                if (h == 4)
                    h = x.octVal[p++];
                byte[] g = new byte[h];
                for (int j = 0; j < h; j++)
                    g[j] = x.octVal[p++];
                bool eb = CheckTwosComp(g);
                long e = new Integer(g);
                if (eb)
                    e = -e;
                byte[] m = new byte[x.octVal.Length - p];
                for (int k = 0; p < x.octVal.Length; k++, p++)
                    m[k] = x.octVal[p];
                long n = new Integer(m);
                return ((double)(s * n * f)) * Math.Pow((double)b, (double)e);
            }
            else if ((x.octVal[0] & 0x40) == 0) // 8.5.6 decimal encoding
                return double.Parse(new ASCIIEncoding().GetString(x.octVal, 0, x.octVal.Length));
            else // 8.5.7 special real encoding
                switch (x.octVal[0])
                {
                    case 0x40: return double.PositiveInfinity;
                    case 0x41: return double.NegativeInfinity;
                    default: throw (new Exception("X690:8.5.7 reserved encoding"));
                }
        }
        static bool CheckTwosComp(byte[] b)
        {
            if (b[0] < 128)
                return false;
            int c = 1;
            for (int j = b.Length - 1; j >= 0; j--)
            {
                if (b[j] == 0 && c > 0)
                    continue;
                b[j] = (byte)(255 - b[j] + c);
                c = 0;
            }
            return true;
        }
        public override string ToString()
        {
            return ((double)this).ToString();
        }
    }
    public abstract class BER
    {
        // internal representation of the encoding
        protected BERtag type; // BERtag class does encoding/decoding
        protected object val = null;
        // safety field
        protected bool e; // encode if true, decode if false
        // external representation of the contents octets
        protected byte[] b;
        protected uint len
        {
            get
            {  // crash if b is null!
                return (uint)b.Length;
            }
        }
        public bool Encode { get { return e; } }
        protected byte ReadByte(Stream s)
        {
            int n = s.ReadByte();
            if (n == -1)
                throw (new Exception("BER end of file"));
            return (byte)n;
        }
        protected void WriteByte(Stream s, byte b)
        {
            s.WriteByte(b);
        }
    }
    public enum BERtype  // 8.1.2.2
    {
        Universal = 0, Application = 1, Context = 2, Private = 3
    }
    public enum UniversalType
    {
        EndMarker = 0x00,
        Boolean = 0x01,
        Integer = 0x02, // X690.Integer
        BitString = 0x03,  // X690.BitSet
        OctetString = 0x04, // X690.OctetString
        Null = 0x05,
        ObjectIdentifier = 0x06, // uint[]
        ObjectDescriptor = 0x7,
        ExternalInstance = 0x8,
        Real = 0x9,  // X690.Real
        Enumerated = 0xa,
        EmbeddedPDV = 0xb,
        UTF8String = 0xc,
        RelativeOID = 0xd,
        Reserved1 = 0xe,
        Reserved2 = 0xf,
        Sequence = 0x10,
        Set = 0x11,
        NumericString = 0x12,
        PrintableString = 0x13,
        T61String = 0x14,
        VideoTextString = 0x15,
        IA5String = 0x16,
        UTCTime = 0x17,
        GeneralizedTime = 0x18,
        GrahicString = 0x19,
        VisibleString = 0x1a,
        GeneralString = 0x1b,
        UniversalString = 0x1c,
        CharacterString = 0x1d,
        BMPString = 0x1e
    }
    public class BERtag : BER
    {
        // Internal representation of Identifier octets 8.1.2.3
        public BERtype atp;
        public bool comp;
        public ulong tag;
        public BERtag() { atp = BERtype.Universal; comp = false; tag = 0; } // EndMarker
        public BERtag(BERtype a, bool c, ulong t) { atp = a; comp = c; tag = t; }
        public BERtag(UniversalType b) : this((byte)b) { }
        public BERtag(byte b)
        {
            // decoding 8.1.2.4.3 for small tag values
            atp = (BERtype)(((uint)b & 0xc0) >> 6);
            comp = ((b & 0x20) != 0);
            tag = (ulong)(b & 0x1f);
            if (tag == 0x1f)
                throw (new Exception("BER bad byte tag"));
        }
        public BERtag(Stream s)
        {
            // decoding 8.1.2.4.3
            byte b = ReadByte(s);
            atp = (BERtype)((b & 0xc0) >> 6);
            comp = ((b & 0x20) != 0);
            tag = (ulong)(b & 0x1f);
            if ((b & 0x1f) == 0x1f)
                tag = GetBigTag(s);
        }
        public void Send(Stream s)
        {
            // encoding 8.1.2.4.3
            byte b = (byte)(((uint)atp) << 6 | (uint)(comp ? 0x20 : 0));
            if (tag < 31)
            {
                b |= (byte)tag;
                s.WriteByte(b);
                return;
            }
            b |= 31;
            s.WriteByte(b);
            PutBigTag(s, tag);
        }
        public byte ToByte()
        {
            byte b = (byte)(((uint)atp << 6) | (uint)(comp ? 0x20 : 0));
            if (tag >= 31)
                throw (new Exception("BERtag out of range for convert to byte"));
            b |= (byte)tag;
            return b;
        }
        public bool isEndMarker
        {
            get { return (atp == BERtype.Universal && !comp && tag == 0); }
        }
        public ulong GetBigTag(Stream s)
        {
            ulong r = 0;
            byte x = ReadByte(s);
            do
            {
                r = (r << 7) + (ulong)(x & 0x7f);
            } while ((x & 0x80) != 0);
            return r;
        }
        public void PutBigTag(Stream s, ulong n)
        {
            byte[] c = new byte[16];
            int j = 0;
            while (n > 0)
            {
                c[j++] = (byte)(n & 0x7f);
                n = n >> 7;
            }
            while (j > 0)
            {
                byte x = c[--j];
                if (j > 0)
                    x |= 0x80;
                WriteByte(s, x);
            }
        }
        public int ExtLength() // calculate length required for identifier octets
        {
            if (tag < 31)
                return 1;
            ulong a = tag;
            int j = 1;
            while (a > 0)
            {
                j++;
                a = a >> 7;
            }
            return j;
        }
        public override string ToString()
        {
            if (atp == BERtype.Universal && !comp)
                return ((UniversalType)tag).ToString().ToUpper();
            return "[" + atp.ToString().ToUpper() + " " + (comp ? "SEQUENCE " : "") + tag + "]";
        }
    }
    // The following class provides for the Universal encodings and the encodings needed for SNMP
    // For application or context-specific encodings, derive a class from this and override the
    // Evaluate method, which creates an object called val based on the contents in byte[] b.
    // Evaluate takes a single uint parameter which is the number of bytes to use in b.
    public class Universal : BER
    {
        // override these two functions in any subclass of Universal so that SEQUENCES work correctly
        protected virtual Universal Creator(Stream s) { return new Universal(s); }
        protected virtual Universal[] Creators(int n) { return new Universal[n]; }
        protected Universal() { }
        public static Universal Null
        {
            get
            {
                return new Universal(new BERtag(UniversalType.Null), new Universal[0]);
            }
        }
        public Universal(bool x) // 8.2
        {
            type = new BERtag(UniversalType.Boolean);
            val = x;
            e = true;
            b = new byte[1];
            b[0] = (byte)(x ? 0xff : 0);
        }
        public Universal(int n) // 8.3
        {
            type = new BERtag(UniversalType.Integer);
            val = n;
            e = true;
            b = new Integer(n).octVal;
        }
        public Universal(double d)
        {
            type = new BERtag(UniversalType.Real);
            val = d;
            e = true;
            b = new Real(d).octVal;
        }
        public Universal(BitSet a)
        {
            // encoding 8.6.2
            type = new BERtag(UniversalType.BitString);
            val = a;
            e = true;
            int n = (a.Length + 7) / 8;
            byte r = (byte)(8 - a.Length % 8);
            b = new byte[n + 1];
            int ln = 0;
            b[ln++] = r;
            int k = 24;
            int i = 0;
            for (int j = 0; j < n; j++)
            {
                b[ln++] = (byte)(a.bits[i] >> k);
                k -= 8;
                if (k < 0)
                {
                    i++;
                    k = 24;
                }
            }
        }
        public Universal(string s)
        {
            type = new BERtag(UniversalType.OctetString);
            val = s;
            e = true;
            b = (new ASCIIEncoding()).GetBytes(s);
        }
        public Universal(uint[] oid)
        {
            type = new BERtag(UniversalType.ObjectIdentifier);
            val = oid;
            e = true;
            int ln = 0;
            int j;
            for (j = 1; j < oid.Length; j++)
                ln += LengthOIDEl(oid[j]);
            b = new byte[ln];
            if (oid[0] != 1 || oid[1] != 3)
                throw (new Exception("OID must begin with .1.3"));
            ln = 0;
            PutOIDEl(ref ln, 43);
            for (j = 2; j < oid.Length; j++)
                PutOIDEl(ref ln, oid[j]);
        }
        public Universal(ArrayList a)
        {
            type = new BERtag(0, true, 0);
            e = true;
            ArrayList al = new ArrayList(a.Count);
            val = al;
            for (int j = 0; j < a.Count; j++)
            {
                object o = a[j];
                if (o is bool)
                    al.Add(new Universal((bool)o));
                else if (o is int)
                    al.Add(new Universal((int)o));
                else if (o is BitSet)
                    al.Add(new Universal((BitSet)o));
                else if (o is string)
                    al.Add(new Universal((string)o));
                else if (o is uint[])
                    al.Add(new Universal((uint[])o));
            }
        }
        public Universal(BERtag t, params Universal[] obs)
        {
            type = t;
            val = obs;
            e = true;
            val = obs;
        }
        public Universal(params Universal[] obs) : this(new BERtag(0, true, 16), obs) { }
        protected bool Children(Stream s) // handle SEQUENCE
        {
            if (type.isEndMarker)
                return true;
            byte x = ReadByte(s);
            if (x == 0x80) // use end-of-contents marker
            {
                ArrayList al = new ArrayList();
                val = al;
                Universal bb;
                do
                {
                    bb = Creator(s);
                    al.Add(bb);
                } while (!bb.type.isEndMarker);
                Universal[] obs = Creators(al.Count - 1);
                for (int i = 0; i < al.Count; i++)
                    obs[i] = (Universal)al[i];
                val = obs;
                return true;
            }
            int ln = ReadLength(s, x);
            b = new byte[ln];
            if (type.comp)
            {
                ArrayList c = new ArrayList();
                int n = 0;
                Universal d;
                do
                {
                    long pos = s.Position;
                    d = Creator(s);
                    n += (int)(s.Position - pos);
                    c.Add(d);
                } while (n < ln);
                Universal[] obs = Creators(c.Count);
                for (int i = 0; i < c.Count; i++)
                    obs[i] = (Universal)c[i];
                val = obs;
                return true;
            }
            return false;
        }
        public Universal(Stream s)
        {
            e = false;
            type = new BERtag(s);
            if (Children(s))
            {
                if (type.tag != 0x10)
                    CombineValues();
                return;
            }
            s.Read(b, 0, (int)len);
            ValueOf(len);
        }
        protected int ReadLength(Stream s, byte x) // x is initial octet
        {
            if ((x & 0x80) == 0)
                return (int)x;
            int u = 0;
            int n = (int)(x & 0x7f);
            for (int j = 0; j < n; j++)
            {
                x = ReadByte(s);
                u = (u << 8) + (int)x;
            }
            return u;
        }
        protected void WriteLength(Stream s, int a) // excluding initial octet
        {
            if (a <= 0)
            {
                s.WriteByte(0);
                return;
            }
            byte[] c = new byte[16];
            int j = 0;
            while (a > 0)
            {
                c[j++] = (byte)(a & 0xff);
                a = a >> 8;
            }
            s.WriteByte((byte)(0x80 | j));
            while (j > 0)
            {
                int x = c[--j];
                s.WriteByte((byte)x);
            }
        }
        protected int LengthLength(int a) // excluding initial octet
        {
            int j = 0;
            while (a > 0)
            {
                j++;
                a = a >> 8;
            }
            return j;
        }
        void CombineValues() // handle some special cases
        {
            Universal[] a = (Universal[])val;
            int j;
            switch ((UniversalType)(type.ToByte()))
            {
                case UniversalType.BitString: // 8.6.3
                    BitSet r = (BitSet)a[0].val;
                    for (j = 1; j < a.Length; j++)
                        r = r.Cat((BitSet)a[j].val);
                    val = r; break;
                case UniversalType.OctetString: // 8.7.3
                    OctetString s = (OctetString)a[0].val;
                    for (j = 1; j < a.Length; j++)
                        s += (OctetString)a[j].val;
                    val = s; break;
            }
        }
        protected virtual bool ValueOf(uint n)
        {
            int j = 0;
            switch ((UniversalType)(type.ToByte()))
            {
                case UniversalType.Boolean: val = (b[0] > 0); break;
                case UniversalType.Integer:
                    val = new Integer(b); break;
                case UniversalType.BitString:
                    byte r = b[0];
                    BitSet bs = new BitSet(n * 8 - r); // 8.6.2
                    for (j = 0; j < bs.size; j++)
                        bs.bits[j] = (b[4 * j] << 24) | (b[4 * j + 1] << 16) | (b[4 * j + 2] << 8) | b[4 * j + 3];
                    val = bs; break;
                case UniversalType.OctetString:
                    val = new OctetString(b, 0, n); break;
                case UniversalType.Null:
                    val = null;
                    break;
                case UniversalType.ObjectIdentifier:
                    ArrayList al = new ArrayList();
                    int p = 0;
                    while (p < n)
                        al.Add(GetOIDEl(ref p));
                    uint[] oid;
                    if (((uint)al[0]) == 43)
                    {
                        oid = new uint[al.Count + 1];
                        oid[0] = 1;
                        oid[1] = 3;
                        for (j = 1; j < al.Count; j++)
                            oid[j + 1] = (uint)al[j];
                    }
                    else // can happen that oid is .0??
                    {
                        //				throw(new Exception("OID must begin with .1.3"));
                        oid = new uint[al.Count];
                        for (j = 0; j < al.Count; j++)
                            oid[j] = (uint)al[j];
                    }
                    val = oid; break;
                case UniversalType.Real:
                    val = new Real(b); break;
                case UniversalType.GeneralString:
                    val = ASCIIEncoding.ASCII.GetString(b); break;
                case UniversalType.Enumerated:
                    val = new Integer(b); break;
                default:
                    val = type.ToString() + " unimplemented"; break;
            }
            return true;
        }
        protected int Length
        {
            get
            {
                if (e && val is Universal[])
                {
                    int r = 0;
                    Universal[] a = (Universal[])val;
                    for (int j = 0; j < a.Length; j++)
                    {
                        Universal u = a[j];
                        r += u.Length + LengthLength(u.Length) + 1 + u.type.ExtLength();
                    }
                    return r;
                }
                else
                    return (int)len;
            }
        }
        public void Send(Stream s) // create the external representation
        {
            type.Send(s);
            WriteLength(s, Length);
            if (e && val is Universal[])
            {
                Universal[] a = (Universal[])val;
                for (int j = 0; j < a.Length; j++)
                    a[j].Send(s);
            }
            else
                s.Write(b, 0, (int)Length);
        }
        protected void PutOIDEl(ref int ln, uint a)
        {
            if (a == 0)
            {
                b[ln++] = 0;
                return;
            }
            byte[] c = new byte[16];
            int j = 0;
            while (a > 0)
            {
                c[j++] = (byte)(a & 0x7f);
                a = a >> 7;
            }
            while (j > 0)
            {
                int x = c[--j];
                if (j > 0)
                    x |= 0x80;
                b[ln++] = (byte)x;
            }
        }
        protected uint GetOIDEl(ref int p)
        {
            uint r = 0;
            byte x;
            do
            {
                x = b[p++];
                r = (r << 7) + ((uint)x & 0x7f);	// 0.3.3a (Evan Watson)
            } while ((x & 0x80) != 0);
            return r;
        }
        int LengthOIDEl(uint a)
        {
            int j = 0;
            if (a == 0)
                return 1;
            while (a > 0)
            {
                j++;
                a = a >> 7;
            }
            return j;
        }
        public object Value { get { return val; } }
        public string Type()
        {
            string r = type.ToString();
            if (type.comp)
            {
                r += "{\n";
                Universal[] al = (Universal[])val;
                for (int j = 0; j < al.Length; j++)
                {
                    r += al[j].Type();
                    if (j < al.Length - 1)
                        r += ",\n";
                }
                r += "}";
            }
            return r;
        }
        public override string ToString()
        {
            string r = "";
            if (type.comp)
            {
                r += "{\n";
                Universal[] al = (Universal[])val;
                for (int j = 0; j < al.Length; j++)
                {
                    r += al[j].ToString();
                    if (j < al.Length - 1)
                        r += ",\n";
                }
                r += "}";
            }
            else
            {
                if (val == null)
                    ValueOf(len);
                switch ((UniversalType)type.ToByte()) // Guy McIlroy
                {
                    case UniversalType.BitString:
                        r += "[" + val.ToString() + "]";
                        break;
                    case UniversalType.ObjectIdentifier:
                        uint[] oid = (uint[])val;
                        for (int k = 0; k < oid.Length; k++)
                            r += "." + oid[k];
                        break;
                    case UniversalType.OctetString:
                        r += "\"" + val.ToString() + "\"";
                        break;
                    case UniversalType.Null:
                        r += "NULL"; break;
                    default:
                        r += val.ToString();
                        break;
                }
            }
            return r;
        }
        public void Dump()
        {
            string[] r = ToString().Split('\n');
            for (int i = 0; i < r.Length; i++)
                System.Console.WriteLine(r[i]);
        }
        public Universal this[int ix]
        {
            get
            {
                Universal[] ls = (Universal[])Value;
                return ls[ix];
            }
            set
            {
                Universal[] ls = (Universal[])Value;
                ls[ix] = value;
            }
        }
    }
}