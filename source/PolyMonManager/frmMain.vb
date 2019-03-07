Imports System.ServiceProcess
Imports System.Data.SqlClient

Public Class frmMain

#Region "Private Attributes"
    Private mfrmDashBoard As frmDashboard = Nothing
    Private mfrmCurrentStatus As frmCurrentStatus = Nothing
    Private mfrmFailuresWarnings As frmFailuresWarnings = Nothing
    Private mfrmEventHistory As frmEventHistory = Nothing
    Private mfrmUptimeAnalysis As frmUptimeAnalysis = Nothing
    Private mfrmGeneralSettings As frmGeneralSettings = Nothing
    Private mfrmMonitorDefs As frmMonitorDefs = Nothing
    Private mfrmMonitorTypes As frmMonitorTypes = Nothing
    Private mfrmOperators As frmOperators = Nothing
    Private mfrmPolymonExecutive As frmPolyMonExecutive = Nothing

    Private mAllowClose As Boolean = False
	Private mOpeningFromTray As Boolean = False

	Private Const mDBVersion As Single = 1.1
	Private mForceClose As Boolean = False
#End Region

#Region "Event Handlers"
	Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If mForceClose Then
			Me.mAllowClose = True
			Me.Close()
		End If
		If Me.WindowState = FormWindowState.Minimized Then Me.Hide()
	End Sub
    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then Me.Hide()
    End Sub
    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (e.CloseReason = CloseReason.WindowsShutDown Or e.CloseReason = CloseReason.TaskManagerClosing) Then
            If mAllowClose Then
                'Just continue closing
            Else
                'Just minimize to tray
                mAllowClose = False
                e.Cancel = True
                Me.Hide()
            End If
        End If
    End Sub

#Region "File Menu"
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        mAllowClose = True
        Me.Close()
    End Sub
#End Region

#Region "Status Menu/Toolbar"
    Private Sub LoadForm_Dashboard(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DashboardToolStripMenuItem.Click, tsbDashboard.Click, tslblOK.Click
        Me.Cursor = Cursors.WaitCursor
        LoadChildForm("frmDashboard")
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub CurrentStatusAllMonitorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrentStatusAllMonitorsToolStripMenuItem.Click, tsbAllStatus.Click
        Me.Cursor = Cursors.WaitCursor
        LoadChildForm("frmCurrentStatus")
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadForm_FailuresWarnings(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlertsToolStripMenuItem.Click, tsbAlerts.Click, tslblAlerts.Click
        Me.Cursor = Cursors.WaitCursor
        LoadChildForm("frmFailuresWarnings")
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadForm_EventHistory(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EventHistoryToolStripMenuItem.Click, tsbEventHistory.Click
        Me.Cursor = Cursors.WaitCursor
        LoadChildForm("frmEventHistory")
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tsbUptimeAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemHealthToolStripMenuItem.Click, tsbUptimeAnalysis.Click
        Me.Cursor = Cursors.WaitCursor
        LoadChildForm("frmUptimeAnalysis")
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub RefreshStatus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnRefresh.Click, TimerStatusRefresh.Tick
        Me.Cursor = Cursors.WaitCursor
        RefreshMonitorStatuses(False, StatusForms.All)
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Settings Menu/Toolbar"
    Private Sub LoadForm_GeneralSettings(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralToolStripMenuItem.Click, tslblAutoRefreshInterval.Click
        Me.Cursor = Cursors.WaitCursor
        LoadChildForm("frmGeneralSettings")
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadForm_LoadPolyMonExecutive(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecutiveToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        LoadChildForm("frmPolyMonExecutive")
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadForm_MonitorTypes(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonitorTypesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        LoadChildForm("frmMonitorTypes")
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadForm_Operators(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OperatorsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        LoadChildForm("frmOperators")
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadForm_MonitorDefinitions(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonitorDefinitionsToolStripMenuItem.Click, tsbMonitorDefs.Click, tsbMonitorDefs.Click
        Me.Cursor = Cursors.WaitCursor
        LoadChildForm("frmMonitorDefs")
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Window Menu"
    Private Sub HorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub VerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub MinimizeAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizeAllToolStripMenuItem.Click
        For Each ChildWin As Form In Me.MdiChildren
            ChildWin.WindowState = FormWindowState.Minimized
        Next
    End Sub
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        For Each ChildWin As Form In Me.MdiChildren
            ChildWin.Close()
        Next
    End Sub
    Private Sub RestoreAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreAllToolStripMenuItem.Click
        For Each ChildWin As Form In Me.MdiChildren
            ChildWin.WindowState = FormWindowState.Normal
        Next
    End Sub
#End Region

#Region "Help Menu"
    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click
        Help.ShowHelp(Me, "PolyMon.chm")
    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim myAbout As New frmAboutPolyMon
        myAbout.ShowDialog()
    End Sub
#End Region

#Region "Status Bar Tools"
    Private Sub OpenPolyMonManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenPolyMonManagerToolStripMenuItem.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub ClosePolyMonManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClosePolyMonManagerToolStripMenuItem.Click
        Me.mAllowClose = True
        Me.Close()
    End Sub
#End Region

#Region "Tray Icon Events"
    Private Sub NotifyIcon1_BalloonTipClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.BalloonTipClicked
        mOpeningFromTray = True
        LoadChildForm("frmFailuresWarnings")
        mOpeningFromTray = False
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub
#End Region
#End Region

#Region "Public Interface"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
		mForceClose = Not (InitForm())
	End Sub
    Public Enum StatusForms As Integer
        All = 0
        Dashboard = 1
        FailuresWarnings = 2
        CurrentStatus = 3
    End Enum
    Public Sub SetTimerInterval()
        Dim myUserSettings As New UserSettings

        SetRefreshStatus(myUserSettings.RefreshInterval.Name)
        If myUserSettings.RefreshIntervalIndex > 0 Then
            With TimerStatusRefresh
                .Stop()
                .Interval = myUserSettings.RefreshInterval.Interval * 1000
                .Enabled = True
                .Start()
            End With
        Else
            With TimerStatusRefresh
                .Stop()
                .Enabled = False
            End With
        End If
    End Sub
    Public Sub RefreshMonitorStatuses(ByVal IsTimerEvent As Boolean, ByVal StatusForm As StatusForms)
        Me.Cursor = Cursors.WaitCursor
        Dim IsAlertOpen As Boolean = False

        SetAlertStatus(AlertStatuses.None)

        'Refresh any open Status forms
        Select Case StatusForm
            Case StatusForms.All
                IsAlertOpen = False
                If Not (mfrmFailuresWarnings Is Nothing) AndAlso (ChildFormExists("frmFailuresWarnings")) Then
                    IsAlertOpen = True
                    mfrmFailuresWarnings.RefreshMonitors(True)
                End If
                If Not (mfrmDashBoard Is Nothing) AndAlso (ChildFormExists("frmDashboard")) Then
                    IsAlertOpen = True
                    mfrmDashBoard.RefreshDashboard(True)
                End If
                If Not (mfrmCurrentStatus Is Nothing) AndAlso (ChildFormExists("frmCurrentStatus")) Then
                    IsAlertOpen = True
                    mfrmCurrentStatus.RefreshMonitors(True)
                End If
            Case StatusForms.Dashboard
                If Not (mfrmDashBoard Is Nothing) AndAlso (ChildFormExists("frmDashboard")) Then
                    IsAlertOpen = True
                    mfrmDashBoard.RefreshDashboard(True)
                End If
            Case StatusForms.FailuresWarnings
                If Not (mfrmFailuresWarnings Is Nothing) AndAlso (ChildFormExists("frmFailuresWarnings")) Then
                    IsAlertOpen = True
                    mfrmFailuresWarnings.RefreshMonitors(True)
                End If
            Case StatusForms.CurrentStatus
                If Not (mfrmCurrentStatus Is Nothing) AndAlso (ChildFormExists("frmCurrentStatus")) Then
                    IsAlertOpen = True
                    mfrmCurrentStatus.RefreshMonitors(True)
                End If
        End Select

        'If no Status forms were open, check for Alerts/Warning directly against db
        If Not IsAlertOpen Then
            Dim NumWarnings As Integer = 0
            Dim NumFailures As Integer = 0
            If CheckNominalStatusOK(NumWarnings, NumFailures) Then
                'Everything OK
                SetAlertStatus(AlertStatuses.OK)
            Else
                'Alerts are present
                AlertRaised(Me, System.EventArgs.Empty)
            End If
        End If

        'Finally reset timer if this was not a regular timer event
        If Not (IsTimerEvent) Then
            SetTimerInterval()
        End If

        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Private Methods"
    Private Enum AlertStatuses As Integer
        None = 0
        OK = 1
        Alerts = 2
    End Enum

	Private Function InitForm() As Boolean
		Me.NotifyIcon1.BalloonTipTitle = "PolyMon Manager"
		Me.NotifyIcon1.BalloonTipText = Nothing
		Me.NotifyIcon1.Icon = My.Resources.icoPolyMon

		Dim Sys As New PolyMon.General.SysSettings
		If Sys.DBVersion <> mDBVersion Then
			'Incorrect Database version
			MsgBox(String.Format("Your database version is incompatible with this version of PolyMon Manager.{0}Your version: {1}{0}Required Version: {2}", vbCrLf, Format(Sys.DBVersion, "0.00"), Format(mDBVersion, "0.00")), MsgBoxStyle.Critical, "PolyMon Manager")
			InitForm = False
		Else
			SetTimerInterval()
			Dim myUserSettings As New UserSettings
			SetAlertStatus(AlertStatuses.None)
			RefreshMonitorStatuses(False, StatusForms.All)

			'Check command line parameters to see if StartMinimized was set
			Dim StartMinArg As String = "/StartMinimized="
			Dim StartMinVal As String = "0"

			For Each s As String In My.Application.CommandLineArgs
				If s.ToLower.StartsWith(StartMinArg.ToLower) Then
					StartMinVal = s.Remove(0, StartMinArg.Length)
					Exit For
				End If
			Next

			If IsNumeric(StartMinVal) AndAlso CInt(StartMinVal) = 1 Then
				Me.WindowState = FormWindowState.Minimized
				Me.Hide()
			End If

			'Change MDI form background color
			Dim c As Control
			For Each c In Me.Controls
				If c.GetType.Name = "MdiClient" Then
                    c.BackColor = myUserSettings.MDIBackColor
					Exit For
				End If
			Next

			InitForm = True
		End If
	End Function

    Public Function LoadChildForm(ByVal FormName As String) As Windows.Forms.Form
        Select Case FormName.ToUpper
            Case "frmDashboard".ToUpper
                If mfrmDashBoard Is Nothing OrElse Not (ChildFormExists(FormName)) Then
                    mfrmDashBoard = New frmDashboard()
                    mfrmDashBoard.MdiParent = Me
                    AddHandler mfrmDashBoard.AlertEvent, AddressOf AlertRaised
                    AddHandler mfrmDashBoard.AllNominal, AddressOf AllNominal
                    mfrmDashBoard.Show()
                    RefreshMonitorStatuses(False, StatusForms.Dashboard)
                Else
                    mfrmDashBoard.Activate()
                End If
                'mfrmDashBoard.RefreshLayout()
                Return mfrmDashBoard
            Case "frmCurrentStatus".ToUpper
                If mfrmCurrentStatus Is Nothing OrElse Not (ChildFormExists(FormName)) Then
                    mfrmCurrentStatus = New frmCurrentStatus()
                    mfrmCurrentStatus.MdiParent = Me
                    AddHandler mfrmCurrentStatus.AlertEvent, AddressOf AlertRaised
                    AddHandler mfrmCurrentStatus.AllNominal, AddressOf AllNominal
                    mfrmCurrentStatus.Show()
                Else
                    mfrmCurrentStatus.Activate()
                End If
                Return mfrmCurrentStatus
            Case "frmFailuresWarnings".ToUpper
                If mfrmFailuresWarnings Is Nothing OrElse Not (ChildFormExists(FormName)) Then
                    mfrmFailuresWarnings = New frmFailuresWarnings
                    mfrmFailuresWarnings.MdiParent = Me
                    AddHandler mfrmFailuresWarnings.AlertEvent, AddressOf AlertRaised
                    AddHandler mfrmFailuresWarnings.AllNominal, AddressOf AllNominal
                    mfrmFailuresWarnings.Show()
                    RefreshMonitorStatuses(False, StatusForms.FailuresWarnings)
                Else
                    mfrmFailuresWarnings.Activate()
                End If
                Return mfrmFailuresWarnings
            Case "frmEventHistory".ToUpper
                If mfrmEventHistory Is Nothing OrElse Not (ChildFormExists(FormName)) Then
                    mfrmEventHistory = New frmEventHistory
                    mfrmEventHistory.MdiParent = Me
                    mfrmEventHistory.Show()
                Else
                    mfrmEventHistory.Activate()
                End If
                Return mfrmEventHistory
            Case "frmUptimeAnalysis".ToUpper
                If mfrmUptimeAnalysis Is Nothing OrElse Not (ChildFormExists(FormName)) Then
                    mfrmUptimeAnalysis = New frmUptimeAnalysis
                    mfrmUptimeAnalysis.MdiParent = Me
                    mfrmUptimeAnalysis.Show()
                Else
                    mfrmEventHistory.Activate()
                End If
                Return mfrmEventHistory
            Case "frmGeneralSettings".ToUpper
                If mfrmGeneralSettings Is Nothing OrElse Not (ChildFormExists(FormName)) Then
                    mfrmGeneralSettings = New frmGeneralSettings
                    mfrmGeneralSettings.MdiParent = Me
                    mfrmGeneralSettings.Show()
                Else
                    mfrmGeneralSettings.Activate()
                End If
                Return mfrmGeneralSettings
            Case "frmMonitorDefs".ToUpper
                If mfrmMonitorDefs Is Nothing OrElse Not (ChildFormExists(FormName)) Then
                    mfrmMonitorDefs = New frmMonitorDefs
                    mfrmMonitorDefs.MdiParent = Me
                    mfrmMonitorDefs.Show()
                Else
                    mfrmMonitorDefs.Activate()
                End If
                Return mfrmMonitorDefs
            Case "frmMonitorTypes".ToUpper
                If mfrmMonitorTypes Is Nothing OrElse Not (ChildFormExists(FormName)) Then
                    mfrmMonitorTypes = New frmMonitorTypes
                    mfrmMonitorTypes.MdiParent = Me
                    mfrmMonitorTypes.Show()
                Else
                    mfrmMonitorTypes.Activate()
                End If
                Return mfrmMonitorTypes
            Case "frmOperators".ToUpper
                If mfrmOperators Is Nothing OrElse Not (ChildFormExists(FormName)) Then
                    mfrmOperators = New frmOperators
                    mfrmOperators.MdiParent = Me
                    mfrmOperators.Show()
                Else
                    mfrmOperators.Activate()
                End If
                Return mfrmOperators
            Case "frmPolymonExecutive".ToUpper
                If mfrmPolymonExecutive Is Nothing OrElse Not (ChildFormExists(FormName)) Then
                    mfrmPolymonExecutive = New frmPolyMonExecutive
                    mfrmPolymonExecutive.MdiParent = Me
                    mfrmPolymonExecutive.Show()
                Else
                    mfrmPolymonExecutive.Activate()
                End If
                Return mfrmPolymonExecutive
            Case Else
                MsgBox("Unknown Form!!", MsgBoxStyle.Exclamation, "Error Loading Form...")
                Return Nothing
        End Select


    End Function
    Private Function ChildFormExists(ByVal FormName As String) As Boolean
        Dim hWin As Windows.Forms.Form

        For Each hWin In Me.MdiChildren
            If hWin.Name = FormName Then
                Return True
                Exit For
            End If
        Next
        Return False
    End Function

    Private Sub AlertRaised(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim myUserSettings As New UserSettings

        If myUserSettings.AudibleAlertsEnabled AndAlso Not (mOpeningFromTray) Then
            Try
                My.Computer.Audio.Play(myUserSettings.AudioAlertFile)
            Catch ex As Exception
                Beep()
            End Try
        End If

        SetAlertStatus(AlertStatuses.Alerts)
        'Me.NotifyIcon1.Icon = My.Resources.icoWarning
        'If myUserSettings.BalloonAlertsEnabled AndAlso Not (mOpeningFromTray) Then
        '    Me.NotifyIcon1.BalloonTipText = "Some Monitors have a Failure/Warning status. Click here to view them."
        '    Me.NotifyIcon1.ShowBalloonTip(30000)
        'End If
    End Sub
    Private Sub AllNominal(ByVal sender As System.Object, ByVal e As EventArgs)
        SetAlertStatus(AlertStatuses.OK)
        'Me.NotifyIcon1.Icon = My.Resources.icoPolyMon
        'Me.NotifyIcon1.BalloonTipText = Nothing
    End Sub

    Private Function CheckNominalStatusOK(ByRef NumWarnings As Integer, ByVal NumFailures As Integer) As Boolean
        Dim sp As String = "polymon_sel_NonNominalMonitors"
        Dim strSQLConn As String = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
        Dim SQLConn As New SqlConnection(strSQLConn)

        Dim SQLCmd As New SqlCommand
        With SQLCmd
            .Connection = SQLConn
            .CommandType = CommandType.StoredProcedure
            .CommandText = sp
        End With

        Dim rdResults As SqlDataReader
        Dim ErrorsWarnings As Boolean = False
        NumWarnings = 0
        NumFailures = 0

        Try
            SQLConn.Open()
            rdResults = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rdResults.Read()
                ErrorsWarnings = True
                If CInt(rdResults.Item("StatusID")) = 2 Then
                    NumWarnings += 1
                ElseIf CInt(rdResults.Item("StatusID")) = 3 Then
                    NumFailures += 1
                End If
            End While

            Return Not (ErrorsWarnings)
        Catch ex As Exception
            MsgBox("Error loading Monitor statuses." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Polymon")
        Finally
            If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
            SQLConn.Dispose()
        End Try

        Return ErrorsWarnings
    End Function

    Private Sub SetAlertStatus(ByVal AlertStatus As AlertStatuses)
        Dim myUserSettings As New UserSettings

        Select Case AlertStatus
            Case AlertStatuses.None
                Me.tslblUnknown.Visible = False
                Me.tslblOK.Visible = False
                Me.tslblAlerts.Visible = False
				'Me.NotifyIcon1.Icon = My.Resources.icoPolyMon
				'Me.NotifyIcon1.Icon = My.Resources.icoWarning
				Me.NotifyIcon1.Icon = My.Resources.PolyMonOK
                Me.NotifyIcon1.Visible = True
            Case AlertStatuses.OK
                Me.tslblUnknown.Visible = False
                Me.tslblOK.Visible = True
                Me.tslblAlerts.Visible = False
				'Me.NotifyIcon1.Icon = My.Resources.icoPolyMon
				Me.NotifyIcon1.Icon = My.Resources.PolyMonOK
                Me.NotifyIcon1.Visible = True
            Case AlertStatuses.Alerts
                Me.tslblUnknown.Visible = False
                Me.tslblOK.Visible = False
                Me.tslblAlerts.Visible = True
				'Me.NotifyIcon1.Icon = My.Resources.icoWarning
				Me.NotifyIcon1.Icon = My.Resources.PolyMonWarning
                If myUserSettings.BalloonAlertsEnabled AndAlso Not (mOpeningFromTray) Then
                    Me.NotifyIcon1.BalloonTipText = "Some Monitors have a Failure/Warning status. Click here to view them."
                    Me.NotifyIcon1.ShowBalloonTip(30000)
                End If
                Me.NotifyIcon1.Visible = True
        End Select
		Me.tslblAsOf.Text = "(as of " & Format(Now(), "MMM dd, yyyy hh:mm:ss tt" & ")")
    End Sub
    Private Sub SetRefreshStatus(ByVal IntervalName As String)
        Me.tslblAutoRefreshInterval.Text = IntervalName
    End Sub
#End Region
End Class

