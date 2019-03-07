Imports PolyMon.Dashboard

Public Class frmDashboard

#Region "Private Attributes"
    Private mGroups As New List(Of UCPanelGroup)
    Private mBulkRefresh As Boolean = False
    Private mBulkRaiseEvent As Boolean = False
#End Region

#Region "Event Handlers"
    Private Sub frmDashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDashboard()
    End Sub
    Private Sub PanelAlertHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If mBulkRefresh Then
            mBulkRaiseEvent = True
        Else
            RaiseEvent AlertEvent(Me, System.EventArgs.Empty)
        End If
    End Sub
    Private Sub tbtnOrderGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnOrderGroups.Click
        Dim Groups As New List(Of UCPanelGroup)
        Dim Group As UCPanelGroup
        For Each Group In Me.FlowLayoutPanel1.Controls
            Groups.Add(Group)
        Next

        Dim myDialog As dlgOrderGroups = New dlgOrderGroups(Groups)
        Dim myresult As DialogResult = myDialog.ShowDialog()
        If myresult = Windows.Forms.DialogResult.OK Then
            'Re-order Groups
            Dim i As Integer = 0
            For Each Group In myDialog.NewOrderGroups
                Me.FlowLayoutPanel1.Controls.SetChildIndex(Group, i)
                i += 1
            Next
        End If
    End Sub
    Private Sub tbtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRefresh.Click
        CType(Me.MdiParent, frmMain).RefreshMonitorStatuses(False, frmMain.StatusForms.Dashboard)
    End Sub
    Private Sub tbtnNewGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnNewGroup.Click
        Dim GroupName As String = InputBox("Enter a new Group Name:", "Create New Panel Group", Nothing)

        If GroupName Is Nothing OrElse GroupName.Trim.Length = 0 Then
            'Do nothing
        Else
            'Create a New Group
            Dim PanelGroups As New PolyMon.Dashboard.PanelGroups
            Try
                'Create Panel Group
                Dim NewGroup As New PolyMon.Dashboard.PanelGroup(GroupName, 9999)
                NewGroup.Save()
                'Assign a UC to new panel group and display it
                Dim NewUCPanelGroup As New UCPanelGroup(NewGroup.GroupID)
                AddHandler NewUCPanelGroup.Alert, New EventHandler(AddressOf PanelAlertHandler)
                AddHandler NewUCPanelGroup.BeforeDelete, New EventHandler(AddressOf GroupDeleted)
                mGroups.Add(NewUCPanelGroup)
                Me.FlowLayoutPanel1.Controls.Add(NewUCPanelGroup)
                NewUCPanelGroup.Width = Me.FlowLayoutPanel1.Size.Width - 25
            Catch ex As Exception
                MsgBox("Error creating new Group:" & ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub tbtnViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnViewList.Click
        If tbtnViewList.Checked Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim UserSettings As New UserSettings()
        UserSettings.DashboardViewType = PolyMonManager.UserSettings.MonitorViewTypes.List
        tbtnViewList.Checked = True
        tbtnViewTiles.Checked = False
        LoadDashboard()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tbtnViewTiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnViewTiles.Click
        If tbtnViewTiles.Checked Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim UserSettings As New UserSettings()
        UserSettings.DashboardViewType = PolyMonManager.UserSettings.MonitorViewTypes.Tiles
        tbtnViewList.Checked = False
        tbtnViewTiles.Checked = True
        LoadDashboard()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FlowLayoutPanel1_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles FlowLayoutPanel1.Layout
        ResizeFlowPanel()
    End Sub
#End Region

#Region "Public Interface"
    Public Event AlertEvent As EventHandler
    Public Event AllNominal As EventHandler

    Public Sub RefreshDashboard(ByVal RaiseErrors As Boolean)
        BulkRefresh(RaiseErrors)
    End Sub
    Public Sub ReloadDashboard()
        LoadDashboard()
    End Sub
#End Region

#Region "Private Methods"
    Private Sub LoadDashboard()
        Dim UserSettings As New UserSettings

        If UserSettings.DashboardViewType = PolyMonManager.UserSettings.MonitorViewTypes.List Then
            tbtnViewList.Checked = True
            tbtnViewTiles.Checked = False
        Else
            tbtnViewList.Checked = False
            tbtnViewTiles.Checked = True
        End If

        Dim Groups As New PanelGroups()
        Dim Group As PolyMon.Dashboard.PanelGroup

        'Remove any existing PanelGroups and associated event handlers
        FlowLayoutPanel1.Visible = False
        Dim ctl As UCPanelGroup
        Do While FlowLayoutPanel1.Controls.Count > 0
            ctl = CType(FlowLayoutPanel1.Controls.Item(0), UCPanelGroup)
            RemoveHandler ctl.Alert, AddressOf PanelAlertHandler
            RemoveHandler ctl.BeforeDelete, AddressOf GroupDeleted
            FlowLayoutPanel1.Controls.RemoveAt(0)
            ctl.Dispose()
        Loop
        FlowLayoutPanel1.Controls.Clear()


        For Each Group In Groups.List()
            Dim myGroup As New UCPanelGroup(Group.GroupID)
            AddHandler myGroup.Alert, New EventHandler(AddressOf PanelAlertHandler)
            AddHandler myGroup.BeforeDelete, New EventHandler(AddressOf GroupDeleted)
            mGroups.Add(myGroup)
            myGroup.Width = Me.FlowLayoutPanel1.Size.Width - 25
            Me.FlowLayoutPanel1.Controls.Add(myGroup)
        Next

        FlowLayoutPanel1.Visible = True
    End Sub
    Private Sub BulkRefresh(ByVal RaiseErrors As Boolean)
        mBulkRefresh = True
        mBulkRaiseEvent = False
        Dim myGroup As UCPanelGroup
        For Each myGroup In Me.FlowLayoutPanel1.Controls
            myGroup.RefreshPanels()
        Next
        If mBulkRaiseEvent Then
            If RaiseErrors Then RaiseEvent AlertEvent(Me, System.EventArgs.Empty)
        Else
            RaiseEvent AllNominal(Me, System.EventArgs.Empty)
        End If
        mBulkRefresh = False
    End Sub
    Private Sub GroupDeleted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim UCGroup As UCPanelGroup = CType(sender, UCPanelGroup)
        Dim GroupID As Integer = UCGroup.GroupID
        Dim PanelGroups As New PolyMon.Dashboard.PanelGroups()
        Dim PanelGroup As New PolyMon.Dashboard.PanelGroup(GroupID)

        Try
            PanelGroups.RemoveGroup(PanelGroup)
            Dim MyIndex As Integer = -1
            Dim i As Integer
            For i = 0 To Me.FlowLayoutPanel1.Controls.Count - 1
                If CType(Me.FlowLayoutPanel1.Controls(i), UCPanelGroup).GroupID = UCGroup.GroupID Then
                    Me.FlowLayoutPanel1.Controls.Remove(UCGroup)
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("Error deleting PanelGroup:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ResizeFlowPanel()
        Dim myGroup As UCPanelGroup
        For Each myGroup In mGroups
            myGroup.Width = Me.FlowLayoutPanel1.ClientSize.Width - 25
        Next
    End Sub
#End Region

End Class