Imports System.Xml
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports PolyMon.Status

'<TcpPortMonitor>
'   <Host></Host>
'   <Port></Port>
'   <Timeout></Timeout>
'</TcpPortMonitor>

Namespace Monitors
    ''' <summary>
    ''' Monitors a TCP socket for connectivity
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TCPMonitor
        Inherits PolyMon.Monitors.MonitorExecutor

        Private mConnectStartTime As DateTime = Nothing
        Private mConnectEndTime As DateTime = Nothing

		Private mTCPClient As TcpClient
		Private WithEvents mTimer As System.Timers.Timer
		Private mIsTimeoutError As Boolean


        Public Sub New(ByVal MonitorID As Integer)
            MyBase.New(MonitorID)
        End Sub

		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As MonitorExecutor.MonitorStatus
			'Read Monitor configuration from XML
			Dim Host As String = Nothing
			Dim Port As Integer = 0
			Dim Timeout As Double = 2000


			Try
				Dim RootNode As XmlNode = MonitorXML.DocumentElement
				Dim NodeValue As String

				Host = ReadXMLNodeValue(RootNode.SelectSingleNode("Host"))
				Port = CInt(ReadXMLNodeValue(RootNode.SelectSingleNode("Port")))

				NodeValue = ReadXMLNodeValue(RootNode.SelectSingleNode("Timeout"))
				Timeout = CDbl(IIf((NodeValue Is Nothing), 2000, NodeValue))

				mTCPClient = New TcpClient()
				mTCPClient.LingerState.Enabled = False
				mIsTimeoutError = False

				'Attemp connection and start timer
				mTimer = New System.Timers.Timer(Timeout)
				mTimer.AutoReset = False 'Timer will only fire once
				mConnectStartTime = Now()
				mTimer.Start()
				Try
					mTCPClient.Connect(Host, Port) 'If timeout is reached, timer event handler will cause this method to fail
					mConnectEndTime = Now()
					mTimer.Stop()
					mTimer.Close()
				Catch ex As Exception
					If mIsTimeoutError Then
						'Method call failed because we "timed it out" in the timer event handler... 
						StatusMessage = "Timeout exceeded."
						Return MonitorStatus.Fail
					Else
						'Something else happened...
						StatusMessage = ex.Message
						Return MonitorStatus.Fail
					End If
				End Try

				If mTCPClient.Connected Then
					StatusMessage = "OK."
					Counters.Add(New Counter("Connect Time", mConnectEndTime.Subtract(mConnectStartTime).Milliseconds))
					Return MonitorStatus.OK
				Else
					'We should be connected since no error occurred, but just in case something slipped through.
					StatusMessage = "Undetermined error."
					Return MonitorStatus.Fail
				End If

			Catch ex As Exception
				StatusMessage = ex.Message
				Return MonitorStatus.Fail
			Finally
				'Close any open connections
				If mTCPClient IsNot Nothing AndAlso mTCPClient.Client IsNot Nothing Then
					If mTCPClient.Connected Then mTCPClient.Client.Close()
					mTCPClient.Close()
				End If
			End Try
		End Function

		Private Sub mTimer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles mTimer.Elapsed
			Try
				mIsTimeoutError = True
				If mTCPClient IsNot Nothing Then
					'Closing will generate an error in the TcpClient.Connect method
					'so we need to trap that exception back there and handle as a timeout error
					mTCPClient.Close()
				End If
			Catch ex As Exception
				'Do nothing...
			End Try
		End Sub

		Private Function ReadXMLNodeValue(ByVal myXMLNode As XmlNode) As String
			If myXMLNode Is Nothing Then
				Return Nothing
			Else
				If myXMLNode Is Nothing OrElse myXMLNode.InnerXml = Nothing Then
					Return Nothing
				Else
					Return myXMLNode.InnerXml.Trim()
				End If
			End If
		End Function
		Private Function ReadXMLAttributeValue(ByVal myXMLAttribute As XmlAttribute) As String
			If myXMLAttribute Is Nothing Then
				Return Nothing
			Else
				If myXMLAttribute.Value Is Nothing OrElse myXMLAttribute.Value.Trim() = "" Then
					Return Nothing
				Else
					Return myXMLAttribute.Value.Trim()
				End If
			End If
		End Function

	End Class
End Namespace
