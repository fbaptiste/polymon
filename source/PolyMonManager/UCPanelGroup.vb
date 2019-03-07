Imports PolyMon.Dashboard

Public Class UCPanelGroup

#Region "Private Attributes"
    Private mGroupID As Integer = -1
    Private mCurrVisibleStateExpanded As Boolean = True
    Private mPanelGroup As PolyMon.Dashboard.PanelGroup = Nothing
    Private mBulkRefresh As Boolean = False
    Private mBulkRaiseEvent As Boolean = False

    Private mUserSettings As New UserSettings()
#End Region

#Region "Public Interface"
    Public Sub New(ByVal GroupID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            mGroupID = GroupID
            LoadPanels(GroupID)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub RefreshPanels()
        Dim myPanel As UCMonitorPanel
        Dim AlertLevel As PolyMon.Monitors.MonitorStatus.eStatus = PolyMon.Monitors.MonitorStatus.eStatus.OK
        mBulkRefresh = True
        mBulkRaiseEvent = False
        For Each myPanel In pnlMain.Controls
            Try
                myPanel.RefreshData()
            Catch ex As Exception
                'Do nothing if error occurs
            End Try
        Next
        SetPanelAlertStatus()
        mBulkRefresh = False
        If mBulkRaiseEvent Then
            RaiseEvent Alert(Me, EventArgs.Empty)
        End If
    End Sub
    Public ReadOnly Property GroupName() As String
        Get
            Return mPanelGroup.Name
        End Get
    End Property
    Public ReadOnly Property GroupID() As Integer
        Get
            Return mGroupID
        End Get
    End Property
    Public ReadOnly Property PanelGroup() As PolyMon.Dashboard.PanelGroup
        Get
            Return mPanelGroup
        End Get
    End Property

    Public Event Alert As EventHandler
    Public Event BeforeDelete As EventHandler
#End Region

#Region "Event Handlers"
    Private Sub PanelDeletedHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim UCMonitorPanel As UCMonitorPanel = CType(sender, UCMonitorPanel)
        Dim PanelID As Integer = UCMonitorPanel.PanelID

        'Remove Panel from Group (both visual and database)
        Dim MonitorPanels As New PolyMon.Dashboard.MonitorPanels(mGroupID)
        MonitorPanels.RemovePanel(New PolyMon.Dashboard.MonitorPanel(PanelID))

        'Remove control and handlers
        RemoveHandler UCMonitorPanel.AlertEvent, AddressOf PanelAlertHandler
        RemoveHandler UCMonitorPanel.BeforeDelete, AddressOf PanelDeletedHandler
        pnlMain.Controls.Remove(UCMonitorPanel)

        ResizeGroup()
        SetPanelAlertStatus()
    End Sub
    Private Sub PanelAlertHandler(ByVal sender As System.Object, ByVal e As AlertEventArgs)
        'Send this event upstream, no handling here
        If mBulkRefresh Then
            mBulkRaiseEvent = True 'batch events when in batch refresh mode...
        Else
            SetPanelAlertStatus()
            If Not (e.AlertStatus.Status = PolyMon.Monitors.MonitorStatus.eStatus.OK) Then
                RaiseEvent Alert(sender, e)
            End If
        End If
    End Sub

    Private Sub tbtnCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnCollapse.Click
        SetVisibleState(False)
        mUserSettings.PanelGroupIsOpen(Me.GroupID) = False
    End Sub
    Private Sub tbtnExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnExpand.Click
        SetVisibleState(True)
        mUserSettings.PanelGroupIsOpen(Me.GroupID) = True
    End Sub
    Private Sub tbtnAddPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnAddPanel.Click
        'Add Panel to Group
        Dim myDialog As dlgMonitor = New dlgMonitor(Me.mGroupID, 0, True)
        Dim myResult As DialogResult = myDialog.ShowDialog()

        If myResult = DialogResult.OK Then
            'If myDialog.SelectedMonitorID > -1 Then
            If myDialog.SelectedMonitors.Count > 0 Then
                Me.Cursor = Cursors.WaitCursor

                'Find max DisplayOrder and add to end of list
                Dim DisplayOrder As Integer = -1
                For i As Integer = 0 To Me.mPanelGroup.Panels.Count - 1
                    If Me.mPanelGroup.Panels.Item(i).DisplayOrder > DisplayOrder Then
                        DisplayOrder = Me.mPanelGroup.Panels.Item(i).DisplayOrder
                    End If
                Next
                DisplayOrder += 1

                'Add Panel
                Dim MonitorID As Integer
                For Each MonitorID In myDialog.SelectedMonitors
                    AddNewPanel(mGroupID, MonitorID, DisplayOrder)
                    DisplayOrder += 1
                Next

                Me.Cursor = Cursors.Default
            End If
        End If

    End Sub
    Private Sub tbtnOrderPanels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnOrderPanels.Click
        Dim Panels As New List(Of UCMonitorPanel)
        Dim Panel As UCMonitorPanel
        For Each Panel In Me.pnlMain.Controls
            Panels.Add(Panel)
        Next

        Dim myDialog As dlgOrderPanels = New dlgOrderPanels(Panels)
        Dim myresult As DialogResult = myDialog.ShowDialog()
        If myresult = DialogResult.OK Then
            'LoadPanels(mGroupID)
            're-order panels
            Dim i As Integer = 0
            For Each Panel In myDialog.NewOrderPanels
                Me.pnlMain.Controls.SetChildIndex(Panel, i)
                i += 1
            Next
        End If
    End Sub
    Private Sub tbtnRefreshPanelStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRefreshPanelStatus.Click
        Me.Cursor = Cursors.WaitCursor
        RefreshPanels()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tbtnDeleteGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnDeleteGroup.Click
        Dim res As MsgBoxResult = MsgBox("You are about to delete this group and all sub panels." & vbCrLf & "Are you sure?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "PolyMon - Delete Panel Group")
        If res = MsgBoxResult.Yes Then
            RaiseEvent BeforeDelete(Me, EventArgs.Empty)
        End If
    End Sub
    Private Sub tbtnEditGroupName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnEditGroupName.Click
        'Edit current Group name
        Dim NewName As String = InputBox("Please enter new Group name:", "Rename Group...", mPanelGroup.Name)
        If NewName Is Nothing OrElse NewName.Trim.Length = 0 Then
            'Cancel
        Else
            mPanelGroup.Name = NewName
            mPanelGroup.Save()
            tlblGroupName.Text = NewName
        End If

    End Sub

    Private Sub pnlMain_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMain.ClientSizeChanged
        Me.Height = Me.ToolStrip1.Height + Me.pnlMain.Height
    End Sub
    Private Sub PanelGroup_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        ResizeGroup()
    End Sub
#End Region

#Region "Private Methods"
    Private Sub SetVisibleState(ByVal Expanded As Boolean)
        Me.tbtnExpand.Visible = Not (Expanded)
        Me.tbtnCollapse.Visible = Expanded

        mCurrVisibleStateExpanded = Expanded

        If Expanded Then
            Me.pnlMain.Height = Me.pnlMain.GetPreferredSize(New Size(Me.pnlMain.Width, 0)).Height
        Else
            Me.pnlMain.Height = 0
        End If
    End Sub
    Public Sub ResizeGroup()
        If mCurrVisibleStateExpanded Then
            Me.pnlMain.Height = Me.pnlMain.GetPreferredSize(New Size(Me.pnlMain.Width, 0)).Height
        Else
            Me.pnlMain.Height = 0
        End If
    End Sub
    Private Sub AddNewPanel(ByVal GroupID As Integer, ByVal MonitorID As Integer, ByVal DisplayOrder As Integer)
        Dim NewPanel As New PolyMon.Dashboard.MonitorPanel(GroupID, MonitorID, DisplayOrder)
        NewPanel.Save()
        LoadPanels(mGroupID)
    End Sub

    Private Sub LoadPanels(ByVal GroupID As Integer)
        pnlMain.Visible = False

        mPanelGroup = New PolyMon.Dashboard.PanelGroup(GroupID)
        tlblGroupName.Text = mPanelGroup.Name

        'Clear our current contents of pnlMain
        Dim ctl As UCMonitorPanel
        Do While pnlMain.Controls.Count > 0
            ctl = CType(pnlMain.Controls.Item(0), UCMonitorPanel)
            RemoveHandler ctl.AlertEvent, AddressOf PanelAlertHandler
            RemoveHandler ctl.BeforeDelete, AddressOf PanelDeletedHandler
            pnlMain.Controls.RemoveAt(0)
            ctl.Dispose()
        Loop
        pnlMain.Controls.Clear()


        Dim myPanel As PolyMon.Dashboard.MonitorPanel
        mUserSettings.Refresh()
        For Each myPanel In mPanelGroup.Panels()
            Select Case mUserSettings.DashboardViewType
                Case UserSettings.MonitorViewTypes.Tiles
                    Dim ChildUCPanel As New UCMonitorPanelDetailsView(myPanel.PanelID)
                    AddHandler ChildUCPanel.BeforeDelete, New EventHandler(AddressOf PanelDeletedHandler)
                    AddHandler ChildUCPanel.AlertEvent, AddressOf PanelAlertHandler
                    Me.pnlMain.Controls.Add(ChildUCPanel)
                Case UserSettings.MonitorViewTypes.List
                    Dim ChildUCPanel As New UCMonitorPanelListView(myPanel.PanelID)
                    AddHandler ChildUCPanel.BeforeDelete, New EventHandler(AddressOf PanelDeletedHandler)
                    AddHandler ChildUCPanel.AlertEvent, AddressOf PanelAlertHandler
                    Me.pnlMain.Controls.Add(ChildUCPanel)
            End Select
        Next
        SetPanelAlertStatus()

        Dim OpenStatus As Boolean = False
        OpenStatus = mUserSettings.PanelGroupIsOpen(GroupID)
        SetVisibleState(OpenStatus)

        pnlMain.Visible = True
    End Sub

    Private Sub SetPanelAlertStatus()
        Dim myPanel As UCMonitorPanel
        Dim AlertLevel As PolyMon.Monitors.MonitorStatus.eStatus = PolyMon.Monitors.MonitorStatus.eStatus.OK
		For Each myPanel In pnlMain.Controls
			If myPanel.MonitorEnabled Then
				If myPanel.CurrentStatus.Status = PolyMon.Monitors.MonitorStatus.eStatus.Warning Then
					If AlertLevel = PolyMon.Monitors.MonitorStatus.eStatus.OK Then
						AlertLevel = PolyMon.Monitors.MonitorStatus.eStatus.Warning
					End If
				ElseIf myPanel.CurrentStatus.Status = PolyMon.Monitors.MonitorStatus.eStatus.Fail Then
					AlertLevel = PolyMon.Monitors.MonitorStatus.eStatus.Fail
				End If
			End If
		Next

        Select Case AlertLevel
            Case PolyMon.Monitors.MonitorStatus.eStatus.Fail
                ToolStrip1.BackColor = Color.OrangeRed
            Case PolyMon.Monitors.MonitorStatus.eStatus.Warning
                ToolStrip1.BackColor = Color.Khaki
            Case Else
                ToolStrip1.BackColor = Color.LightSkyBlue
        End Select
    End Sub
#End Region

End Class
