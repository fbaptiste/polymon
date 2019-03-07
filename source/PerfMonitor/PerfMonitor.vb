Imports System.Xml
Imports PolyMon.Status

'<PerfMonitor>
'	<Host>localhost</Host>
'	<Category>Processor</Category>
'	<Counter>% Processor Time</Counter>
'	<Instance>_Total</Instance>
'	<FailThresholds>
'        <Max Enabled="1">90</Max>
'        <Min Enabled="0"></Min>
'    </FailThresholds>
'    <WarnThresholds>
'        <Max Enabled="1">75</Max>
'        <Min Enabled="0"></Min>
'    </WarnThresholds>
'</PerfMonitor>

Namespace Monitors
    Public Class PerfMonitor
        Inherits PolyMon.Monitors.MonitorExecutor

        Public Sub New(ByVal MonitorID As Integer)
            MyBase.New(MonitorID)
        End Sub

		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As Monitors.MonitorExecutor.MonitorStatus
			Dim IsError As Boolean = False
			Dim IsWarning As Boolean = False

			Try
				Dim RootNode As XmlNode = MonitorXML.DocumentElement

				'Read Params
				Dim Host As String
				Dim Category As String
				Dim Counter As String
				Dim Instance As String

				Dim FailMaxEnabled As Boolean
				Dim FailMax As Double
				Dim FailMinEnabled As Boolean
				Dim FailMin As Double

				Dim WarnMaxEnabled As Boolean
				Dim WarnMax As Double
				Dim WarnMinEnabled As Boolean
				Dim WarnMin As Double

				Host = (ReadXMLNodeValue(RootNode.SelectSingleNode("Host")) & "").Trim()
				Category = (ReadXMLNodeValue(RootNode.SelectSingleNode("Category")) & "").Trim()
				Counter = (ReadXMLNodeValue(RootNode.SelectSingleNode("Counter")) & "").Trim()
				Instance = (ReadXMLNodeValue(RootNode.SelectSingleNode("Instance")) & "").Trim()

				FailMaxEnabled = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("FailThresholds/Max").Attributes("Enabled")))
				If FailMaxEnabled Then FailMax = CDbl(ReadXMLNodeValue(RootNode.SelectSingleNode("FailThresholds/Max")))

				FailMinEnabled = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("FailThresholds/Min").Attributes("Enabled")))
				If FailMinEnabled Then FailMin = CDbl(ReadXMLNodeValue(RootNode.SelectSingleNode("FailThresholds/Min")))

				WarnMaxEnabled = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnThresholds/Max").Attributes("Enabled")))
				If WarnMaxEnabled Then WarnMax = CDbl(ReadXMLNodeValue(RootNode.SelectSingleNode("WarnThresholds/Max")))
				WarnMinEnabled = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnThresholds/Min").Attributes("Enabled")))
				If WarnMinEnabled Then WarnMin = CDbl(ReadXMLNodeValue(RootNode.SelectSingleNode("WarnThresholds/Min")))

				'Run Test
				Dim PerfMon As New PerformanceCounter(Category, Counter, Instance, Host)
				Dim PerfMonValue As Double
				Dim SleepMS As Integer = 200
				'Usually have to get NextValue twice to start getting meaningful data
				PerfMonValue = PerfMon.NextValue
				Threading.Thread.Sleep(SleepMS)
				PerfMonValue = PerfMon.NextValue
				PerfMon.Close()
				PerfMon = Nothing

				'Write value to counter
				Me.MonitorCounters.Add(New Counter(Counter & " -> " & Instance, PerfMonValue))

				'Now Compare PerfMonValue against lower/upper fail/warn threshold bounds
				If FailMaxEnabled Then
					If PerfMonValue > FailMax Then
						IsError = True
						StatusMessage = "Fail. Performance counter exceeded Max threshold. Counter=" & CStr(PerfMonValue)
					End If
				End If
				If Not (IsError) Then
					If FailMinEnabled Then
						If PerfMonValue < FailMin Then
							IsError = True
							StatusMessage = "Fail. Performance counter below Min threshold. Counter=" & CStr(PerfMonValue)
						End If
					End If
				End If
				If Not (IsError) Then
					If WarnMaxEnabled Then
						If PerfMonValue > WarnMax Then
							IsWarning = True
							StatusMessage = "Warning. Performance counter exceeded Max threshold. Counter=" & CStr(PerfMonValue)
						End If
					End If
					If Not (IsWarning) Then
						If PerfMonValue < WarnMin Then
							IsWarning = True
							StatusMessage = "Warning. Performance counter below Min theshold. Counter=" & CStr(PerfMonValue)
						End If
					End If
				End If
			Catch ex As Exception
				IsError = True
				StatusMessage = "Fail. " & ex.Message
			End Try

			If IsError Then
				Return MonitorExecutor.MonitorStatus.Fail
			ElseIf IsWarning Then
				Return MonitorExecutor.MonitorStatus.Warn
			Else
				StatusMessage = "OK."
				Return MonitorExecutor.MonitorStatus.OK
			End If
		End Function

        Private Function ReadXMLNodeValue(ByVal myXMLNode As XmlNode) As String
            If myXMLNode Is Nothing Then
                Return Nothing
            Else
                If myXMLNode Is Nothing OrElse myXMLNode.InnerXml = Nothing Then
                    Return Nothing
                Else
					Return myXMLNode.InnerText.Trim()
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