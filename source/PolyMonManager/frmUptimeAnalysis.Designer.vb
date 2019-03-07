<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUptimeAnalysis
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUptimeAnalysis))
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.chkIncludeLifetime = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.dgvResults = New System.Windows.Forms.DataGridView()
        Me.cboTP = New System.Windows.Forms.ComboBox()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.radPresetTP = New System.Windows.Forms.RadioButton()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.radCustomTP = New System.Windows.Forms.RadioButton()
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "polymon.chm"
        '
        'chkIncludeLifetime
        '
        Me.chkIncludeLifetime.AutoSize = True
        Me.chkIncludeLifetime.Location = New System.Drawing.Point(127, 70)
        Me.chkIncludeLifetime.Name = "chkIncludeLifetime"
        Me.chkIncludeLifetime.Size = New System.Drawing.Size(136, 17)
        Me.chkIncludeLifetime.TabIndex = 17
        Me.chkIncludeLifetime.Text = "Include Lifetime Uptime"
        Me.chkIncludeLifetime.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Time Period"
        '
        'btnRunReport
        '
        Me.btnRunReport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRunReport.Location = New System.Drawing.Point(403, 32)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(86, 22)
        Me.btnRunReport.TabIndex = 16
        Me.btnRunReport.Text = "Run Report"
        Me.btnRunReport.UseVisualStyleBackColor = True
        '
        'dtpStart
        '
        Me.dtpStart.Location = New System.Drawing.Point(127, 32)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(90, 20)
        Me.dtpStart.TabIndex = 10
        '
        'dgvResults
        '
        Me.dgvResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResults.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResults.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvResults.Location = New System.Drawing.Point(0, 96)
        Me.dgvResults.Name = "dgvResults"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResults.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvResults.Size = New System.Drawing.Size(699, 345)
        Me.dgvResults.TabIndex = 18
        '
        'cboTP
        '
        Me.cboTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTP.FormattingEnabled = True
        Me.cboTP.Location = New System.Drawing.Point(127, 5)
        Me.cboTP.Name = "cboTP"
        Me.cboTP.Size = New System.Drawing.Size(147, 21)
        Me.cboTP.TabIndex = 15
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(223, 36)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(16, 13)
        Me.lblTo.TabIndex = 11
        Me.lblTo.Text = "to"
        '
        'radPresetTP
        '
        Me.radPresetTP.AutoSize = True
        Me.radPresetTP.Location = New System.Drawing.Point(107, 8)
        Me.radPresetTP.Name = "radPresetTP"
        Me.radPresetTP.Size = New System.Drawing.Size(14, 13)
        Me.radPresetTP.TabIndex = 14
        Me.radPresetTP.TabStop = True
        Me.radPresetTP.UseVisualStyleBackColor = True
        '
        'dtpEnd
        '
        Me.dtpEnd.Location = New System.Drawing.Point(245, 32)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(90, 20)
        Me.dtpEnd.TabIndex = 12
        '
        'radCustomTP
        '
        Me.radCustomTP.AutoSize = True
        Me.radCustomTP.Location = New System.Drawing.Point(107, 36)
        Me.radCustomTP.Name = "radCustomTP"
        Me.radCustomTP.Size = New System.Drawing.Size(14, 13)
        Me.radCustomTP.TabIndex = 13
        Me.radCustomTP.TabStop = True
        Me.radCustomTP.UseVisualStyleBackColor = True
        '
        'frmUptimeAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(699, 446)
        Me.Controls.Add(Me.chkIncludeLifetime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRunReport)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.dgvResults)
        Me.Controls.Add(Me.cboTP)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.radPresetTP)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.radCustomTP)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "13")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUptimeAnalysis"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "System Health"
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents chkIncludeLifetime As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRunReport As System.Windows.Forms.Button
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvResults As System.Windows.Forms.DataGridView
    Friend WithEvents cboTP As System.Windows.Forms.ComboBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents radPresetTP As System.Windows.Forms.RadioButton
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents radCustomTP As System.Windows.Forms.RadioButton
End Class
