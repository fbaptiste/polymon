Imports System.Xml
Imports PolyMon.Status

Namespace Monitors
	'The XML definition for this monitor is:
	'<CPUMonitor>
	'	<Host></Host>
	'	<Fail Enabled="0|1" Type="Total|Any">...</Fail>
	'	<Warn Enabled="0|1" Type="Total|Any">...</Warn>
	'</CPUMonitor>
	Public Class CPUMonitor
		Inherits PolyMon.Monitors.MonitorExecutor

		Public Sub New(ByVal MonitorID As Integer)
			MyBase.New(MonitorID)
		End Sub

		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As MonitorExecutor.MonitorStatus
			Dim IsFail As Boolean = False
			Dim IsWarning As Boolean = False

			Try
				Dim RootNode As XmlNode = MonitorXML.DocumentElement

				'Read Params
				Dim Host As String

				Dim FailEnabled As Boolean = False
				Dim FailType As String = Nothing
				Dim FailValue As Double = 0

				Dim WarnEnabled As Boolean = False
				Dim WarnType As String = Nothing
				Dim WarnValue As Double = 0


				Host = (ReadXMLNodeValue(RootNode.SelectSingleNode("Host")) & "").Trim()

				Dim Category As String = "Processor"
				Dim Counter As String = "% Processor Time"
				Dim Instance As String = Nothing


				FailEnabled = MakeBoolean(ReadXMLAttributeValue(RootNode.SelectSingleNode("Fail").Attributes("Enabled")))
				If FailEnabled Then
					FailType = ReadXMLAttributeValue(RootNode.SelectSingleNode("Fail").Attributes("Type")).ToUpper()
					If FailType <> "TOTAL" Then FailType = "ANY"
					FailValue = CDbl(ReadXMLNodeValue(RootNode.SelectSingleNode("Fail")))
				End If

				WarnEnabled = MakeBoolean(ReadXMLAttributeValue(RootNode.SelectSingleNode("Warn").Attributes("Enabled")))
				If WarnEnabled Then
					WarnType = ReadXMLAttributeValue(RootNode.SelectSingleNode("Warn").Attributes("Type")).ToUpper
					If WarnType <> "TOTAL" Then WarnType = "ANY"
					WarnValue = CDbl(ReadXMLNodeValue(RootNode.SelectSingleNode("Warn")))
				End If


				'We have to monitor status based on Type="TOTAL" or Type="ANY"

				'First determine all Processor instances on specified Host including _Total
				Dim PerfCat As PerformanceCounterCategory

				If String.IsNullOrEmpty(Host) OrElse Host.ToUpper.Contains("LOCALHOST") Then
					PerfCat = New PerformanceCounterCategory(Category)
				Else
					PerfCat = New PerformanceCounterCategory(Category, Host)
				End If

				'Retrieve Instance Names
				Dim Instances As New List(Of String)
				If PerfCat.CategoryType = PerformanceCounterCategoryType.SingleInstance Then
					'Single instance
				Else
					'Multiple Instance
					For Each PerfInstance As String In PerfCat.GetInstanceNames()
						Instances.Add(PerfInstance)
					Next
				End If

				'Create Performance Counter List
				Dim PerfCounters As New Dictionary(Of String, PerformanceCounter)
				For Each InstanceName As String In Instances
					PerfCounters.Add(InstanceName, New PerformanceCounter(Category, Counter, InstanceName, Host))
				Next

				'Read Performance Counter Values
				Dim PerfValues As New Dictionary(Of String, Double)

				'First do an empty read on each performance counter and init counter value list
				For Each Instance In Instances
					PerfCounters(Instance).NextValue()
					PerfValues.Add(Instance, 0)
				Next

				'Now read counter values a number of times to get a more averaged picture
				Dim NumSamples As Integer = 0
				Dim MaxSamples As Integer = 10
				While NumSamples < MaxSamples
					Threading.Thread.Sleep(80) 'pause a little between sampling
					For Each Instance In ShuffleList(Instances)
						PerfValues.Item(Instance) += PerfCounters.Item(Instance).NextValue()
					Next
					NumSamples += 1
				End While

				'Now calculate averages
				For Each Instance In Instances
					PerfValues.Item(Instance) /= CDbl(NumSamples)
				Next

				'Store counter values and determine if Fail/Warnings should occur
				Me.MonitorCounters.Add(New Counter("CPU: Total", PerfValues.Item("_Total")))
				If FailEnabled AndAlso FailType = "TOTAL" AndAlso PerfValues.Item("_Total") > FailValue Then
					IsFail = True
				End If
				If WarnEnabled AndAlso WarnType = "TOTAL" AndAlso PerfValues.Item("_Total") > WarnValue Then
					IsWarning = True
				End If

				For Each Instance In PerfValues.Keys
					If Instance <> "_Total" Then
						Me.MonitorCounters.Add(New Counter(String.Format("CPU: {0}", Instance), PerfValues.Item(Instance)))
						If FailEnabled AndAlso FailType = "ANY" AndAlso PerfValues.Item(Instance) > FailValue Then
							IsFail = True
						End If
						If WarnEnabled AndAlso WarnType = "ANY" AndAlso PerfValues.Item(Instance) > WarnValue Then
							IsWarning = True
						End If
					End If
				Next


				If IsFail Then
					StatusMessage = "Fail. CPU (% Processor Time) exceeded threshold value"
				ElseIf IsWarning Then
					StatusMessage = "Warning. CPU (% Processor Time) exceeded threshold value"
				Else
					StatusMessage = "OK."
				End If

			Catch ex As Exception
				IsFail = True
				StatusMessage = "Fail. " & ex.Message
			End Try

			If IsFail Then 'Fail takes precedence over Warnings
				Return MonitorExecutor.MonitorStatus.Fail
			ElseIf IsWarning Then
				Return MonitorExecutor.MonitorStatus.Warn
			Else
				Return MonitorExecutor.MonitorStatus.OK
			End If
		End Function

		Private Function ShuffleList(ByVal MyList As List(Of String)) As List(Of String)
			Try
				Dim TempList As New List(Of String)
				TempList.Clear()
				TempList.AddRange(MyList)

				Dim Index As Integer
				Dim RndIndex As Integer
				Dim RndObj As New Random()
				Dim TempElement As String

				For Index = TempList.Count - 1 To 1 Step -1
					RndIndex = RndObj.Next(Index + 1)
					If RndIndex <> Index Then
						TempElement = TempList(Index)
						TempList(Index) = TempList(RndIndex)
						TempList(RndIndex) = TempElement
					End If
				Next

				Return TempList
			Catch ex As Exception
				Return MyList
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

		Private Function MakeBoolean(ByVal Value As String) As Boolean
			Try
				Return CBool(Value)
			Catch ex As Exception
				Return False
			End Try
		End Function
	End Class
End Namespace