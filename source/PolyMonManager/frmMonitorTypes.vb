Public Class frmMonitorTypes

#Region "Private Attributes"
    Private mCurrMonitorTypeEdited As PolyMon.MonitorTypes.MonitorType = Nothing
    Private mCurrMonitorTypeIsNew As Boolean = False
#End Region

#Region "Public Interface"
    Public Sub New()
        InitializeComponent()
        InitForm()
        SetEditState(False)
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub tscMonitorTypes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscMonitorTypes.SelectedIndexChanged
        ClearMonitorTypeEditorFields()
        mCurrMonitorTypeIsNew = False
        mCurrMonitorTypeEdited = CType(tscMonitorTypes.SelectedItem, PolyMon.MonitorTypes.MonitorType)
        With mCurrMonitorTypeEdited
            Me.txtName.Text = .Name
            Me.txtMonitorAssembly.Text = .MonitorAssembly
            Me.txtEditorAssembly.Text = .EditorAssembly
            Me.txtXMLTemplate.Text = .XMLTemplate
        End With
        SetEditState(True)
    End Sub
    Private Sub tsbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNew.Click
        ClearMonitorTypeEditorFields()
        mCurrMonitorTypeIsNew = True
        mCurrMonitorTypeEdited = New PolyMon.MonitorTypes.MonitorType()
        SetEditState(True)
    End Sub
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        If mCurrMonitorTypeEdited Is Nothing Then Exit Sub
        Try
            With mCurrMonitorTypeEdited
                .Name = Me.txtName.Text.Trim()
                .MonitorAssembly = Me.txtMonitorAssembly.Text.Trim()
                .EditorAssembly = Me.txtEditorAssembly.Text.Trim()
                .XMLTemplate = Me.txtXMLTemplate.Text.Trim()
                .Save()
            End With
            mCurrMonitorTypeIsNew = False
            LoadMonitorTypes(mCurrMonitorTypeEdited.MonitorTypeID)
        Catch ex As Exception
            MsgBox("Error occurred while saving Monitor Type:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error...")
        End Try
        SetEditState(True)
    End Sub
    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click
        If Me.mCurrMonitorTypeIsNew Then
            'Since this has not been saved yet, simply act like a cancel
            LoadMonitorTypes()
            SetEditState(False)
        Else
            If mCurrMonitorTypeEdited Is Nothing Then
                ClearMonitorTypeEditorFields()
                SetEditState(False)
            Else
                Dim ret As MsgBoxResult = MsgBox("You are about to delete an existing Monitor Type." & vbCrLf & "Please note that this will delete the monitor type and ALL associated Monitors." & vbCrLf & "Do you wish to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Delete Monitor Type?")
                If ret = MsgBoxResult.Yes Then
                    Try
                        Me.mCurrMonitorTypeEdited.Delete()
                        LoadMonitorTypes()
                        SetEditState(False)
                    Catch ex As Exception
                        MsgBox("Error occurred deleting Monitor Type." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error...")
                    End Try
                End If
            End If
        End If
    End Sub
    Private Sub tsbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancel.Click
        If Me.mCurrMonitorTypeIsNew Then
            LoadMonitorTypes()
            SetEditState(False)
        Else
            If mCurrMonitorTypeEdited Is Nothing Then
                ClearMonitorTypeEditorFields()
                SetEditState(False)
            Else
                LoadMonitorTypes(Me.mCurrMonitorTypeEdited.MonitorTypeID)
                SetEditState(True)
            End If
        End If
    End Sub
#End Region

#Region "Private Methods"
    Private Sub InitForm()
        'Init Monitor Type Toolstrip Combo Box
        Dim cb1 As ComboBox = CType(Me.tscMonitorTypes.Control, ComboBox)
        cb1.Items.Clear()
        cb1.DisplayMember = "Name"
        cb1.ValueMember = "MonitorTypeID"

        LoadMonitorTypes()

        SetEditState(False)
    End Sub
    Private Sub ClearMonitorTypeEditorFields()
        Me.mCurrMonitorTypeEdited = Nothing
        Me.mCurrMonitorTypeIsNew = False

        Me.txtName.Text = Nothing
        Me.txtMonitorAssembly.Text = Nothing
        Me.txtEditorAssembly.Text = Nothing
        Me.txtXMLTemplate.Text = Nothing
    End Sub
    Private Sub LoadMonitorTypes(Optional ByVal MonitorTypeID As Integer = -1)
        'Reset info
        ClearMonitorTypeEditorFields()

        'Load Monitor Types
        Me.tscMonitorTypes.Items.Clear()
        Dim MTypes As New PolyMon.MonitorTypes.MonitorTypes
        Dim MType As PolyMon.MonitorTypes.MonitorType

        For Each MType In MTypes
            Me.tscMonitorTypes.Items.Add(MType)
        Next

        'Preselect Monitor Type if applicable
        If MonitorTypeID > 0 Then
            For Each MType In tscMonitorTypes.Items
                If MType.MonitorTypeID = MonitorTypeID Then
                    tscMonitorTypes.SelectedItem = MType
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub SetEditState(ByVal AllowEdits As Boolean)
        Me.txtName.Enabled = AllowEdits
        Me.txtMonitorAssembly.Enabled = AllowEdits
        Me.txtEditorAssembly.Enabled = AllowEdits
        Me.txtXMLTemplate.Enabled = AllowEdits

        Me.tsbSave.Enabled = AllowEdits
        Me.tsbCancel.Enabled = AllowEdits
        Me.tsbDelete.Enabled = AllowEdits
    End Sub
#End Region


End Class