Imports System.Collections.Generic
Imports System.Management.Automation

Namespace ScriptEngines
	Public Class ScriptEngine
		Dim mEngine As String
		Dim mEngineID As Integer
		Dim mDefaultTemplate As String

		Public Sub New(ByVal EngineID As Integer)
			Select Case EngineID
				Case 0
					'PowerShell
					mEngineID = EngineID
					mEngine = "PowerShell"
					mDefaultTemplate = My.Resources.PowerShellTemplate
				Case 1
					'VBScript
					mEngineID = EngineID
					mEngine = "VBScript"
					mDefaultTemplate = My.Resources.VBScriptTemplate
				Case Else
					'Not implemented...
					Throw New System.Exception("Specified Script Engine is not implemented.")
			End Select
		End Sub
		Public ReadOnly Property EngineID() As Integer
			Get
				Return mEngineID
			End Get
		End Property

		Public ReadOnly Property Engine() As String
			Get
				Return mEngine
			End Get
		End Property

		Public ReadOnly Property DefaultTemplate() As String
			Get
				Return mDefaultTemplate
			End Get
		End Property

		Public Function RunScript(ByVal Script As String, ByVal MonitorStatusID As Integer, ByVal Counters As PolyMon.Status.CounterList) As String
			Dim ReturnMsg As String = Nothing
			Dim MonitorStatus As New PolyMon.Status.Status(MonitorStatusID)

			Select Case mEngineID
				Case 0 'PowerShell
					Try
						Dim myRunspace As Runspaces.Runspace = Nothing
						myRunspace = Runspaces.RunspaceFactory.CreateRunspace()
						myRunspace.Open()

						Dim myPipeline As Runspaces.Pipeline = myRunspace.CreatePipeline(Script)

						myRunspace.SessionStateProxy.SetVariable("Status", MonitorStatus)
						myRunspace.SessionStateProxy.SetVariable("Counters", Counters)
						myPipeline.Invoke()
					Catch ex As Exception
						ReturnMsg = ex.ToString()
					End Try
				Case 1 'VBScript
					Try
						Dim VBScriptEngine As New MSScriptControl.ScriptControl
						With VBScriptEngine
							.Language = "VBScript"
							.AddObject("Status", MonitorStatus, True)
							.AddObject("Counters", Counters, True)
							.ExecuteStatement(Script)
						End With
					Catch ex As Exception
						ReturnMsg = ex.ToString()
					End Try
			End Select

			Return ReturnMsg

		End Function
	End Class

	Public Class ScriptEngines
		Dim mEngines As New List(Of ScriptEngine)

		Public Sub New()
			mEngines.Add(New ScriptEngine(0))
			mEngines.Add(New ScriptEngine(1))
		End Sub

		Public ReadOnly Property Engines() As System.Collections.ObjectModel.ReadOnlyCollection(Of ScriptEngine)
			Get
				Return mEngines.AsReadOnly
			End Get
		End Property

		Public ReadOnly Property ScriptEngine(ByVal EngineID As Integer) As ScriptEngine
			Get
				Dim ReturnEngine As ScriptEngine = Nothing
				For Each myEngine As ScriptEngine In mEngines
					If myEngine.EngineID = EngineID Then
						ReturnEngine = myEngine
					End If
				Next
				Return ReturnEngine
			End Get
		End Property
	End Class
End Namespace
