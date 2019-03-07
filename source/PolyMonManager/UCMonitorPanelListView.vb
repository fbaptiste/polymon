Public Class UCMonitorPanelListView

#Region "Private Attributes"
    Dim mMonitorID As Integer
    Dim mPanelID As Integer
    Dim mGroupID As Integer
    Dim mMonitorPanel As PolyMon.Dashboard.MonitorPanel

    Dim mMonitorStatus As PolyMon.Monitors.MonitorStatus
    Dim mMonitorMetadata As PolyMon.Monitors.MonitorMetadata
    Dim mMonitorOperators As PolyMon.Operators.MonitorOperators
#End Region

#Region "Public Interface"
    Public Sub New(ByVal PanelID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mPanelID = PanelID

        mMonitorPanel = New PolyMon.Dashboard.MonitorPanel(PanelID)
        mMonitorID = mMonitorPanel.MonitorID
        mGroupID = mMonitorPanel.GroupID

        RefreshData()
    End Sub
    Public Sub New(ByVal MonitorID As Integer, ByVal UseMonitorID As Boolean)
        'Use this constructor for when the Monitor Panel is used outside of the Dashboard panels context. In this case
        'Panel related functions are disabled or unavailable.

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mMonitorID = MonitorID
        mPanelID = -1

        mMonitorPanel = New PolyMon.Dashboard.MonitorPanel(MonitorID, True)
        mGroupID = mMonitorPanel.GroupID
        'Also disable the "Remove from Group" button since this not applicable in this setting
        Me.btnRemoveMonitor.Enabled = False


        RefreshData()
    End Sub

    Public Overrides Sub RefreshData()
        Dim OldMonitorStatus As PolyMon.Monitors.MonitorStatus
        OldMonitorStatus = mMonitorStatus

        mMonitorStatus = Nothing
        mMonitorMetadata = Nothing
        mMonitorOperators = Nothing
        ClearMonitorData()

        mMonitorStatus = New PolyMon.Monitors.MonitorStatus(mMonitorID)
        Try
            mMonitorMetadata = New PolyMon.Monitors.MonitorMetadata(mMonitorID)
        Catch ex As Exception
            'Monitor could not be found in database, remove it from group
            RaiseEvent BeforeDelete(Me, EventArgs.Empty)
            Exit Sub
        End Try
        mMonitorOperators = New PolyMon.Operators.MonitorOperators(mMonitorID)

        Me.lblMonitorName.Text = mMonitorMetadata.MonitorName
		Me.lblMonitorType.Text = mMonitorMetadata.MonitorType

		If mMonitorMetadata.Enabled Then
			'Me.lblStatus.Text = mMonitorStatus.CurrentStatus.Status.ToString & "  (" & CStr(IIf(mMonitorMetadata.Enabled, "Enabled", "Disabled")) & ")"
			Me.lblStatus.Text = mMonitorStatus.CurrentStatus.StatusElapsedTxt
			Me.lblHealth.Text = Format(mMonitorStatus.CurrentStatus.LifetimePercUptime, "##0.0##") & "%"


			Select Case mMonitorStatus.CurrentStatus.Status
				Case PolyMon.Monitors.MonitorStatus.eStatus.OK
                    Me.lblMonitorName.ForeColor = Color.Black
                Case PolyMon.Monitors.MonitorStatus.eStatus.Fail
                    Me.lblMonitorName.ForeColor = Color.OrangeRed
                Case PolyMon.Monitors.MonitorStatus.eStatus.Warning
                    Me.lblMonitorName.ForeColor = Color.Blue
                Case PolyMon.Monitors.MonitorStatus.eStatus.Unknown
                    Me.lblMonitorName.ForeColor = Color.Yellow
            End Select

			Me.BackColor = Color.WhiteSmoke

			Me.pcbStatus.Image = Me.ImageListStatus.Images.Item(mMonitorStatus.CurrentStatus.Status)
			Me.lblMessage.Text = mMonitorStatus.CurrentStatus.StatusMessage

			If mMonitorStatus.CurrentStatus.Status <> PolyMon.Monitors.MonitorStatus.eStatus.Unknown Then
				Me.lblLastEventDT.Text = Format(mMonitorStatus.CurrentStatus.EventDate, "MMM dd, yyyy hh:mm:ss tt")
			Else
				Me.lblLastEventDT.Text = "N/A"
			End If

			If (Not (OldMonitorStatus Is Nothing) AndAlso OldMonitorStatus.CurrentStatus.Status <> mMonitorStatus.CurrentStatus.Status) _
			 OrElse (mMonitorStatus.CurrentStatus.Status = PolyMon.Monitors.MonitorStatus.eStatus.Fail Or mMonitorStatus.CurrentStatus.Status = PolyMon.Monitors.MonitorStatus.eStatus.Warning) Then
				RaiseEvent AlertEvent(Me, New AlertEventArgs(mMonitorStatus.CurrentStatus))
			End If

		Else
			'Monitor disabled
			'Me.lblStatus.Text = "Disabled"
			Me.lblStatus.Text = Nothing
			Me.lblHealth.Text = Nothing

			Me.BackColor = Color.LightGray
            Me.lblMonitorName.ForeColor = Color.Black

			Me.pcbStatus.Image = Me.ImageListStatus.Images.Item(8)

			'Me.lblMessage.Text = Nothing
			Me.lblMessage.Text = "Disabled"

			Me.lblLastEventDT.Text = Nothing
		End If

	End Sub
    Public Overrides ReadOnly Property MonitorID() As Integer
        Get
            Return mMonitorID
        End Get
    End Property
    Public Overrides ReadOnly Property MonitorName() As String
        Get
            Return mMonitorPanel.MonitorName
        End Get
    End Property
    Public Overrides ReadOnly Property PanelID() As Integer
        Get
            Return mPanelID
        End Get
    End Property
    Public Overrides ReadOnly Property GroupID() As Integer
        Get
            Return mGroupID
        End Get
    End Property
    Public Overrides ReadOnly Property MonitorPanel() As PolyMon.Dashboard.MonitorPanel
        Get
            Return mMonitorPanel
        End Get
    End Property
    Public Overrides ReadOnly Property CurrentStatus() As PolyMon.Monitors.MonitorStatus.Current
        Get
            Return mMonitorStatus.CurrentStatus
        End Get
	End Property
	Public Overrides ReadOnly Property MonitorEnabled() As Boolean
		Get
			Return mMonitorMetadata.Enabled
		End Get
	End Property
    Public Shadows Event BeforeDelete As EventHandler
    Public Shadows Delegate Sub AlertEventHandler(ByVal sender As Object, ByVal e As AlertEventArgs)
    Public Shadows Event AlertEvent As AlertEventHandler
#End Region

#Region "Private Methods/Event Handlers"
    Private Sub InitForm()
        With Me.lblMonitorName
            .Text = Nothing
            .ForeColor = Color.Black
        End With

        Me.lblMonitorType.Text = Nothing

        ClearMonitorData()
    End Sub
    Private Sub ClearMonitorData()
        Me.lblStatus.Text = Nothing
        Me.pcbStatus.Image = Nothing
        Me.lblMessage.Text = Nothing
        Me.lblLastEventDT.Text = Nothing
    End Sub
    Private Sub RunMonitor(ByVal MonitorID As Integer)
        Dim AssemblyPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "Monitors/"
        Dim MonitorMetadata As New PolyMon.Monitors.MonitorMetadata(MonitorID)
        Dim MonitorAssembly As String = MonitorMetadata.MonitorAssembly
        Dim myMonitor As PolyMon.Monitors.MonitorExecutor = Nothing

        Dim asm As Reflection.Assembly
        Dim MonitorType As Type = Nothing
        Dim ty As Type
        Dim types() As Type
        Dim ci As Reflection.ConstructorInfo
        Dim params() As Object
        Dim obj As Object
        Dim apppath As String = System.AppDomain.CurrentDomain.BaseDirectory()

        asm = Reflection.Assembly.LoadFrom(AssemblyPath & MonitorAssembly)
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
        End If

        myMonitor.ManualOverride = True
        myMonitor.ForceLog = True
        myMonitor.RunMonitor()

        MonitorMetadata = Nothing
        myMonitor = Nothing
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        RefreshData()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        Me.Cursor = Cursors.WaitCursor
        RunMonitor(Me.mMonitorID)
        RefreshData()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
		'Dim myHistory As New frmHistory(mMonitorID)
		'myHistory.MdiParent = frmMain
		'myHistory.Show()
		Dim myReport As New frmReports(mMonitorID)
		myReport.MdiParent = frmMain
		myReport.Show()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnRemoveMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveMonitor.Click
        Dim result As MsgBoxResult = MsgBox("You are about to remove this Monitor from the group. Are you sure?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Remove Monitor from Group")
        If result = MsgBoxResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            RaiseEvent BeforeDelete(Me, EventArgs.Empty)
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub btnMonitorDef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonitorDef.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmMonitorDefs As frmMonitorDefs = CType(CType(Me.ParentForm.ParentForm, frmMain).LoadChildForm("frmMonitorDefs"), frmMonitorDefs)
        frmMonitorDefs.EditMonitor(mMonitorID)
        Me.Cursor = Cursors.Default
    End Sub
#End Region
End Class
