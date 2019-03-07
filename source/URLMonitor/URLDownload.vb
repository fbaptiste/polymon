Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Web



Friend Class URLDownload

#Region "Private Attributes"
    Private mURL As String
    Private mStatusMessage As String = Nothing
    Private mStatusCode As StatusCodes
    Private mHTTPResponse As String = Nothing
    Private mTimeOut As Integer

    'Private Const mUserAgentHeader As String = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; SysMon; .NET CLR 1.0.3705; .NET CLR 1.1.4322)"
	'Private Const mUserAgentHeader As String = "Mozilla/4.0 (compatible; MSIE 6.0; PolyMon)"
	Private Const mUserAgentHeader As String = "(PolyMon; System Monitoring)"
#End Region

#Region "Public Interface"
    Public Enum StatusCodes As Integer
        OK = 0
        Failed = 1
    End Enum
    Public Sub New(ByVal URL As String, ByVal TimeOutSecs As Integer)
        If URL Is Nothing OrElse URL.Trim.Length = 0 Then
            mStatusCode = StatusCodes.Failed
            mStatusMessage = "Invalid URL (Empty)."
            Exit Sub
        Else
            mURL = URL.Trim()
        End If

        If TimeOutSecs <= 0 Then
            mTimeOut = System.Threading.Timeout.Infinite
        Else
            mTimeOut = TimeOutSecs * 1000
        End If

        DownloadURL()
    End Sub

    Public ReadOnly Property StatusCode() As StatusCodes
        Get
            Return mStatusCode
        End Get
    End Property
    Public ReadOnly Property StatusMessage() As String
        Get
            Return mStatusMessage
        End Get
    End Property
    Public ReadOnly Property HTTPResponse() As String
        Get
            Return mHTTPResponse
        End Get
    End Property
#End Region

#Region "Private Methods"
    Private Sub DownloadURL()
        Try
			Dim req As WebRequest = WebRequest.Create(mURL)
			Try
				CType(req, HttpWebRequest).UserAgent = mUserAgentHeader
			Finally

			End Try

			req.Timeout = mTimeOut 'milliseconds
			Dim res As WebResponse = req.GetResponse()

			Dim stream As Stream = res.GetResponseStream()
			Dim stReader As New StreamReader(stream, True)
			Dim strRes As New StringBuilder("")
			strRes.Append(stReader.ReadToEnd())

			stReader.Close()
			stream.Close()
			'Dim iTotalBuff As Integer = 0
			'Dim Buffer(126) As [Byte]
			'Dim stream As Stream = res.GetResponseStream()
			'iTotalBuff = stream.Read(Buffer, 0, 127)
			'Dim strRes As New StringBuilder("")
			'While iTotalBuff <> 0
			'    strRes.Append(Encoding.Unicode.GetString(Buffer, 0, iTotalBuff))
			'    iTotalBuff = stream.Read(Buffer, 0, 127)
			'End While
			mHTTPResponse = strRes.ToString()
			mStatusMessage = "OK"
			mStatusCode = StatusCodes.OK
		Catch e As WebException
			mStatusCode = StatusCodes.Failed
			mStatusMessage = e.Message()
		Catch e As Exception
			mStatusCode = StatusCodes.Failed
			mStatusMessage = e.Message()
		End Try
	End Sub	'DownloadURL
#End Region

End Class 'URLDownload
