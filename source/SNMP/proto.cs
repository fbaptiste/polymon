
using System;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using System.Text;
using System.Net;
using X690;

// SNMP library for .NET by Malcolm Crowe at University of the West of Scotland
// http://cis.paisley.ac.uk/crow-ci0/
// This is version 0 of the library. Email bugs to
// mailto:malcolm.crowe@paisley.ac.uk

// Getting Started
// The simplest way to get an SNMP value from a host is
// ManagerItem mi = new ManagerItem(
//								new ManagerSession(hostname,"public"),
//								"1.3.6.1.2.1.1.4.0");
// Then the actual OID is mi.Name and the value is in mi.Value.ToString().

// TODO: Tables, lists of bindings
//		 Friendly strings derived from MIBs

namespace Snmp
{
    public class SnmpTag : BERtag
    {
        public SnmpTag(SnmpType s) : base((byte)s) { }
        public SnmpTag() : base() { }
        public SnmpTag(byte t) : base(t) { }
        public override string ToString()
        {
            if (atp == BERtype.Universal)
                return base.ToString();
            return ((SnmpType)ToByte()).ToString().ToUpper();
        }
    }
    public enum SnmpType // RFC1213 subset of ASN.1
    {
        EndMarker = 0x00,
        Boolean = 0x01,
        Integer = 0x02,
        UInt32 = 0x47,
        BitString = 0x03,  // internally BitSet
        OctetString = 0x04, // internally string
        ObjectIdentifier = 0x06, // internally uint[]
        Null = 0x05,
        Sequence = 0x30, // Array
        Counter32 = 0x41,
        Counter64 = 0x46,
        Gauge = 0x42,
        TimeTicks = 0x43,
        IPAddress = 0x40, // byte[]
        Opaque = 0x44,
        NetAddress = 0x45,
        GetRequestPDU = 0xA0,
        GetNextRequestPDU = 0xA1,
        GetResponsePDU = 0xA2,
        SetRequestPDU = 0xA3,
        TrapPDUv1 = 0xA4,
        TrapPDUv2 = 0xA7,
        GetBulkRequest = 0xA5,
        InformRequest = 0xA6
    }
    public class SnmpBER : Universal
    {
        // These 3 declarations are needed to make the Universal machinery for SEQUENCEs work correctly
        protected override Universal Creator(Stream s) { return new SnmpBER(s); }
        protected override Universal[] Creators(int n) { return new SnmpBER[n]; }
        protected override bool ValueOf(uint n)
        {
            switch ((SnmpType)(type.ToByte()))
            {
                case SnmpType.UInt32: val = GetUInt(); break;
                case SnmpType.Counter32:
                    val = (uint)GetUInt(); break;
                case SnmpType.Counter64:
                    val = GetULong(); break;
                case SnmpType.Gauge:
                    val = GetUInt(); break;
                case SnmpType.TimeTicks:
                    val = GetUInt(); break;
                case SnmpType.IPAddress:
                    val = b; break;
                default:
                    return base.ValueOf(n); // handle Universal types
            }
            return true;
        }
        public override string ToString()
        {
            if (val == null)
                ValueOf(len);
            if (val is byte[])
            {
                string r = "";
                for (int j = 0; j < len; j++)
                {
                    r += b[j];
                    if (j < len - 1)
                        r += ".";
                }
                return r;
            }
            else
                return base.ToString();
        }
        public SnmpBER(Stream s) : base(s) { }
        public SnmpBER(SnmpType t)
        {
            b = new byte[0];
            e = true;
            type = new SnmpTag(t);
        }
        public SnmpBER(ulong c, SnmpType t)
        {
            type = new SnmpTag(t);
            e = true;
            b = new byte[ULongLength(c)];
            int n = 0;
            PutULong(ref n, c);
        }
        public SnmpBER(uint c) : this((ulong)c, SnmpType.Counter32) { }
        public SnmpBER(byte[] a) // IPAddress
        {
            type = new SnmpTag(SnmpType.IPAddress);
            e = true;
            b = a;
        }
        public SnmpBER(SnmpType t, params Universal[] obs) : base(new SnmpTag(t), obs) { }
        void PutULong(ref int ln, ulong a)
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
                c[j++] = (byte)(a & 0xff);
                a = a >> 8;
            }
            while (j > 0)
                b[ln++] = c[--j];
        }
        uint ULongLength(ulong a)
        {
            if (a == 0)
                return 1;
            uint j = 0;
            while (a > 0)
            {
                j++;
                a = a >> 8;
            }
            return j;
        }
        ulong GetULong()
        {
            ulong r = 0;
            int p = 0;
            byte x;
            do
            {
                x = b[p++];
                r = (r << 8) + (ulong)x;
            } while (p < len);
            return r;
        }
        ulong GetUInt()
        {
            uint r = 0;
            int p = 0;
            byte x;
            do
            {
                x = b[p++];
                r = (r << 8) + (uint)x;
            } while (p < len);
            return r;
        }
    }
    public class ManagerSession
    {
        public string agentAddress;
        public string agentCommunity;
        IPEndPoint agent;
        int seq = 0;
        UdpClient udp = new UdpClient();
        public ManagerSession(string a, string c)
        {
            agentAddress = a;
            agentCommunity = c;
            IPAddress host = Dns.GetHostEntry(a).AddressList[0];
            agent = new IPEndPoint(host, 161);
        }
        public void Close() { udp.Close(); }
        public Universal VarBind(uint[] oid)
        {
            return VarBind(oid, Universal.Null);
        }
        public Universal VarBind(uint[] oid, Universal val)
        {
            return new Universal(new Universal(oid), val);
        }
        public Universal PDU(SnmpType t, params Universal[] vbinds)
        {
            seq += 10;
            return new SnmpBER(t,
                new Universal(seq),
                new Universal(0), // errorStatus
                new Universal(0), // errorIndex
                new Universal(vbinds));
        }
        public Universal[] Get(params Universal[] vbinds)
        {
            SnmpBER mess = new SnmpBER(SnmpType.Sequence,
                new Universal(0), // version-1
                new Universal(agentCommunity),
                PDU(SnmpType.GetRequestPDU, vbinds));
            MemoryStream m = new MemoryStream();
            mess.Send(m);
            byte[] bytes = m.ToArray();
            udp.Send(bytes, bytes.Length, agent);
            IPEndPoint from = new IPEndPoint(IPAddress.Any, 0);
            IAsyncResult result = udp.BeginReceive(null, this);
            result.AsyncWaitHandle.WaitOne(100, false);
            if (!result.IsCompleted)
                return null;
            bytes = udp.EndReceive(result, ref from);
            m = new MemoryStream(bytes, false);
            mess = new SnmpBER(m);
            Universal pdu = mess[2];
            Universal vbindlist = pdu[3];
            return (Universal[])vbindlist.Value;
        }
        public void Set(params Universal[] vbinds)
        {
            SnmpBER mess = new SnmpBER(SnmpType.Sequence,
                new Universal(0), // version-1
                new Universal(agentCommunity),
                PDU(SnmpType.SetRequestPDU, vbinds));
            MemoryStream m = new MemoryStream();
            mess.Send(m);
            byte[] bytes = m.ToArray();
            udp.Send(bytes, bytes.Length, agent);
        }
        public bool GetNext(ref Universal vbind)
        {
            SnmpBER mess = new SnmpBER(SnmpType.Sequence,
                new Universal(0), // version-1
                new Universal(agentCommunity),
                PDU(SnmpType.GetNextRequestPDU, vbind));
            MemoryStream m = new MemoryStream();
            mess.Send(m);
            byte[] bytes = m.ToArray();
            IPAddress host = Dns.GetHostEntry(agentAddress).AddressList[0];
            agent = new IPEndPoint(host, 161);
            udp.Send(bytes, bytes.Length, agent);
            IPEndPoint from = new IPEndPoint(IPAddress.Any, 0);
            IAsyncResult result = udp.BeginReceive(null, this);
            result.AsyncWaitHandle.WaitOne(100, false);
            if (!result.IsCompleted)
                return false;
            bytes = udp.EndReceive(result, ref from);
            m = new MemoryStream(bytes, false);
            mess = new SnmpBER(m);
            Universal pdu = mess[2];
            if (((int)(X690.Integer)pdu[1].Value) != 0) // errorStatus
                return false;
            Universal vbindlist = pdu[3];
            vbind = ((Universal[])vbindlist.Value)[0];
            return true;
        }
    }
    public class ManagerItem
    {
        bool isCached = false;
        protected ManagerSession sess;
        public Universal Value
        {
            get
            {
                try
                {
                    if (isCached)
                        return varbind[1];
                    varbind = sess.Get(sess.VarBind(Oid))[0];
                    isCached = true;
                    return varbind[1];
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                // crash if ManagerItem does not already contain a binding
                varbind[1] = value;
                isCached = true;
                sess.Set(varbind);
            }
        }
        public uint[] Oid
        {
            get
            {
                return (uint[])(varbind[0].Value);
            }
        }
        Universal varbind;
        public ManagerItem(ManagerSession s, uint[] oid) : this(s, s.VarBind(oid)) { }
        public ManagerItem(ManagerSession s, Universal v)
        {
            sess = s;
            varbind = v;
        }
        public void Refresh()
        {
            isCached = false;
        }
    }
    public class ManagerSubTree
    {
        protected ManagerSession sess;
        ArrayList values = new ArrayList(); // of Universal (Variable Binding) 0:OID 1:Value
        uint[] start = null;
        public ManagerSubTree(ManagerSession s, uint[] oid)
        {
            sess = s;
            start = oid;
            Refresh();
        }
        bool Match(uint[] a, uint[] b) // check that b starts with a
        {
            if (b.Length < a.Length)
                return false;
            for (int j = 0; j < a.Length; j++)
                if (a[j] != b[j])
                    return false;
            return true;
        }
        public void Refresh()
        {
            Universal v = sess.VarBind(start);
            values.Clear();
            uint[] next = start;
            bool fix = false;
            while (sess.GetNext(ref v))
            {
                uint[] from = (uint[])v[0].Value;
                if (!Match(start, from)) // outside the start subtree
                    break;
                // the SNMP standard says that from should be lexicographically greater than next
                if (from.Length <= next.Length && Match(from, next))   // non-compliance
                {
                    if (fix || (from.Length < next.Length)) // already tried to fix it or agent really bad
                        throw (new Exception("Non-compliant agent"));
                    fix = true; // try as a fix to add .0 on the end
                    next = new uint[from.Length + 1];
                    for (int j = 0; j < from.Length; j++)
                        next[j] = from[j];
                    next[from.Length] = 0; // and try again
                }
                else // compliant: add it to the result set
                {
                    values.Add(v);
                    next = from;
                    fix = false;
                }
                v = sess.VarBind(next);
            }
        }
        public int Length { get { return values.Count; } }
        public ManagerItem this[int x] { get { return new ManagerItem(sess, (Universal)values[x]); } }
        public _Enumerator GetEnumerator()
        {
            return new _Enumerator(this);
        }
        public class _Enumerator
        {
            ManagerSubTree st;
            int ix = -1;
            public _Enumerator(ManagerSubTree t) { st = t; }
            public bool MoveNext()
            {
                if (ix == st.Length - 1)
                    return false;
                ix++;
                return true;
            }
            public ManagerItem Current { get { return st[ix]; } }
            public void Reset() { ix = -1; }
        }
    }
}