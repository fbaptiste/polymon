<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEventHistory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEventHistory))
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.dgvResults = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkInclFail = New System.Windows.Forms.CheckBox()
        Me.chkInclWarning = New System.Windows.Forms.CheckBox()
        Me.chkInclOK = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpTPHi = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTPLo = New System.Windows.Forms.DateTimePicker()
        Me.cboTP = New System.Windows.Forms.ComboBox()
        Me.radCustom = New System.Windows.Forms.RadioButton()
        Me.radPreset = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "PolyMon.chm"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnRunReport)
        Me.Panel1.Controls.Add(Me.dgvResults)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(673, 565)
        Me.Panel1.TabIndex = 5
        '
        'btnRunReport
        '
        Me.btnRunReport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRunReport.Location = New System.Drawing.Point(434, 37)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(86, 22)
        Me.btnRunReport.TabIndex = 6
        Me.btnRunReport.Text = "Run Report"
        Me.btnRunReport.UseVisualStyleBackColor = True
        '
        'dgvResults
        '
        Me.dgvResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResults.BackgroundColor = System.Drawing.Color.White
        Me.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResults.Location = New System.Drawing.Point(0, 107)
        Me.dgvResults.Name = "dgvResults"
        Me.dgvResults.Size = New System.Drawing.Size(673, 452)
        Me.dgvResults.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkInclFail)
        Me.GroupBox1.Controls.Add(Me.chkInclWarning)
        Me.GroupBox1.Controls.Add(Me.chkInclOK)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(94, 96)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Statuses"
        '
        'chkInclFail
        '
        Me.chkInclFail.AutoSize = True
        Me.chkInclFail.Checked = True
        Me.chkInclFail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInclFail.Location = New System.Drawing.Point(12, 69)
        Me.chkInclFail.Name = "chkInclFail"
        Me.chkInclFail.Size = New System.Drawing.Size(57, 17)
        Me.chkInclFail.TabIndex = 2
        Me.chkInclFail.Text = "Failure"
        Me.chkInclFail.UseVisualStyleBackColor = True
        '
        'chkInclWarning
        '
        Me.chkInclWarning.AutoSize = True
        Me.chkInclWarning.Checked = True
        Me.chkInclWarning.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInclWarning.Location = New System.Drawing.Point(12, 46)
        Me.chkInclWarning.Name = "chkInclWarning"
        Me.chkInclWarning.Size = New System.Drawing.Size(66, 17)
        Me.chkInclWarning.TabIndex = 1
        Me.chkInclWarning.Text = "Warning"
        Me.chkInclWarning.UseVisualStyleBackColor = True
        '
        'chkInclOK
        '
        Me.chkInclOK.AutoSize = True
        Me.chkInclOK.Location = New System.Drawing.Point(12, 23)
        Me.chkInclOK.Name = "chkInclOK"
        Me.chkInclOK.Size = New System.Drawing.Size(41, 17)
        Me.chkInclOK.TabIndex = 0
        Me.chkInclOK.Text = "OK"
        Me.chkInclOK.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpTPHi)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtpTPLo)
        Me.GroupBox2.Controls.Add(Me.cboTP)
        Me.GroupBox2.Controls.Add(Me.radCustom)
        Me.GroupBox2.Controls.Add(Me.radPreset)
        Me.GroupBox2.Location = New System.Drawing.Point(112, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(303, 82)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Timeframe"
        '
        'dtpTPHi
        '
        Me.dtpTPHi.Location = New System.Drawing.Point(169, 51)
        Me.dtpTPHi.Name = "dtpTPHi"
        Me.dtpTPHi.Size = New System.Drawing.Size(109, 20)
        Me.dtpTPHi.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(147, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "to"
        '
        'dtpTPLo
        '
        Me.dtpTPLo.Location = New System.Drawing.Point(32, 51)
        Me.dtpTPLo.Name = "dtpTPLo"
        Me.dtpTPLo.Size = New System.Drawing.Size(109, 20)
        Me.dtpTPLo.TabIndex = 3
        '
        'cboTP
        '
        Me.cboTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTP.FormattingEnabled = True
        Me.cboTP.Location = New System.Drawing.Point(32, 19)
        Me.cboTP.Name = "cboTP"
        Me.cboTP.Size = New System.Drawing.Size(210, 21)
        Me.cboTP.TabIndex = 2
        '
        'radCustom
        '
        Me.radCustom.AutoSize = True
        Me.radCustom.Location = New System.Drawing.Point(10, 55)
        Me.radCustom.Name = "radCustom"
        Me.radCustom.Size = New System.Drawing.Size(14, 13)
        Me.radCustom.TabIndex = 1
        Me.radCustom.UseVisualStyleBackColor = True
        '
        'radPreset
        '
        Me.radPreset.AutoSize = True
        Me.radPreset.Checked = True
        Me.radPreset.Location = New System.Drawing.Point(10, 23)
        Me.radPreset.Name = "radPreset"
        Me.radPreset.Size = New System.Drawing.Size(14, 13)
        Me.radPreset.TabIndex = 0
        Me.radPreset.TabStop = True
        Me.radPreset.UseVisualStyleBackColor = True
        '
        'frmEventHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 565)
        Me.Controls.Add(Me.Panel1)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "14")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEventHistory"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Event History"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnRunReport As System.Windows.Forms.Button
    Friend WithEvents dgvResults As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkInclFail As System.Windows.Forms.CheckBox
    Friend WithEvents chkInclWarning As System.Windows.Forms.CheckBox
    Friend WithEvents chkInclOK As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpTPHi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTPLo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTP As System.Windows.Forms.ComboBox
    Friend WithEvents radCustom As System.Windows.Forms.RadioButton
    Friend WithEvents radPreset As System.Windows.Forms.RadioButton
End Class
