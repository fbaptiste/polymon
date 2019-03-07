Imports System.ServiceProcess
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text

Namespace Executive
    Public Class PolyMonExecutive
        Inherits System.ServiceProcess.ServiceBase

#Region " Component Designer generated code "

        Public Sub New()
            MyBase.New()

            ' This call is required by the Component Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call

        End Sub

        'UserService overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        ' The main entry point for the process
        <MTAThread()> _
        Shared Sub Main()
            Dim ServicesToRun() As System.ServiceProcess.ServiceBase

            ' More than one NT Service may run within the same process. To add
            ' another service to this process, change the following line to
            ' create a second service object. For example,
            '
            '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
            '
            ServicesToRun = New System.ServiceProcess.ServiceBase() {New PolyMon.Executive.PolyMonExecutive}

            System.ServiceProcess.ServiceBase.Run(ServicesToRun)
        End Sub

        'Required by the Component Designer
        Private components As System.ComponentModel.IContainer

        ' NOTE: The following procedure is required by the Component Designer
        ' It can be modified using the Component Designer.  
        ' Do not modify it using the code editor.
		Friend WithEvents ServiceController1 As System.ServiceProcess.ServiceController
		Friend WithEvents timerSQLConnect As System.Timers.Timer
        Friend WithEvents timerMonitor As System.Timers.Timer
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.ServiceController1 = New System.ServiceProcess.ServiceController
			Me.timerMonitor = New System.Timers.Timer
			Me.timerSQLConnect = New System.Timers.Timer
			CType(Me.timerMonitor, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.timerSQLConnect, System.ComponentModel.ISupportInitialize).BeginInit()
			'
			'timerMonitor
			'
			'
			'timerSQLConnect
			'
			'
			'PolyMonExecutive
			'
			Me.ServiceName = "PolyMonExecutive"
			CType(Me.timerMonitor, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.timerSQLConnect, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub

#End Region


#Region "Private Attributes"
		Private Const mDBVersion As Single = 1.1

		Private mEventLog As String = "PolyMon"

		Private mIsMonitorRunning As Boolean = False

		Private mMonitorList As New Dictionary(Of Integer, PolyMon.Monitors.MonitorExecutor)

		Private mSQLConn As String
		Private mMainTimerInterval As Integer = 60 'seconds
		Private mExecutiveID As Integer = 1

		Private Enum SeverityLevel As Integer
			OK = 1
			Recoverable = 2
			Critical = 3
		End Enum

		Private mSQLTimerInterval As Integer = 30 'seconds
#End Region


#Region "Service Start/Stop"
		Protected Overrides Sub OnStart(ByVal args() As String)

			'First make sure all timers have been stopped/disabled
			Me.timerSQLConnect.Enabled = False
			Me.timerMonitor.Enabled = False
			Me.timerSQLConnect.Stop()
			Me.timerMonitor.Stop()

			Me.AutoLog = False

			Try
				If Not EventLog.SourceExists(mEventLog) Then
					EventLog.CreateEventSource(mEventLog, mEventLog)
				End If
			Catch
				'Do nothing - event logging is not crucial...
			End Try

			Try
				EventLog.WriteEntry(mEventLog, "Service starting...", EventLogEntryType.Information)
			Catch
				'Do Nothing
			End Try

			Dim Result As SeverityLevel = RetrieveConfigSettings()
			If Result <> SeverityLevel.OK Then
				'Cannot start service
				Me.ServiceController1.Stop()
			Else
				'Now attempt SQL Connection
				Result = TestSQLConnection()
				If Result <> SeverityLevel.OK Then
					'Cannot connect - go into deferred mode using timer to keep trying connecting to SQL
					Me.timerSQLConnect.Interval = mSQLTimerInterval * 1000 'convert to milliseconds
					Me.timerSQLConnect.Enabled = True
					Me.timerSQLConnect.Start()
				Else
					'Connection OK, proceed with initialization
					Try
						EventLog.WriteEntry(mEventLog, "PolyMon Executive Initializing...", EventLogEntryType.Information)
					Catch
						'Do Nothing
					End Try
					'Initialize

					Result = RetrieveSQLSettings()
					If Result <> SeverityLevel.OK Then
						'Stop service...
						Me.ServiceController1.Stop()
						Exit Sub
					End If

					'Initialization completed OK
					Try
						EventLog.WriteEntry(mEventLog, "PolyMon Executive Initialization Complete.", EventLogEntryType.Information)
					Catch
						'Do nothing
					End Try

					'Start Monitoring timer
					Me.timerMonitor.Interval = mMainTimerInterval
					Me.timerMonitor.Enabled = True
					Me.timerMonitor.Start()
				End If

				Try
					EventLog.WriteEntry(mEventLog, "Service Started.", EventLogEntryType.Information)
				Catch
					'Do nothing
				End Try
			End If
		End Sub
		Protected Overrides Sub OnStop()
			' Add code here to perform any tear-down necessary to stop your service.
			timerMonitor.Dispose()
			timerSQLConnect.Dispose()

			Try
				EventLog.WriteEntry(mEventLog, "Service Stopped.", EventLogEntryType.Information)
			Catch
				'Do nothing
			End Try
		End Sub
#End Region

#Region "Configuration"
		Private Function RetrieveConfigSettings() As SeverityLevel
			'First retrieve SQL connection string
			Try
				mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
				If mSQLConn = Nothing Then Throw New Exception("SQL Connection string not specified in configuration file.")
			Catch ex As Exception
				Try
					EventLog.WriteEntry(mEventLog, "SQLConn: " & ex.Message, EventLogEntryType.Error)
				Catch
					'Do nothing
				End Try
				Return SeverityLevel.Critical
			End Try

			'Executive ID
			Try
				mExecutiveID = CInt(System.Configuration.ConfigurationManager.AppSettings("ExecutiveID"))
				If mExecutiveID = Nothing Then Throw New Exception("ExecutiveID not specified in configuration file.")
			Catch ex As Exception
				Try
					EventLog.WriteEntry(mEventLog, "ExecutiveID: " & ex.Message, EventLogEntryType.Error)
				Catch
					'Do nothing
				End Try
				Return SeverityLevel.Critical
			End Try

			'Next check to make sure we are connecting to a compatible databse version
			Dim Sys As New PolyMon.General.SysSettings
			If Sys.DBVersion <> mDBVersion Then
				Try
					EventLog.WriteEntry(mEventLog, "Incompatible database version. PolyMon Executive will be halted.", EventLogEntryType.Error)
				Catch
					'Do nothing
				End Try
				Return SeverityLevel.Critical
			End If

			'Reached here, so OK!
			Return SeverityLevel.OK
		End Function
		Private Function RetrieveSQLSettings() As SeverityLevel
			Dim HasErrors As Boolean = False
			Dim ErrMsg As New StringBuilder
			Dim IsEnabled As Boolean = True
			Dim SQLConn As SqlConnection = Nothing


			SQLConn = New SqlConnection(mSQLConn)
			Dim SQLCmd As New SqlCommand
			With SQLCmd
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = "polymon_sel_SysSettings"
			End With

			Dim dr As SqlDataReader = Nothing
			Try
				SQLConn.Open()
				dr = SQLCmd.ExecuteReader(CommandBehavior.SingleRow)
				If Not (dr.HasRows()) Then
					Throw New Exception("Service cannot start. No settings were found in PolyMon database. Please configure PolyMon through PolyMon Manager before running the service.")
				End If
			Catch ex As Exception
				Try
					EventLog.WriteEntry(mEventLog, ex.Message, EventLogEntryType.Error)
				Catch
					'Do nothing
				End Try
				If SQLConn IsNot Nothing Then
					If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
					SQLConn.Dispose()
				End If
				Return SeverityLevel.Critical

			End Try


			Try
				While dr.Read()
					IsEnabled = CBool(dr.Item("IsEnabled"))
					If Not (IsEnabled) Then
						Try
							EventLog.WriteEntry(mEventLog, "Service cannot start. PolyMon has been disabled. Please enable PolyMon through PolyMon Manager's General Settings.", EventLogEntryType.Error)
						Catch
							'Do nothing 
						End Try
						SQLConn.Close()
						SQLConn.Dispose()
						Return SeverityLevel.Critical
					End If


					Dim StrMainTimerInterval As String = CStr(dr.Item("MainTimerInterval"))
					If Not IsNumeric(StrMainTimerInterval) OrElse CInt(StrMainTimerInterval) <= 0 Then
						Try
							EventLog.WriteEntry(mEventLog, "Service cannot start. Main Timer Interval value is invalid.", EventLogEntryType.Error)
						Catch
							'Do nothing 
						End Try
						SQLConn.Close()
						SQLConn.Dispose()
						Return SeverityLevel.Critical
					Else
						mMainTimerInterval = CInt(StrMainTimerInterval) * 1000 'Convert seconds to milliseconds
					End If
				End While
			Catch ex As Exception
				Try
					EventLog.WriteEntry(mEventLog, "Service cannot start." & ex.Message, EventLogEntryType.Error)
				Catch
					'Do nothing
				End Try
				Return SeverityLevel.Critical
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End Try

			'Reached here, so OK!
			Return SeverityLevel.OK
		End Function
#End Region

#Region "Monitoring"
		Private Function RefreshMonitorList() As SeverityLevel
			'Creates/Updates Monitor List
			Dim HasErrors As Boolean = False
			Dim ErrMsg As New StringBuilder

			RefreshMonitorList = SeverityLevel.OK

			Dim MonitorID As Integer = -1
			Dim MonitorName As String = Nothing

			Dim MonitorAssembly As String
			Dim myMonitor As PolyMon.Monitors.MonitorExecutor = Nothing
			Dim asm As Reflection.Assembly
			Dim MonitorType As Type
			Dim ty As Type
			Dim types() As Type
			Dim ci As Reflection.ConstructorInfo
			Dim params() As Object
			Dim obj As Object
			Dim AppPath As String = System.AppDomain.CurrentDomain.BaseDirectory()

			Dim SQLConn As New SqlConnection(mSQLConn)

			Dim prmExecutiveID As New SqlParameter("@ExecutiveID", SqlDbType.Int)
			With prmExecutiveID
				.Direction = ParameterDirection.Input
				.Value = mExecutiveID
			End With

			Dim SQLCmd As New SqlCommand
			With SQLCmd
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = "polymon_sel_MonitorList"
				.Parameters.Add(prmExecutiveID)
			End With

			

			Dim dr As SqlDataReader = Nothing
			Try
				SQLConn.Open()
				dr = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection)
			Catch ex As Exception
				HasErrors = True
				RefreshMonitorList = SeverityLevel.Recoverable
				ErrMsg.AppendFormat("No monitoring will take place at this time. Error occurred retrieving Monitor Metadata from database: {0}", ex.Message)
			End Try

			If Not (HasErrors) Then
				While dr.Read()
					Try
						'Read each monitor and store in Monitor collection
						MonitorID = CInt(dr.Item("MonitorID"))
						MonitorName = CStr(dr.Item("Name"))

						If Not (mMonitorList.ContainsKey(MonitorID)) Then
							'Monitor is not in the list, add it in

							'First determine the Monitor's assembly
							MonitorAssembly = CStr(dr.Item("MonitorAssembly"))
							MonitorType = Nothing
							asm = Reflection.Assembly.LoadFrom(AppPath & MonitorAssembly)
							For Each ty In asm.GetExportedTypes
								If ty.BaseType.FullName = GetType(PolyMon.Monitors.MonitorExecutor).FullName Then
									MonitorType = ty
									Exit For
								End If
							Next
							If Not (MonitorType Is Nothing) Then
								types = New Type() {GetType(System.Int32)}
								ci = MonitorType.GetConstructor(types)
								params = New Object() {MonitorID}
								obj = ci.Invoke(params)
								myMonitor = DirectCast(obj, PolyMon.Monitors.MonitorExecutor)
								myMonitor.ManualOverride = False
								mMonitorList.Add(MonitorID, myMonitor)
								Try
									EventLog.WriteEntry(mEventLog, "Adding " & myMonitor.MonitorName, EventLogEntryType.Information)
								Catch
									'Do nothing 
								End Try
							Else
								'Monitor Assembly was not found
								HasErrors = True
								ErrMsg.AppendFormat("Could not locate the monitoring assembly [{0}] for monitor [{1} = {2}]. Monitoring for this monitor is suspended.", MonitorAssembly, MonitorID, MonitorName)
							End If
						End If
					Catch ex As Exception
						HasErrors = True
						RefreshMonitorList = SeverityLevel.Recoverable
						ErrMsg.AppendFormat("Error initializing monitor [{0} = {1}]: {2}]", MonitorID, MonitorName, ex.Message)
					End Try
				End While
			End If

			If HasErrors Then
				Try
					EventLog.WriteEntry(mEventLog, ErrMsg.ToString(), EventLogEntryType.Warning)
				Catch
					'Do nothing
				End Try
			End If

			'Cleanup
			If SQLConn IsNot Nothing Then
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End If
		End Function
		Private Sub RunMonitors()
			RefreshMonitorList()
			Dim myMonitor As PolyMon.Monitors.MonitorExecutor
			For Each myMonitor In mMonitorList.Values
				Try
					myMonitor.RunMonitor()
				Catch ex As Exception
					Try
						EventLog.WriteEntry(mEventLog, "Error occurred processing Monitor: " & myMonitor.MonitorName & " (ID=" & myMonitor.MonitorID & ")" & vbCrLf & ex.Message, EventLogEntryType.Warning)
					Catch
						'Do nothing 
					End Try
				End Try
			Next
		End Sub

		Private Sub timerMonitor_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timerMonitor.Elapsed
			If mIsMonitorRunning Then
				'Monitor already running it's tests... Simply ignore this event
			Else
				mIsMonitorRunning = True
				RunMonitors()
				SendNotifications()
				mIsMonitorRunning = False
			End If
		End Sub
#End Region

#Region "Startup/SQL Connection"
		Private Sub timerSQLConnect_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timerSQLConnect.Elapsed
			'Attempt connection to SQL Server
			timerSQLConnect.Stop()

			Dim Result As SeverityLevel

			Result = TestSQLConnection()
			If Result = SeverityLevel.OK Then
				'Connected OK - switch to monitoring
				Try
					EventLog.WriteEntry(mEventLog, "PolyMonExecutive Initializing...", EventLogEntryType.Information)
				Catch
					'Do nothing
				End Try

				'Initialize
				Result = RetrieveSQLSettings()
				If Result = SeverityLevel.Critical Then
					'Stop service...
					Me.ServiceController1.Stop()
					Exit Sub
				End If

				'Initialization completed OK
				Try
					EventLog.WriteEntry(mEventLog, "PolyMon Executive Initialization Complete.", EventLogEntryType.Information)
				Catch
					'Do nothing
				End Try

				'Start Monitoring timer
				Me.timerMonitor.Interval = mMainTimerInterval
				Me.timerMonitor.Enabled = True
				Me.timerMonitor.Start()
			Else
				'Could not connect - keep trying
				timerSQLConnect.Start()
			End If
		End Sub

		Private Function TestSQLConnection() As SeverityLevel
			Dim SQLConn As SqlConnection = Nothing
			Try
				SQLConn = New SqlConnection(mSQLConn)
				SQLConn.Open()
				Try
					EventLog.WriteEntry(mEventLog, "SQL connection established OK.", EventLogEntryType.Information)
				Catch
					'Do nothing 
				End Try
				Return SeverityLevel.OK
			Catch ex As Exception
				Try
					EventLog.WriteEntry(mEventLog, "SQL Connection could not be established. Retrying in " & Me.mSQLTimerInterval & " seconds.", EventLogEntryType.Warning)
				Catch
					'Do nothing
				End Try
				Return SeverityLevel.Recoverable
			Finally
				If SQLConn.State <> ConnectionState.Closed Then
					SQLConn.Close()
				End If
				SQLConn.Dispose()
			End Try
		End Function
#End Region

#Region "Notifications"
		Private Sub SendNotifications()
			Dim Mailer As New PolyMon.Notifier.PolyMonMailer
			'Send any pending non-queued Alerts
			Try
				Mailer.ProcessPendingEmailNotifications(250)
			Catch ex As Exception
				EventLog.WriteEntry(mEventLog, "Error Sending Pending Notifications " & vbCrLf & ex.Message, EventLogEntryType.Error)
			End Try

			'Send any pending Queued Alerts
			Try
				Mailer.ProcessQueuedNotifications(250)
			Catch ex As Exception
				EventLog.WriteEntry(mEventLog, "Error Sending Queued Notifications " & vbCrLf & ex.Message, EventLogEntryType.Error)
			End Try

			'Send any pending Recap emails
			Try
				Mailer.ProcessPendingRecapNotifications()
			Catch ex As Exception
				EventLog.WriteEntry(mEventLog, "Error Sending Recap Notifications " & vbCrLf & ex.Message, EventLogEntryType.Error)
			End Try

			'Send any pending Summary Notifications (Heartbeat)
			Try
				Mailer.ProcessPendingSummaryNotifications()
			Catch ex As Exception
				EventLog.WriteEntry(mEventLog, "Error Sending Heartbeat Notifications " & vbCrLf & ex.Message, EventLogEntryType.Error)
			End Try
		End Sub
#End Region


	End Class
End Namespace