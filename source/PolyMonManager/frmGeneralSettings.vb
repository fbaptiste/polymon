Imports System.Drawing
Imports System.Data.sqlclient

Public Class frmGeneralSettings

#Region "Private Attributes"
	Private mSysSettings As PolyMon.General.SysSettings
	Private mRetentionSettings As PolyMon.General.DefaultRetentionSettings
    Private mUserSettings As New UserSettings
#End Region

#Region "Event Handlers"
    Private Sub frmGeneralSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Populate Color Pick List with known colors
        cboMDIBackColor.Items.Clear()
        Dim ColName As String
        For Each ColName In System.Enum.GetNames(GetType(KnownColor))
            Me.cboMDIBackColor.Items.Add(ColName)
        Next

        'Load System Settings
        If mSysSettings Is Nothing Then LoadSysSettings()

        'Load User Settings
        LoadUserSettings()
    End Sub
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Me.Cursor = Cursors.WaitCursor
        SaveSysSettings()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tsbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancel.Click
        Me.Cursor = Cursors.WaitCursor
        LoadSysSettings()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboTimerIntervals_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTimerIntervals.SelectedIndexChanged
        Dim myTimerInterval As UserSettings.TimerInterval = CType(Me.cboTimerIntervals.SelectedItem, UserSettings.TimerInterval)
        mUserSettings.RefreshIntervalIndex = Me.cboTimerIntervals.SelectedIndex
        CType(Me.MdiParent, frmMain).SetTimerInterval()
    End Sub
    Private Sub chkAudioAlert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAudioAlert.CheckedChanged
        Me.mUserSettings.AudibleAlertsEnabled = Me.chkAudioAlert.Checked
    End Sub
    Private Sub chkBalloonAlerts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBalloonAlerts.CheckedChanged
        Me.mUserSettings.BalloonAlertsEnabled = Me.chkBalloonAlerts.Checked
    End Sub
    Private Sub cboMDIBackColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMDIBackColor.SelectedIndexChanged
        Dim NewColor As Color
        NewColor = Color.FromName(CStr(cboMDIBackColor.SelectedItem))
        mUserSettings.MDIBackColor = NewColor
        'Change MDI form background color
        Dim c As Control
        For Each c In Me.ParentForm.Controls
            If c.GetType.Name = "MdiClient" Then
                c.BackColor = NewColor
                Exit For
            End If
        Next
	End Sub

	Private Sub btnSendTestMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendTestMail.Click
		'First get TO email address from user
		Dim EmailTO As String = Nothing

		EmailTO = InputBox("Please enter recipient's email address.", "PolyMon - Email Notifier Tester")
		If String.IsNullOrEmpty(EmailTO) Then
			MsgBox("Message was not sent - Email address was blank or cancelled")
		Else
			Try
				Dim PolyMonMail As New PolyMon.Notifier.PolyMonMailer()
				PolyMonMail.SendMail(EmailTO, Nothing, "PolyMon - Test", "PolyMon Test" & vbCrLf & "Please ignore.", False)
			Catch ex As Exception
				MsgBox("An error occurred sending email." & vbCrLf & ex.ToString(), MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Polymon - Email Notifier Error")
			End Try
		End If
	End Sub

	Private Sub trRaw_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trRaw.ValueChanged
		Me.lblRaw.Text = String.Format("{0} Months", trRaw.Value.ToString())
		If trDaily.Value < trRaw.Value Then trDaily.Value = trRaw.Value
	End Sub
	Private Sub trDaily_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trDaily.ValueChanged
		Me.lblDaily.Text = String.Format("{0} Months", trDaily.Value.ToString())
		If trWeekly.Value < trDaily.Value Then trWeekly.Value = trDaily.Value
		If trDaily.Value < trRaw.Value Then trDaily.Value = trRaw.Value
	End Sub
	Private Sub trWeekly_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trWeekly.ValueChanged
		Me.lblWeekly.Text = String.Format("{0} Months", trWeekly.Value.ToString())
		If trMonthly.Value < trWeekly.Value Then trMonthly.Value = trWeekly.Value
		If trWeekly.Value < trDaily.Value Then trWeekly.Value = trDaily.Value
	End Sub
	Private Sub trMonthly_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trMonthly.ValueChanged
		Me.lblMonthly.Text = String.Format("{0} Months", trMonthly.Value.ToString())
		If trMonthly.Value < trWeekly.Value Then trMonthly.Value = trWeekly.Value
    End Sub

    Private Sub tsbSaveRetentionScheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSaveRetentionScheme.Click
        Me.Cursor = Cursors.WaitCursor
        SaveRetentionSettings()
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Private Methods"
    Private Sub LoadSysSettings()
        Try
            mSysSettings = New PolyMon.General.SysSettings
            With mSysSettings
                Me.chkSysEnabled.Checked = .IsEnabled
                Me.txtSysName.Text = .Name
                Me.txtSysServiceServer.Text = .ServiceServer
                Me.udSysMainTimerInterval.Value = .MainTimerInterval
                Me.txtSysSMTPServer.Text = .ExtSMTPServer
                Me.upSysSMTPPort.Value = .ExtSMTPPort
                Me.txtSysSMTPUserID.Text = .ExtSMTPUserID
                Me.txtSysSMTPPwd.Text = .ExtSMTPPwd
                Me.txtSysSMTPFromName.Text = .SMTPFromName
				Me.txtSysSMTPFromAddress.Text = .SMTPFromAddress
				Me.chkSysSMTPUseSSL.Checked = .ExtSMTPUseSSL
			End With

			mRetentionSettings = New PolyMon.General.DefaultRetentionSettings
			With mRetentionSettings
				Me.trMonthly.Value = .Monthly
				Me.trWeekly.Value = .Weekly
				Me.trDaily.Value = .Daily
				Me.trRaw.Value = .Raw
			End With
        Catch ex As Exception
            MsgBox("Error retrieving data from database:" & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.InnerException.Message, MsgBoxStyle.Exclamation, "PolyMon Error")
        End Try
    End Sub
    Private Sub SaveSysSettings()
        Try
            With mSysSettings
                .Name = Me.txtSysName.Text
                .IsEnabled = Me.chkSysEnabled.Checked
                .ServiceServer = Me.txtSysServiceServer.Text
                .MainTimerInterval = CInt(Me.udSysMainTimerInterval.Value)
				.UseInternalSMTP = False 'For now we do not have an embedded SMTP service

				.SetExtSMTP(Me.txtSysSMTPServer.Text, CInt(Me.upSysSMTPPort.Value), Me.txtSysSMTPUserID.Text, Me.txtSysSMTPPwd.Text, Me.chkSysSMTPUseSSL.Checked)
                .SetSMTPFrom(Me.txtSysSMTPFromName.Text, Me.txtSysSMTPFromAddress.Text)

                .Save()
            End With
        Catch ex As Exception
            If ex.InnerException Is Nothing Then
                MsgBox("Error Saving Settings:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "PolyMon Error")
            Else
                MsgBox("Error Saving Settings:" & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.InnerException.Message, MsgBoxStyle.Exclamation, "PolyMon Error")
            End If

        End Try
    End Sub
	Private Sub SaveRetentionSettings()
		Try
			With mRetentionSettings
				.Raw = trRaw.Value
				.Daily = trDaily.Value
				.Weekly = trWeekly.Value
				.Monthly = trMonthly.Value

				.Save()
			End With
		Catch ex As Exception
			MsgBox("Error Saving Retention Settings:" & vbCrLf & ex.ToString(), MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		End Try
	End Sub
    Private Sub LoadUserSettings()
        Dim Interval As UserSettings.TimerInterval
        With Me.cboTimerIntervals
            .DisplayMember = "Name"
            .ValueMember = "Interval"
            .Items.Clear()
            For Each Interval In mUserSettings.RefreshIntervals
                .Items.Add(Interval)
            Next

            'Pre-select current value
            .SelectedIndex = mUserSettings.RefreshIntervalIndex
        End With

        'Set Audio On/Off
        Me.chkAudioAlert.Checked = mUserSettings.AudibleAlertsEnabled

        'Set Balloon On/Off
        Me.chkBalloonAlerts.Checked = mUserSettings.BalloonAlertsEnabled

        'MDI Back Color
        Me.cboMDIBackColor.Text = mUserSettings.MDIBackColor.Name
    End Sub
#End Region



	''Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
	''	If TabControl1.SelectedTab Is Me.tpDBSettings Then
	''		'Refresh Database Connection info
	''		Dim ManagerConnString As String = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

	''		Me.lblServer_Manager.Text = Nothing
	''		Me.lblDatabase_Manager.Text = Nothing
	''		Me.chkIntegratedSecurity_Manager.Checked = False
	''		Me.lblUserID_Manager.Text = Nothing
	''		Me.lblPassword_Manager.Text = Nothing

	''		If Not String.IsNullOrEmpty(ManagerConnString) Then
	''			Try
	''				Dim Conn As New SqlConnectionStringBuilder(ManagerConnString)

	''				Me.lblServer_Manager.Text = Conn.DataSource
	''				Me.lblDatabase_Manager.Text = Conn.InitialCatalog
	''				Me.chkIntegratedSecurity_Manager.Checked = Conn.IntegratedSecurity
	''				If Not (Conn.IntegratedSecurity) Then
	''					Me.lblUserID_Manager.Text = Conn.UserID
	''					Me.lblPassword_Manager.Text = Conn.Password
	''				End If

	''				pcbStatus_Manager.Image = Me.imglstStatus.Images(0)
	''			Catch ex As Exception
	''				pcbStatus_Manager.Image = Me.imglstStatus.Images(1)
	''				lblStatus_Manager.Text = ex.Message
	''			End Try

	''			'Refresh PolyMon Executive
	''		End If
	''	End If
	''End Sub
End Class