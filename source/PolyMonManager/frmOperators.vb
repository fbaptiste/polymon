Public Class frmOperators

#Region "Private Attributes"
    Private mCurrOperatorEdited As PolyMon.Operators.PMOperator = Nothing
    Private mCurrOperatorIsNew As Boolean = False
#End Region

#Region "Public Interface"
    Public Sub New()
        InitializeComponent()
        InitForm()
        If (tscOperators.Items.Count = 0) Then
            SetEditState(False)
        Else
            SetEditState(True)
        End If
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub tscOperators_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscOperators.SelectedIndexChanged
        errSummary.Clear()
        ClearOperatorEditorFields()
        mCurrOperatorIsNew = False
        mCurrOperatorEdited = CType(Me.tscOperators.SelectedItem, PolyMon.Operators.PMOperator)
        If (mCurrOperatorEdited IsNot Nothing) Then
            With mCurrOperatorEdited
                Me.chkEnabled.Checked = .IsEnabled
                Me.txtName.Text = .Name
                Me.txtEmailAddress.Text = .EmailAddress
                Me.cboStartHour.Text = .OfflineTime.StartTime.Split(CChar(":"))(0)
                Me.cboStartMinute.Text = .OfflineTime.StartTime.Split(CChar(":"))(1)
                Me.cboEndHour.Text = .OfflineTime.EndTime.Split(CChar(":"))(0)
                Me.cboEndMinute.Text = .OfflineTime.EndTime.Split(CChar(":"))(1)
                Me.chkIncludeMessageBody.Checked = .IncludeMessageBody
                Me.cboQueuedNotify.SelectedIndex = .QueuedNotify
                Me.chkSummaryNotify.Checked = .SummaryNotify
                Me.chkSummaryOK.Checked = .SummaryNotifyOK
                Me.chkSummaryWarn.Checked = .SummaryNotifyWarn
                Me.chkSummaryFail.Checked = .SummaryNotifyFail
                Me.cboSummaryNotifyHour.Text = .SummaryNotifyTime.Split(CChar(":"))(0)
                Me.cboSummaryNotifyMinute.Text = .SummaryNotifyTime.Split(CChar(":"))(1)
            End With
            pnlOperatorID.Visible = True
            lblID.Text = mCurrOperatorEdited.OperatorID.ToString
        Else
            pnlOperatorID.Visible = False
        End If
        If ((Me.cboStartHour.Text = "00") And (Me.cboStartMinute.Text = "00") And (Me.cboEndHour.Text = "00") And (Me.cboEndMinute.Text = "00")) Then
            radAlwaysAvailable.Checked = True
        Else
            radOffline.Checked = True
        End If
        SetEditState(True)
    End Sub
    Private Sub tsbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNew.Click
        errSummary.Clear()
        Me.tscOperators.SelectedIndex = -1
        ClearOperatorEditorFields()
        mCurrOperatorIsNew = True
        mCurrOperatorEdited = New PolyMon.Operators.PMOperator()
        ResetOfflineTime()
        SetEditState(True)
        Me.txtName.Focus()
    End Sub
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        errSummary.Clear()
        If (Not IsFormValid()) Then Exit Sub
        'reset offline time if they are marked as always available
        If (radAlwaysAvailable.Checked) Then
            ResetOfflineTime()
        End If
        Try
            With mCurrOperatorEdited
                .IsEnabled = Me.chkEnabled.Checked
                .Name = Me.txtName.Text.Trim()
                .EmailAddress = Me.txtEmailAddress.Text.Trim()
                .OfflineTime.StartTime = Me.cboStartHour.Text & ":" & Me.cboStartMinute.Text
                .OfflineTime.EndTime = Me.cboEndHour.Text & ":" & Me.cboEndMinute.Text
                .IncludeMessageBody = Me.chkIncludeMessageBody.Checked
                .QueuedNotify = CType(Me.cboQueuedNotify.SelectedIndex, PolyMon.Operators.PMOperator.QueuedNotifyFlags)
                .SummaryNotify = Me.chkSummaryNotify.Checked
                .SummaryNotifyOK = Me.chkSummaryOK.Checked
                .SummaryNotifyWarn = Me.chkSummaryWarn.Checked
                .SummaryNotifyFail = Me.chkSummaryFail.Checked
                .SummaryNotifyTime = Me.cboSummaryNotifyHour.Text & ":" & Me.cboSummaryNotifyMinute.Text
                .Save()
            End With
            mCurrOperatorIsNew = False
            LoadOperators(mCurrOperatorEdited.OperatorID)
        Catch ex As Exception
            MsgBox("Error occurred while saving Operator:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error...")
        End Try
        SetEditState(True)
    End Sub
    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click
        errSummary.Clear()
        If Me.mCurrOperatorIsNew Then
            'Since this has not been saved yet, simply act like a cancel
            LoadOperators()
            SetEditState(False)
        Else
            If mCurrOperatorEdited Is Nothing Then
                ClearOperatorEditorFields()
                SetEditState(False)
            Else
                Dim ret As MsgBoxResult = MsgBox("You are about to delete an existing Operator." & vbCrLf & "Please note that this will delete the operator and ALL monitor associations." & vbCrLf & "Do you wish to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Delete Operator?")
                If ret = MsgBoxResult.Yes Then
                    Try
                        Me.mCurrOperatorEdited.Delete()
                        LoadOperators()
                        If (tscOperators.Items.Count = 0) Then
                            SetEditState(False)
                        Else
                            SetEditState(True)
                        End If
                    Catch ex As Exception
                        MsgBox("Error occurred deleting Operator." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error...")
                    End Try
                Else
                    SetEditState(True)
                End If
            End If
        End If
    End Sub
    Private Sub tsbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancel.Click
        'if we are cancelling the form from when a new user was being entered, then do this...
        If (Me.mCurrOperatorIsNew) Then
            'load operators, which will pick the first one in the list to display by default
            LoadOperators()
        End If
        'if we are cancelling while an existing user was selected, do this...
        If mCurrOperatorEdited Is Nothing Then
            ClearOperatorEditorFields()
            SetEditState(False)
        Else
            'reload the user, so all settings are reset
            LoadOperators(Me.mCurrOperatorEdited.OperatorID)
            SetEditState(True)
        End If
    End Sub
    Private Sub chkSummaryNotify_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSummaryNotify.CheckedChanged
        errSummary.Clear()
        Me.gbNotificationSettings.Enabled = Me.chkSummaryNotify.Checked
    End Sub
    Private Sub radAlwaysAvailable_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radAlwaysAvailable.CheckedChanged
        errSummary.Clear()
        Me.pnlOfflineTime.Enabled = False
    End Sub
    Private Sub radOffline_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radOffline.CheckedChanged
        errSummary.Clear()
        Me.pnlOfflineTime.Enabled = True
    End Sub
#End Region

#Region "Private Methods"
    Private Sub InitForm()
        'Init Toolstrip Combo Box
        Dim cb As ComboBox = CType(Me.tscOperators.Control, ComboBox)
        cb.Items.Clear()
        cb.DisplayMember = "Name"
        cb.ValueMember = "OperatorID"

        'Init Offline Time Drop-Downs, Summary Notify Drop-Downs
        Dim i As Integer
        Dim cbHStart As ComboBox = CType(Me.cboStartHour, ComboBox)
        Dim cbMStart As ComboBox = CType(Me.cboStartMinute, ComboBox)
        Dim cbHEnd As ComboBox = CType(Me.cboEndHour, ComboBox)
        Dim cbMEnd As ComboBox = CType(Me.cboEndMinute, ComboBox)
        Dim cbSummaryH As ComboBox = CType(Me.cboSummaryNotifyHour, ComboBox)
        Dim cbSummaryM As ComboBox = CType(Me.cboSummaryNotifyMinute, ComboBox)

        cbHStart.Items.Clear()
        cbMStart.Items.Clear()
        cbHEnd.Items.Clear()
        cbMEnd.Items.Clear()
        cbSummaryH.Items.Clear()
        cbSummaryM.Items.Clear()
        For i = 0 To 23
            cbHStart.Items.Add(Format(i, "00"))
            cbHEnd.Items.Add(Format(i, "00"))
            cbSummaryH.Items.Add(Format(i, "00"))
        Next

        For i = 0 To 59 Step 10
            cbMStart.Items.Add(Format(i, "00"))
            cbMEnd.Items.Add(Format(i, "00"))
            cbSummaryM.Items.Add(Format(i, "00"))
        Next

        'Init Queued Notify Drop-Down
        Me.cboQueuedNotify.Items.Clear()
        Me.cboQueuedNotify.Items.Add("Do not send Queued Alerts")
        Me.cboQueuedNotify.Items.Add("Send all Queued Alerts")
        Me.cboQueuedNotify.Items.Add("Send Alert Recap Only")
        LoadOperators()

        Me.chkSummaryNotify.Checked = False
        Me.chkSummaryOK.Checked = False
        Me.chkSummaryWarn.Checked = False
        Me.chkSummaryFail.Checked = False
        Me.gbNotificationSettings.Enabled = False
        Me.cboSummaryNotifyHour.SelectedIndex = 8
        Me.cboSummaryNotifyMinute.SelectedIndex = 0
    End Sub
    Private Sub ClearOperatorEditorFields()
        Me.mCurrOperatorEdited = Nothing
        Me.mCurrOperatorIsNew = False

        Me.chkEnabled.Checked = False
        Me.txtName.Text = Nothing
        Me.txtEmailAddress.Text = Nothing

        'Added code to init starts/end hours for offline times so they aren't blank at startup
        Me.cboStartHour.SelectedIndex = 0
        Me.cboStartMinute.SelectedIndex = 0
        Me.cboEndHour.SelectedIndex = 0
        Me.cboEndMinute.SelectedIndex = 0
        Me.radAlwaysAvailable.Checked = True

        Me.chkIncludeMessageBody.Checked = False
        Me.cboQueuedNotify.SelectedIndex = 0

        Me.chkSummaryNotify.Checked = False
        Me.chkSummaryOK.Checked = False
        Me.chkSummaryWarn.Checked = False
        Me.chkSummaryFail.Checked = False
        Me.gbNotificationSettings.Enabled = False
        Me.cboSummaryNotifyHour.SelectedIndex = 8
        Me.cboSummaryNotifyMinute.SelectedIndex = 0
    End Sub
    Private Sub LoadOperators(Optional ByVal OperatorID As Integer = -1)
        'Reset info
        ClearOperatorEditorFields()
        'Load Operators
        Me.tscOperators.Items.Clear()
        Dim PMOperators As New PolyMon.Operators.PMOperators
        Dim PMOperator As PolyMon.Operators.PMOperator
        For Each PMOperator In PMOperators
            Me.tscOperators.Items.Add(PMOperator)
        Next
        'Preselect Monitor Type if applicable
        If OperatorID > 0 Then
            For Each PMOperator In Me.tscOperators.Items
                If PMOperator.OperatorID = OperatorID Then
                    tscOperators.SelectedItem = PMOperator
                    Exit For
                End If
            Next
        End If
        'Load the first operator if there isn't one already selected
        If ((OperatorID <= 0) And (tscOperators.Items.Count > 0)) Then
            If (tscOperators.SelectedIndex = -1) Then
                tscOperators.SelectedIndex = 0
                pnlOperator.Enabled = True
            End If
        End If
    End Sub
    Private Sub SetEditState(ByVal AllowEdits As Boolean)
        Me.chkEnabled.Enabled = AllowEdits
        Me.txtName.Enabled = AllowEdits
        Me.txtEmailAddress.Enabled = AllowEdits
        Me.cboStartHour.Enabled = AllowEdits
        Me.cboStartMinute.Enabled = AllowEdits
        Me.cboEndHour.Enabled = AllowEdits
        Me.cboEndMinute.Enabled = AllowEdits
        Me.chkIncludeMessageBody.Enabled = AllowEdits

        Me.tsbSave.Enabled = AllowEdits
        Me.tsbCancel.Enabled = AllowEdits
        Me.tsbDelete.Enabled = AllowEdits

        Me.cboQueuedNotify.Enabled = AllowEdits

        Me.chkSummaryNotify.Enabled = AllowEdits
        Me.gbNotificationSettings.Enabled = AllowEdits And Me.chkSummaryNotify.Checked

        Me.pnlOperator.Enabled = AllowEdits
    End Sub
    Private Function IsFormValid() As Boolean
        Dim bIsValid As Boolean = True
        If (mCurrOperatorEdited IsNot Nothing) Then
            bIsValid = CBool(IIf(mCurrOperatorEdited Is Nothing, False, True))
        End If
        'validate name field
        If (String.IsNullOrEmpty(txtName.Text)) Then
            errSummary.SetError(Me.txtName, "You must provide a valid name.")
            bIsValid = False
        End If
        'validate email address field
        If ((String.IsNullOrEmpty(txtEmailAddress.Text)) Or (Not PolyMon.Tools.IsEmailValid(txtEmailAddress.Text))) Then
            errSummary.SetError(Me.txtEmailAddress, "You must provide a valid email address.")
            bIsValid = False
        End If

        Return bIsValid
    End Function
    Private Sub ResetOfflineTime()
        If (Me.cboStartHour.Items.Count > 0) Then
            Me.cboStartHour.Text = "00"
            Me.cboStartMinute.Text = "00"
            Me.cboEndHour.Text = "00"
            Me.cboEndMinute.Text = "00"
        End If
    End Sub
#End Region

End Class