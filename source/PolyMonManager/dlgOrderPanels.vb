Imports System.Windows.Forms

Public Class dlgOrderPanels

#Region "Private Attributes"
    Private mOriginalPanels As List(Of UCMonitorPanel)
    Private mNewPanels As New List(Of UCMonitorPanel)
#End Region

#Region "Public Interface"
    Public Sub New(ByVal Panels As List(Of UCMonitorPanel))
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadPanelList(Panels)
    End Sub
    Public ReadOnly Property NewOrderPanels() As List(Of UCMonitorPanel)
        Get
            mNewPanels.Clear()
            Dim i As Integer
            For i = 0 To Me.lstPanels.Items.Count - 1
                mNewPanels.Add(CType(lstPanels.Items.Item(i), UCMonitorPanel))
            Next
            Return mNewPanels
        End Get
    End Property
#End Region

#Region "Private Methods"
    Private Sub LoadPanelList(ByVal Panels As List(Of UCMonitorPanel))
        'Dim Panels As PolyMon.Dashboard.MonitorPanels = New PolyMon.Dashboard.MonitorPanels(GroupID)
        Dim Panel As UCMonitorPanel

        Me.lstPanels.Items.Clear()
        lstPanels.DisplayMember = "MonitorName"
        lstPanels.ValueMember = "MonitorID"

        For Each Panel In Panels
            lstPanels.Items.Add(Panel)
        Next
    End Sub
    Private Sub SaveChanges()
        Dim Panel As UCMonitorPanel
        Dim DisplayOrder As Integer = 1
        For Each Panel In lstPanels.Items
            Panel.MonitorPanel.DisplayOrder = DisplayOrder
            Panel.MonitorPanel.Save()
            DisplayOrder += 1
        Next
    End Sub
    Private Sub SwapListItems(ByVal Index1 As Integer, ByVal Index2 As Integer)
        Dim Panel As UCMonitorPanel

        Panel = CType(lstPanels.Items(Index2), UCMonitorPanel)

        lstPanels.Items.RemoveAt(Index2)
        lstPanels.Items.Insert(Index1, Panel)
        If Index1 < 5 Then
            lstPanels.TopIndex = 0
        Else
            lstPanels.TopIndex = Index1 - 5
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        SaveChanges()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveUp.Click
        If lstPanels.SelectedItems.Count > 0 Then
            'Move currently selected item one up (if possible)
            If lstPanels.SelectedIndex = 0 Then
                Exit Sub
            Else
                'Swap with preceding item
                SwapListItems(lstPanels.SelectedIndex, lstPanels.SelectedIndex - 1)
                lstPanels.Select()

            End If
        End If
    End Sub
    Private Sub btnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDown.Click
        If lstPanels.SelectedItems.Count > 0 Then
            'Move currently selected item one up (if possible)
            If lstPanels.SelectedIndex = lstPanels.Items.Count - 1 Then
                Exit Sub
            Else
                'Swap with preceding item
                SwapListItems(lstPanels.SelectedIndex, lstPanels.SelectedIndex + 1)
                lstPanels.Select()
            End If
        End If
    End Sub
#End Region
End Class
