Imports System.Xml
Imports System.Management.Automation
Imports PolyMon.Status

Namespace Monitors
	Public Class PowerShellMonitor
		Inherits PolyMon.Monitors.MonitorExecutor

		Public Sub New(ByVal MonitorID As Integer)
			MyBase.New(MonitorID)
		End Sub

		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As MonitorExecutor.MonitorStatus
			Dim RootNode As XmlNode = Me.MonitorXML.DocumentElement
			Dim Script As String = Nothing
			Dim myRunspace As Runspaces.Runspace = Nothing

			Try
				Dim myStatus As New PSStatus()
				Dim myCounters As New PSCounters()

				'Script

				Script = ReadXMLNodeValue(RootNode.SelectSingleNode("Script"))
				If Not String.IsNullOrEmpty(Script) Then Script = XMLDecode(Script)

				If String.IsNullOrEmpty(Script) Then
					'Nothing to execute - simply return a fail stating this
					Throw New Exception("Script not supplied.")
				Else
					myRunspace = Runspaces.RunspaceFactory.CreateRunspace()
					myRunspace.Open()

					Dim myPipeline As Runspaces.Pipeline = myRunspace.CreatePipeline(Script)

					myRunspace.SessionStateProxy.SetVariable("Status", myStatus)
					myRunspace.SessionStateProxy.SetVariable("Counters", myCounters)
					myPipeline.Invoke()
				End If

				StatusMessage = myStatus.StatusText
				For Each myCounter As PSCounter In myCounters.Items
					Counters.Add(New Counter(myCounter.CounterName, myCounter.CounterValue))
				Next
				Return CType(myStatus.StatusID, PolyMon.Monitors.MonitorExecutor.MonitorStatus)
			Catch ex As Exception
				StatusMessage = ex.Message
				If ex.InnerException IsNot Nothing Then
					StatusMessage &= vbCrLf & ex.InnerException.Message
				End If
				Return MonitorExecutor.MonitorStatus.Fail
			Finally
				If myRunspace IsNot Nothing Then
					If myRunspace.RunspaceStateInfo.State <> Runspaces.RunspaceState.Closed Then myRunspace.Close()
					myRunspace.Dispose()
				End If
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

		Private Function XMLEncode(ByVal XMLString As String) As String
			Dim tmpStr As String = XMLString

			tmpStr = tmpStr.Replace("&", "&amp;")
			tmpStr = tmpStr.Replace("<", "&lt;")
			tmpStr = tmpStr.Replace(">", "&gt;")
			tmpStr = tmpStr.Replace("""", "&quot;")
			tmpStr = tmpStr.Replace("'", "&apos;")

			Return tmpStr
		End Function

		Private Function XMLDecode(ByVal XMLString As String) As String
			Dim tmpStr As String = XMLString

			tmpStr = tmpStr.Replace("&amp;", "&")
			tmpStr = tmpStr.Replace("&lt;", "<")
			tmpStr = tmpStr.Replace("&gt;", ">")
			tmpStr = tmpStr.Replace("&quot;", """")
			tmpStr = tmpStr.Replace("&apos;", "'")

			Return tmpStr
		End Function

		Public Class PSStatus
			Private mStatusText As String
			Private mStatusID As StatusCodes

			Public Enum StatusCodes As Integer
				OK = 1
				Warn = 2
				Fail = 3
			End Enum

			Public Property StatusText() As String
				Get
					Return mStatusText
				End Get
				Set(ByVal value As String)
					mStatusText = value
				End Set
			End Property
			Public Property StatusID() As StatusCodes
				Get
					Return mStatusID
				End Get
				Set(ByVal value As StatusCodes)
					mStatusID = value
				End Set
			End Property
		End Class
		Public Class PSCounter
			Private mCounterName As String
			Private mCounterValue As Double

			Public Sub New(ByVal CounterName As String, ByVal CounterValue As Double)
				mCounterName = CounterName
				mCounterValue = CounterValue
			End Sub

			Public ReadOnly Property CounterName() As String
				Get
					Return mCounterName
				End Get
			End Property
			Public ReadOnly Property CounterValue() As Double
				Get
					Return mCounterValue
				End Get
			End Property
		End Class
		Public Class PSCounters
			Private mCounters As New List(Of PSCounter)

			Public Sub Add(ByVal CounterName As String, ByVal CounterValue As Double)
				mCounters.Add(New PSCounter(CounterName, CounterValue))
			End Sub

			Friend ReadOnly Property Items() As List(Of PSCounter)
				Get
					Return mCounters
				End Get
			End Property
		End Class
	End Class
End Namespace