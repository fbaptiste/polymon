Imports System.Windows.Forms

Public Class dlgOrderGroups

#Region "Private Attributes"
    Private mOriginalGroups As List(Of UCPanelGroup)
    Private mNewGroups As New List(Of UCPanelGroup)
#End Region

#Region "Public Interface"
    Public Sub New(ByVal Groups As List(Of UCPanelGroup))

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mOriginalGroups = Groups
        LoadGroupList()
    End Sub

    Public ReadOnly Property NewOrderGroups() As List(Of UCPanelGroup)
        Get
            mNewGroups.Clear()
            Dim i As Integer
            For i = 0 To Me.lstGroups.Items.Count - 1
                mNewGroups.Add(CType(lstGroups.Items.Item(i), UCPanelGroup))
            Next
            Return mNewGroups
        End Get
    End Property
#End Region

#Region "Private Methods"
    Private Sub LoadGroupList()
        Me.lstGroups.Items.Clear()

        lstGroups.DisplayMember = "GroupName"
        lstGroups.ValueMember = "GroupID"

        Dim Group As UCPanelGroup
        For Each Group In mOriginalGroups
            lstGroups.Items.Add(Group)
        Next
    End Sub
    Private Sub SaveChanges()
        Dim Group As UCPanelGroup

        Dim DisplayOrder As Integer = 1
        For Each Group In Me.lstGroups.Items
            Group.PanelGroup.DisplayOrder = DisplayOrder
            Group.PanelGroup.Save()
            DisplayOrder += 1
        Next
    End Sub
    Private Sub SwapListItems(ByVal Index1 As Integer, ByVal Index2 As Integer)
        Dim Group As UCPanelGroup

        Group = CType(lstGroups.Items(Index2), UCPanelGroup)

        lstGroups.Items.RemoveAt(Index2)
        lstGroups.Items.Insert(Index1, Group)
        If Index1 < 5 Then
            lstGroups.TopIndex = 0
        Else
            lstGroups.TopIndex = Index1 - 5
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
        If lstGroups.SelectedItems.Count > 0 Then
            'Move currently selected item one up (if possible)
            If lstGroups.SelectedIndex = 0 Then
                Exit Sub
            Else
                'Swap with preceding item
                SwapListItems(lstGroups.SelectedIndex, lstGroups.SelectedIndex - 1)
                lstGroups.Select()
            End If
        End If
    End Sub
    Private Sub btnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDown.Click
        If lstGroups.SelectedItems.Count > 0 Then
            'Move currently selected item one up (if possible)
            If lstGroups.SelectedIndex = lstGroups.Items.Count - 1 Then
                Exit Sub
            Else
                'Swap with preceding item
                SwapListItems(lstGroups.SelectedIndex, lstGroups.SelectedIndex + 1)
                lstGroups.Select()
            End If
        End If
    End Sub
#End Region


End Class
