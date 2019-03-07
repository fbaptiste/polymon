Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports PolyMon.Monitors.MonitorMetadata
Imports PolyMon.Status

Namespace Monitors
    Public MustInherit Class MonitorExecutor

#Region "Private Class Attributes"
        'SQL Connection
        Private mSQLConn As String

        Private mManualOverride As Boolean = False
        Private mForceLog As Boolean = False

		'Monitor metadata
		Private mMetadata As PolyMon.Monitors.MonitorMetadata

		Private mMonitorID As Integer
		Private mTriggerCount As Integer
		Private mCounters As New CounterList
		Private mStatusMessage As String
		Private mMonitorStatus As MonitorStatus

		'Event Log
        Private myEventLog As EventLog

#End Region

		''#Region "Counter Classes"
		''        Public Class Counter
		''            Private mCounterName As String
		''            Private mCounterValue As Double

		''            Public Sub New(ByVal CounterName As String, ByVal CounterValue As Double)
		''                mCounterName = Left(CounterName.Trim(), 255)
		''                mCounterValue = CounterValue
		''            End Sub
		''            Public ReadOnly Property CounterName() As String
		''                Get
		''                    Return mCounterName
		''                End Get
		''            End Property
		''            Public ReadOnly Property CounterValue() As Double
		''                Get
		''                    Return mCounterValue
		''                End Get
		''            End Property
		''        End Class
		''        Public Class CounterList
		''            Inherits CollectionBase

		''            Default Public Property Item(ByVal index As Integer) As Counter
		''                Get
		''                    Return CType(InnerList.Item(index), Counter)
		''                End Get
		''                Set(ByVal Value As Counter)
		''                    InnerList.Item(index) = Value
		''                End Set
		''            End Property
		''            Public Sub Add(ByVal value As Counter)
		''                InnerList.Add(value)
		''            End Sub
		''        End Class
		''#End Region

#Region "Enumerations"
        Public Enum MonitorStatus As Integer
            Unknown = -1
            OK = 1
            Warn = 2
            Fail = 3
        End Enum
#End Region

#Region "Public Interface"
        Public Property ManualOverride() As Boolean
            Get
                Return mManualOverride
            End Get
            Set(ByVal Value As Boolean)
                mManualOverride = Value
            End Set
        End Property
        Public Property ForceLog() As Boolean
            Get
                Return mForceLog
            End Get
            Set(ByVal value As Boolean)
                mForceLog = value
            End Set
        End Property

        Public ReadOnly Property MonitorID() As Integer
            Get
				Return mMetadata.MonitorID
            End Get
        End Property
        Public Property Enabled() As Boolean
            Get
				Return mMetadata.Enabled
            End Get
            Set(ByVal Value As Boolean)
				mMetadata.Enabled = Value
            End Set
        End Property
        Public ReadOnly Property MonitorName() As String
            Get
				Return mMetadata.MonitorName
            End Get
        End Property
        Public ReadOnly Property MonitorXML() As XmlDocument
            Get
				Return mMetadata.MonitorXML
            End Get
        End Property

		Public ReadOnly Property OfflineTime1() As PolyMon.Monitors.MonitorMetadata.OfflineTime
			Get
				Return mMetadata.OfflineTime1
			End Get
		End Property
		Public ReadOnly Property OfflineTime2() As PolyMon.Monitors.MonitorMetadata.OfflineTime
			Get
				Return mMetadata.OfflineTime2
			End Get
		End Property
        Public ReadOnly Property SubjectTemplate() As String
            Get
				Return mMetadata.MessageSubjectTemplate
            End Get
        End Property
        Public ReadOnly Property BodyTemplate() As String
            Get
				Return mMetadata.MessageBodyTemplate
            End Get
        End Property
        Public ReadOnly Property TriggerMod() As Integer
            Get
				Return mMetadata.TriggerMod
            End Get
        End Property

        Public ReadOnly Property TriggerCount() As Integer
            Get
				Return mTriggerCount
            End Get
        End Property
        Public ReadOnly Property MonitorCounters() As CounterList
            Get
                Return mCounters
            End Get
        End Property
        Public ReadOnly Property Status() As MonitorStatus
            Get
                Return mMonitorStatus
            End Get
        End Property
        Public ReadOnly Property StatusMessage() As String
            Get
                Return mStatusMessage
            End Get
        End Property
        Public ReadOnly Property MonitorTypeID() As Integer
            Get
				Return mMetadata.MonitorTypeID
            End Get
        End Property
        Public ReadOnly Property MonitorType() As String
            Get
				Return mMetadata.MonitorType
            End Get
        End Property
        Public ReadOnly Property MonitorAssembly() As String
            Get
				Return mMetadata.MonitorAssembly
            End Get
        End Property
        Public ReadOnly Property EditorAssembly() As String
            Get
				Return mMetadata.EditorAssembly
            End Get
        End Property

        Public Sub New(ByVal MonitorID As Integer)
            mManualOverride = False
            mMonitorID = MonitorID
            mTriggerCount = 0

            'Read connection string from app config
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

            'Read Monitor metadata from database
			mMetadata = New PolyMon.Monitors.MonitorMetadata(MonitorID)

            'Create Event Log - used for debugging
            If Not EventLog.SourceExists("MonitorExecutor") Then
                EventLog.CreateEventSource("MonitorExecutor", "Application")
            End If
            myEventLog = New EventLog
            myEventLog.Source = "MonitorExecutor"
        End Sub

        Public Sub RunMonitor()
            mMonitorStatus = MonitorStatus.Unknown
            mCounters.Clear()
            mStatusMessage = Nothing

            RefreshMetadata() 'In case monitor metadata has changed in database

            If mManualOverride Then
                'Manual override specified, just run monitor immediately
                'and without saving anything back to the database unless mForceLog is set to true
                Try
                    mMonitorStatus = MonitorTest(mStatusMessage, mCounters)
                Catch ex As Exception
                    mMonitorStatus = MonitorStatus.Fail
                    mStatusMessage = "Monitor Run Exception" & vbCrLf & ex.Message
                    mCounters.Clear()
                Finally
                    If mForceLog Then
                        SaveMonitorEvent()
					End If
					'Post-event Action Script
					If mMetadata.AfterEventIsEnabled Then
						Dim EngineID As Integer = mMetadata.AfterEventScriptEngine.EngineID
						Dim Script As String = mMetadata.AfterEventScript
						Dim ScriptResult As String = Nothing
						Try
							Dim ScriptEngine As New PolyMon.ScriptEngines.ScriptEngine(EngineID)
							ScriptResult = ScriptEngine.RunScript(Script, mMonitorStatus, mCounters)
						Catch ex As Exception
							ScriptResult = ex.ToString()
						End Try

						If ScriptResult IsNot Nothing Then
							'Error running Action Script - set to Warn state and log to database
							mMonitorStatus = MonitorStatus.Warn
							mStatusMessage = "Monitor Action Exception" & vbCrLf & ScriptResult
							mCounters.Clear()
							If mForceLog Then SaveMonitorEvent()
						End If
					End If
                End Try
            Else
                'Regular Processing...
				If Not (mMetadata.Enabled) Then
					'Monitor is disabled, do not run...
				Else
					'Make sure Monitor is not OffLine
					If Not (mMetadata.OfflineTime1.IsOfflineTime) AndAlso Not (mMetadata.OfflineTime2.IsOfflineTime) Then
						'See if we have reached the Trigger Mod
						'myEventLog.WriteEntry("Monitor " & Me.MonitorName & "Trigger Count: " & mTriggerCount & " TriggerMod: " & mTriggerMod)
						mTriggerCount += 1
						If mTriggerCount = 0 OrElse mTriggerCount >= mMetadata.TriggerMod Then
							'Run Monitor
							If mTriggerCount >= mMetadata.TriggerMod Then mTriggerCount = 0
							Try
								'Run Monitor Test
								mMonitorStatus = MonitorTest(mStatusMessage, mCounters)
							Catch ex As Exception
								mMonitorStatus = MonitorStatus.Fail
								mStatusMessage = "Monitor Run Exception" & vbCrLf & ex.Message
								mCounters.Clear()
							Finally
								'And persist results to database
								SaveMonitorEvent()

								'Post-event Action Script
								If mMetadata.AfterEventIsEnabled Then
									Dim EngineID As Integer = mMetadata.AfterEventScriptEngine.EngineID
									Dim Script As String = mMetadata.AfterEventScript
									Dim ScriptResult As String = Nothing
									Try
										Dim ScriptEngine As New PolyMon.ScriptEngines.ScriptEngine(EngineID)
										ScriptResult = ScriptEngine.RunScript(Script, mMonitorStatus, mCounters)
									Catch ex As Exception
										ScriptResult = ex.ToString()
									End Try

									If ScriptResult IsNot Nothing Then
										'Error running Action Script - set to Warn state and log to database
										mMonitorStatus = MonitorStatus.Warn
										mStatusMessage = "Monitor Action Exception" & vbCrLf & ScriptResult
										mCounters.Clear()
										SaveMonitorEvent()
									End If


								End If

							End Try
						End If 'Trigger Mod Check
					End If 'Offline Check
				End If 'Enabled Check
            End If 'Manual Override
        End Sub
#End Region

#Region "Must Override Methods"
        Protected MustOverride Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As MonitorStatus
#End Region

#Region "Private Methods"


		'''Private Sub ReadMonitorMetadata(ByVal MonitorID As Integer)
		'''	Dim SQLConn As New SqlConnection(mSQLConn)
		'''	Dim sp As String = "polymon_sel_MonitorMetadata"

		'''	Dim prmMonitorID As New SqlParameter
		'''	With prmMonitorID
		'''		.ParameterName = "@MonitorID"
		'''		.SqlDbType = SqlDbType.Int
		'''		.Direction = ParameterDirection.Input
		'''		.Value = MonitorID
		'''	End With

		'''	Dim sqlCmd As New SqlCommand
		'''	sqlCmd.Connection = SQLConn
		'''	sqlCmd.CommandType = CommandType.StoredProcedure
		'''	sqlCmd.CommandText = sp
		'''	sqlCmd.Parameters.Add(prmMonitorID)

		'''	Try
		'''		SQLConn.Open()
		'''		Dim drMonitor As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
		'''		With drMonitor
		'''			.Read()
		'''			mIsEnabled = CBool(.Item("IsEnabled"))
		'''			mMonitorName = CStr(.Item("Name"))

		'''			mMonitorXML = New XmlDocument
		'''			mMonitorXML.LoadXml(CStr((.Item("MonitorXML"))))
		'''			mOfflineTime1 = New OfflineTime(CStr(.Item("OfflineTime1Start")), CStr(.Item("OfflineTime1End")))
		'''			mOfflineTime2 = New OfflineTime(CStr(.Item("OfflineTime2Start")), CStr(.Item("OfflineTime2End")))
		'''			If IsDBNull(.Item("MessageSubjectTemplate")) OrElse .Item("MessageSubjectTemplate") Is Nothing Then
		'''				mSubjectTemplate = Nothing
		'''			Else
		'''				mSubjectTemplate = CStr(.Item("MessageSubjectTemplate"))
		'''			End If
		'''			If IsDBNull(.Item("MessageBodyTemplate")) OrElse .Item("MessageBodyTemplate") Is Nothing Then
		'''				mBodyTemplate = Nothing
		'''			Else
		'''				mBodyTemplate = CStr(.Item("MessageBodyTemplate"))
		'''			End If
		'''			mTriggerMod = CInt(.Item("TriggerMod"))

		'''			mMonitorTypeID = CInt(.Item("MonitorTypeID"))
		'''			mMonitorType = CStr(.Item("MonitorTypeName"))
		'''			mMonitorAssembly = CStr(.Item("MonitorAssembly"))
		'''			mEditorAssembly = CStr(.Item("EditorAssembly"))

		'''			mMetadataCurrentDT = CDate(.Item("MetadataCurrentDT"))
		'''		End With
		'''	Catch ex As Exception
		'''		Throw New System.Exception(ex.Message, ex)
		'''	Finally
		'''		If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
		'''		SQLConn.Dispose()
		'''	End Try
		'''End Sub

		Private Sub SaveMonitorEvent()
			Dim EventID As Integer
			Dim SQLConn As New SqlConnection(mSQLConn)
			Dim sp As String = "polymon_ins_MonitorEvent"

			Dim prmMonitorID As New SqlParameter
			With prmMonitorID
				.ParameterName = "@MonitorID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Input
				.Value = mMonitorID
			End With
			Dim prmStatusID As New SqlParameter
			With prmStatusID
				.ParameterName = "@StatusID"
				.SqlDbType = SqlDbType.TinyInt
				.Direction = ParameterDirection.Input
				.Value = mMonitorStatus
			End With
			Dim prmStatusMessage As New SqlParameter
			With prmStatusMessage
				.ParameterName = "@StatusMessage"
				.SqlDbType = SqlDbType.NVarChar
				.Size = 1000
				.Direction = ParameterDirection.Input
				.Value = mStatusMessage
			End With
			Dim prmEventID As New SqlParameter
			With prmEventID
				.ParameterName = "@EventID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Output
			End With

			Dim sqlCmd As New SqlCommand
			With sqlCmd
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = sp
				.Parameters.Add(prmMonitorID)
				.Parameters.Add(prmStatusID)
				.Parameters.Add(prmStatusMessage)
				.Parameters.Add(prmEventID)
			End With

			Try
				SQLConn.Open()
				sqlCmd.ExecuteNonQuery()
				EventID = CInt(prmEventID.Value)
				SQLConn.Close()
				If mCounters.Count > 0 Then
					SaveMonitorCounters(EventID)
				End If
			Catch ex As Exception
				Throw New System.Exception(ex.Message, ex)
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End Try
		End Sub
		Private Sub SaveMonitorCounters(ByVal EventID As Integer)
			If mCounters.Count = 0 Then Exit Sub 'short-circuit out if this was called with no counters 

			Dim SQLConn As New SqlConnection(mSQLConn)
			Dim sp As String = "polymon_ins_MonitorEventCounter"

			Dim prmEventID As New SqlParameter
			With prmEventID
				.ParameterName = "@EventID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Input
				.Value = EventID
			End With
			Dim prmMonitorID As New SqlParameter
			With prmMonitorID
				.ParameterName = "@MonitorID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Input
				.Value = mMonitorID
			End With

			Dim prmCounterName As New SqlParameter
			With prmCounterName
				.ParameterName = "@CounterName"
				.SqlDbType = SqlDbType.VarChar
				.Size = 255
				.Direction = ParameterDirection.Input
			End With
			Dim prmCounterValue As New SqlParameter
			With prmCounterValue
				.ParameterName = "@CounterValue"
				.SqlDbType = SqlDbType.Decimal
				.Direction = ParameterDirection.Input
			End With

			Dim sqlCmd As New SqlCommand
			With sqlCmd
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = sp
				.Parameters.Add(prmEventID)
				.Parameters.Add(prmMonitorID)
				.Parameters.Add(prmCounterName)
				.Parameters.Add(prmCounterValue)
			End With

			Dim Counter As Counter
			Try
				SQLConn.Open()
				For Each Counter In mCounters
					Try
						prmCounterName.Value = Counter.CounterName
						prmCounterValue.Value = Counter.CounterValue
						sqlCmd.ExecuteNonQuery()
					Catch ex As Exception
						'Just ignore this error and try to save other parameters if any
					End Try
				Next
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End Try
		End Sub

		Private Sub RefreshMetadata()
			'Determines whether Monitor metadata is still current 
			'and if need be, reloads metadata
			Dim SQLConn As New SqlConnection(mSQLConn)
			Dim sp As String = "polymon_sel_MonitorMetadataCurrentDT"

			Dim prmMonitorID As New SqlParameter
			With prmMonitorID
				.ParameterName = "@MonitorID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Input
				.Value = mMonitorID
			End With

			Dim sqlCmd As New SqlCommand
			sqlCmd.Connection = SQLConn
			sqlCmd.CommandType = CommandType.StoredProcedure
			sqlCmd.CommandText = sp
			sqlCmd.Parameters.Add(prmMonitorID)

			Try
				SQLConn.Open()
				Dim drMonitor As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim MonitorExists As Boolean = False
				Dim NewDT As Date
				With drMonitor
					If Not (.HasRows) Then
						'Monitor appears to have been deleted from database
						mMetadata.Enabled = False
					Else
						'Check most recent DT
						drMonitor.Read()
						NewDT = CDate(drMonitor.Item("MetadataCurrentDT"))
						If NewDT > mMetadata.CurrentDT Then
							mMetadata = New PolyMon.Monitors.MonitorMetadata(MonitorID)
						End If
					End If
				End With
			Catch ex As Exception
				Throw New System.Exception(ex.Message, ex)
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End Try
		End Sub
#End Region

    End Class
End Namespace