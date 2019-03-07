Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Collections.ObjectModel

Public Class dlgMonitor

#Region "Private Attributes"
    Private mGroupID As Integer = -1
    'Private mSelectedMonitorID As Integer = -1
    Private mSelectedMonitors As New List(Of Integer)
#End Region

#Region "Public Interface"
    Public Sub New(ByVal PreSelectedMonitorID As Integer)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mGroupID = -1
        LoadMonitors(PreSelectedMonitorID)
    End Sub
    Public Sub New(ByVal GroupID As Integer, ByVal PreSelectedMonitorID As Integer)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        'Only returns Monitors belonging to selected group
        mGroupID = GroupID
        LoadMonitors(GroupID, PreSelectedMonitorID)
    End Sub
    Public Sub New(ByVal GroupID As Integer, ByVal PreSelectedMonitorID As Integer, ByVal AvailableMonitorsOnly As Boolean)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        'Returns All monitors (irrespective of group) or returns Monitors NOT in specified group
        mGroupID = GroupID
        LoadFilteredMonitors(GroupID, PreSelectedMonitorID, AvailableMonitorsOnly)
    End Sub

    Public ReadOnly Property SelectedMonitors() As List(Of Integer)
        Get
            Return Me.mSelectedMonitors
        End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim MonitorID As Integer
        Dim SelectedIndex As Integer

        For Each SelectedIndex In Me.lstviewMonitors.SelectedIndices
            MonitorID = CInt(lstviewMonitors.Items(SelectedIndex).SubItems(0).Name)
            Me.mSelectedMonitors.Add(MonitorID)
        Next

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.mSelectedMonitors.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub lstviewMonitors_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstviewMonitors.ColumnClick
        Dim CurrColumn As Integer
        If lstviewMonitors.ListViewItemSorter Is Nothing Then
            Me.lstviewMonitors.ListViewItemSorter = New ListViewItemComparer(e.Column, True)
        Else
            CurrColumn = CType(lstviewMonitors.ListViewItemSorter, ListViewItemComparer).Column
            If CurrColumn = e.Column Then
                Me.lstviewMonitors.ListViewItemSorter = New ListViewItemComparer(e.Column, Not (CType(lstviewMonitors.ListViewItemSorter, ListViewItemComparer).SortAscending))
            Else
                Me.lstviewMonitors.ListViewItemSorter = New ListViewItemComparer(e.Column, True)
            End If
        End If
    End Sub

#End Region

#Region "Private Methods"
    Private Overloads Sub LoadMonitors(ByVal PreSelectedMonitorID As Integer)
        'Loads all monitors

        Dim Monitors As New PolyMon.Monitors.MonitorList
        Dim Monitor As PolyMon.Monitors.MonitorMetadata
        Dim ListItem As ListViewItem

        lstviewMonitors.Items.Clear()
        For Each Monitor In Monitors
            ListItem = lstviewMonitors.Items.Add(CStr(Monitor.MonitorID), Monitor.MonitorName, CStr(Nothing))
            ListItem.SubItems.Add(Monitor.MonitorType)
            ListItem.SubItems.Add(CStr(IIf(Monitor.Enabled, "Yes", "No")))
            ListItem.SubItems.Add(CStr(Monitor.TriggerMod))
            ListItem.SubItems.Add(CStr(Monitor.MonitorID))

            If PreSelectedMonitorID > -1 Then
                If Monitor.MonitorID = PreSelectedMonitorID Then
                    'Pre-select this monitor
                    ListItem.Selected = True
                End If
            End If
        Next
    End Sub
    Private Overloads Sub LoadMonitors(ByVal GroupID As Integer, ByVal PreSelectedMonitorID As Integer)
        'Loads all Monitors for specified group
        Dim ListItem As ListViewItem
        lstviewMonitors.Items.Clear()

        Dim PanelGroup As New PolyMon.Dashboard.PanelGroup(GroupID)
        Dim Monitor As PolyMon.Monitors.MonitorMetadata
        For i As Integer = 0 To PanelGroup.Panels.Count - 1
            Monitor = New PolyMon.Monitors.MonitorMetadata(PanelGroup.Panels.Item(i).MonitorID)

            ListItem = lstviewMonitors.Items.Add(CStr(Monitor.MonitorID), Monitor.MonitorName, CStr(Nothing))
            ListItem.SubItems.Add(Monitor.MonitorType)
            ListItem.SubItems.Add(CStr(IIf(Monitor.Enabled, "Yes", "No")))
            ListItem.SubItems.Add(CStr(Monitor.TriggerMod))
            ListItem.SubItems.Add(CStr(Monitor.MonitorID))

            If PreSelectedMonitorID > -1 Then
                If Monitor.MonitorID = PreSelectedMonitorID Then
                    'Pre-select this monitor
                    ListItem.Selected = True
                End If
            End If
        Next
    End Sub
    Private Overloads Sub LoadFilteredMonitors(ByVal GroupID As Integer, ByVal PreSelectedMonitorID As Integer, ByVal IsFiltered As Boolean)
        If Not (IsFiltered) Then
            'Load all monitors
            LoadMonitors(PreSelectedMonitorID)
        Else
            'Load Monitors not in specified Group
            Dim ListItem As ListViewItem
            lstviewMonitors.Items.Clear()

            Dim PanelGroup As New PolyMon.Dashboard.PanelGroup(GroupID)
            Dim AvailMonitors As ReadOnlyCollection(Of PolyMon.Monitors.MonitorMetadata) = PanelGroup.AvailableMonitors()
            Dim Monitor As PolyMon.Monitors.MonitorMetadata

            For Each Monitor In AvailMonitors
                ListItem = lstviewMonitors.Items.Add(CStr(Monitor.MonitorID), Monitor.MonitorName, CStr(Nothing))
                ListItem.SubItems.Add(Monitor.MonitorType)
                ListItem.SubItems.Add(CStr(IIf(Monitor.Enabled, "Yes", "No")))
                ListItem.SubItems.Add(CStr(Monitor.TriggerMod))
                ListItem.SubItems.Add(CStr(Monitor.MonitorID))

                If PreSelectedMonitorID > -1 Then
                    If Monitor.MonitorID = PreSelectedMonitorID Then
                        'Pre-select this monitor
                        ListItem.Selected = True
                    End If
                End If
            Next
        End If
    End Sub

    Private Class ListViewItemComparer
        Implements IComparer

        Private mCol As Integer
        Private mSortAscending As Boolean = True

        Public Sub New()
            mCol = 0
        End Sub

        Public ReadOnly Property Column() As Integer
            Get
                Return mCol
            End Get
        End Property

        Public ReadOnly Property SortAscending() As Boolean
            Get
                Return mSortAscending
            End Get
        End Property

        Public Sub New(ByVal Column As Integer, ByVal SortAscending As Boolean)
            mCol = Column
            mSortAscending = SortAscending
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            If mSortAscending Then
                Return [String].Compare(CType(x, ListViewItem).SubItems(mCol).Text, CType(y, ListViewItem).SubItems(mCol).Text)
            Else
                Return [String].Compare(CType(y, ListViewItem).SubItems(mCol).Text, CType(x, ListViewItem).SubItems(mCol).Text)
            End If
        End Function
    End Class
#End Region


End Class
