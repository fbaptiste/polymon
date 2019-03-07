Imports System.Xml
Imports system.Net.NetworkInformation
Imports PolyMon.Status

'This monitor will ping a specified host (name or IP) 
'OK, Fail is based on the number of failed/succesful succesive pings
'out of a total number of tries.

'The XML definition for this monitor's settings is specified as follows:
'<PingMonitor>
'	<Host>localhost</Host>
'	<NumTries>5</NumTries>
'	<MaxFail>2</MaxFail>
'	<Timeout>2000</Timeout>
'	<TTL>32</TTL>
'	<DataSize>32</DataSize>
'</PingMonitor>
'
'Notes: 
'Timeout specifies, in milliseconds, the time interval after which a ping is considered to have failed if no response has been received.
'NumTries defines the number of successive pings the monitor should run with MaxFail the upper limit of failed/timed-out pings in a cycle 
'after which the Ping test is considered to have failed.

'This monitor generates two counters indicating the average response time over the specified number of tries 
'and the percentage of succesful pings

Namespace Monitors
    Public Class PingMonitor
        Inherits PolyMon.Monitors.MonitorExecutor

        Public Sub New(ByVal MonitorID As Integer)
            MyBase.New(MonitorID)
        End Sub

		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As MonitorExecutor.MonitorStatus
			Dim Host As String
			Dim NumTries As Integer
			Dim MaxFail As Integer
			Dim Timeout As Integer
			Dim TTL As Byte
			Dim DataSize As Integer

			Dim RootNode As XmlNode = Me.MonitorXML.DocumentElement
			Dim NodeValue As String

			Try
				'Host
				Host = ReadXMLNodeValue(RootNode.SelectSingleNode("Host"))
				'NumTries
				NodeValue = ReadXMLNodeValue(RootNode.SelectSingleNode("NumTries"))
				NumTries = CInt(IIf(NodeValue = Nothing, 1, NodeValue))
				'MaxFail
				NodeValue = ReadXMLNodeValue(RootNode.SelectSingleNode("MaxFail"))
				MaxFail = CInt(IIf(NodeValue = Nothing, 1, NodeValue))
				'Timeout
				NodeValue = ReadXMLNodeValue(RootNode.SelectSingleNode("Timeout"))
				Timeout = CInt(IIf(NodeValue = Nothing, 2000, NodeValue))
				'TTL
				NodeValue = ReadXMLNodeValue(RootNode.SelectSingleNode("TTL"))
				TTL = CByte(IIf(NodeValue = Nothing, 32, NodeValue))
				'DataSize
				NodeValue = ReadXMLNodeValue(RootNode.SelectSingleNode("DataSize"))
				DataSize = CInt(IIf(NodeValue = Nothing, 32, NodeValue))

				Dim iTry As Integer = 1

				Dim PSender As New Ping
				Dim POptions As New PingOptions
				Dim PReply As PingReply
				Dim Data As String = New String(CChar("a"), DataSize)

				Dim Buffer As Byte() = System.Text.Encoding.ASCII.GetBytes(Data)

				POptions.Ttl = TTL

				Dim CumPingTime As Long
				Dim TotalPingsOK As Integer
				Dim TotalPingsFail As Integer = 0

				For iTry = 1 To NumTries
					'PingResult = My.Computer.Network.Ping(Host, Timeout)
					PReply = PSender.Send(Host, Timeout, Buffer, POptions)

					If Not (PReply.Status = IPStatus.Success) Then
						TotalPingsFail += 1
						StatusMessage = PReply.Status.ToString()
					Else
						TotalPingsOK += 1
						CumPingTime += PReply.RoundtripTime
					End If
				Next

				'Add Counters
				'Avg RTT
				If TotalPingsOK > 0 Then
					Counters.Add(New Counter("AvgRTT", CDbl(CumPingTime / TotalPingsOK)))
				Else
					'Cannot generate RTT counter...
					'Counters.Add(New Counter("AvgRTT", 0))
				End If
				'Percentage OK
				Dim PercOK As Double
				PercOK = CDbl((TotalPingsOK / (TotalPingsOK + TotalPingsFail))) * 100
				Counters.Add(New Counter("PercOK", PercOK))

				If TotalPingsFail > MaxFail Then
					'Failed test
					'StatusMessage = "Fail. Number of failed pings exceeded " & CStr(MaxFail)
					Return MonitorExecutor.MonitorStatus.Fail
				Else
					'Passed Test
					StatusMessage = "OK."
					Return MonitorExecutor.MonitorStatus.OK
				End If
			Catch ex As Exception
				StatusMessage = ex.Message & vbCrLf & ex.InnerException.Message
				Return MonitorExecutor.MonitorStatus.Fail
			Finally
				RootNode = Nothing
			End Try
		End Function

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