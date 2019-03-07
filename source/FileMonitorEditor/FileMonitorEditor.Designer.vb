<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileMonitorEditor
    Inherits PolyMon.MonitorEditors.GenericMonitorEditor

    'UserControl1 overrides dispose to clean up the component list.
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
		Me.txtDirPath = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.txtFilePattern = New System.Windows.Forms.TextBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.chkMaxCount = New System.Windows.Forms.CheckBox
		Me.chkCountWarning = New System.Windows.Forms.CheckBox
		Me.chkMaxAge = New System.Windows.Forms.CheckBox
		Me.numCountWarning = New System.Windows.Forms.NumericUpDown
		Me.numMaxCount = New System.Windows.Forms.NumericUpDown
		Me.numMaxAge = New System.Windows.Forms.NumericUpDown
		Me.Label4 = New System.Windows.Forms.Label
		Me.cboDateType = New System.Windows.Forms.ComboBox
		Me.cboAgeType = New System.Windows.Forms.ComboBox
		Me.Label5 = New System.Windows.Forms.Label
		Me.cboFileType = New System.Windows.Forms.ComboBox
		Me.Label6 = New System.Windows.Forms.Label
		CType(Me.numCountWarning, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.numMaxCount, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.numMaxAge, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'txtDirPath
		'
		Me.txtDirPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtDirPath.Location = New System.Drawing.Point(145, 14)
		Me.txtDirPath.Name = "txtDirPath"
		Me.txtDirPath.Size = New System.Drawing.Size(271, 20)
		Me.txtDirPath.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(30, 18)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(74, 13)
		Me.Label1.TabIndex = 11
		Me.Label1.Text = "Directory Path"
		'
		'txtFilePattern
		'
		Me.txtFilePattern.Location = New System.Drawing.Point(145, 40)
		Me.txtFilePattern.Name = "txtFilePattern"
		Me.txtFilePattern.Size = New System.Drawing.Size(124, 20)
		Me.txtFilePattern.TabIndex = 2
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(44, 44)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(60, 13)
		Me.Label2.TabIndex = 13
		Me.Label2.Text = "File Pattern"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(275, 44)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(52, 13)
		Me.Label3.TabIndex = 15
		Me.Label3.Text = "(e.g. *.txt)"
		'
		'chkMaxCount
		'
		Me.chkMaxCount.AutoSize = True
		Me.chkMaxCount.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkMaxCount.Location = New System.Drawing.Point(-2, 92)
		Me.chkMaxCount.Name = "chkMaxCount"
		Me.chkMaxCount.Size = New System.Drawing.Size(133, 17)
		Me.chkMaxCount.TabIndex = 5
		Me.chkMaxCount.Text = "Failure: Max File Count"
		Me.chkMaxCount.UseVisualStyleBackColor = True
		'
		'chkCountWarning
		'
		Me.chkCountWarning.AutoSize = True
		Me.chkCountWarning.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkCountWarning.Location = New System.Drawing.Point(12, 66)
		Me.chkCountWarning.Name = "chkCountWarning"
		Me.chkCountWarning.Size = New System.Drawing.Size(119, 17)
		Me.chkCountWarning.TabIndex = 3
		Me.chkCountWarning.Text = "Warning: File Count"
		Me.chkCountWarning.UseVisualStyleBackColor = True
		'
		'chkMaxAge
		'
		Me.chkMaxAge.AutoSize = True
		Me.chkMaxAge.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkMaxAge.Location = New System.Drawing.Point(7, 118)
		Me.chkMaxAge.Name = "chkMaxAge"
		Me.chkMaxAge.Size = New System.Drawing.Size(124, 17)
		Me.chkMaxAge.TabIndex = 7
		Me.chkMaxAge.Text = "Failure: Max File Age"
		Me.chkMaxAge.UseVisualStyleBackColor = True
		'
		'numCountWarning
		'
		Me.numCountWarning.Location = New System.Drawing.Point(145, 64)
		Me.numCountWarning.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
		Me.numCountWarning.Name = "numCountWarning"
		Me.numCountWarning.Size = New System.Drawing.Size(63, 20)
		Me.numCountWarning.TabIndex = 4
		'
		'numMaxCount
		'
		Me.numMaxCount.Location = New System.Drawing.Point(145, 90)
		Me.numMaxCount.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
		Me.numMaxCount.Name = "numMaxCount"
		Me.numMaxCount.Size = New System.Drawing.Size(63, 20)
		Me.numMaxCount.TabIndex = 6
		'
		'numMaxAge
		'
		Me.numMaxAge.Location = New System.Drawing.Point(145, 116)
		Me.numMaxAge.Maximum = New Decimal(New Integer() {300000, 0, 0, 0})
		Me.numMaxAge.Name = "numMaxAge"
		Me.numMaxAge.Size = New System.Drawing.Size(63, 20)
		Me.numMaxAge.TabIndex = 8
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(249, 145)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(16, 13)
		Me.Label4.TabIndex = 22
		Me.Label4.Text = "of"
		'
		'cboDateType
		'
		Me.cboDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDateType.FormattingEnabled = True
		Me.cboDateType.Items.AddRange(New Object() {"created", "modified", "accessed"})
		Me.cboDateType.Location = New System.Drawing.Point(166, 142)
		Me.cboDateType.Name = "cboDateType"
		Me.cboDateType.Size = New System.Drawing.Size(77, 21)
		Me.cboDateType.TabIndex = 10
		'
		'cboAgeType
		'
		Me.cboAgeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboAgeType.FormattingEnabled = True
		Me.cboAgeType.Items.AddRange(New Object() {"seconds", "minutes", "hours", "days"})
		Me.cboAgeType.Location = New System.Drawing.Point(214, 115)
		Me.cboAgeType.Name = "cboAgeType"
		Me.cboAgeType.Size = New System.Drawing.Size(70, 21)
		Me.cboAgeType.TabIndex = 9
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(86, 145)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(75, 13)
		Me.Label5.TabIndex = 23
		Me.Label5.Text = "based on date"
		'
		'cboFileType
		'
		Me.cboFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboFileType.FormattingEnabled = True
		Me.cboFileType.Items.AddRange(New Object() {"oldest", "newest"})
		Me.cboFileType.Location = New System.Drawing.Point(271, 142)
		Me.cboFileType.Name = "cboFileType"
		Me.cboFileType.Size = New System.Drawing.Size(77, 21)
		Me.cboFileType.TabIndex = 24
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(354, 145)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(23, 13)
		Me.Label6.TabIndex = 25
		Me.Label6.Text = "file."
		'
		'FileMonitorEditor
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.cboFileType)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.cboAgeType)
		Me.Controls.Add(Me.cboDateType)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.numMaxAge)
		Me.Controls.Add(Me.numMaxCount)
		Me.Controls.Add(Me.numCountWarning)
		Me.Controls.Add(Me.chkMaxAge)
		Me.Controls.Add(Me.chkCountWarning)
		Me.Controls.Add(Me.chkMaxCount)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.txtFilePattern)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.txtDirPath)
		Me.Controls.Add(Me.Label1)
		Me.Name = "FileMonitorEditor"
		Me.Size = New System.Drawing.Size(419, 181)
		CType(Me.numCountWarning, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.numMaxCount, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.numMaxAge, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents txtDirPath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFilePattern As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkMaxCount As System.Windows.Forms.CheckBox
    Friend WithEvents chkCountWarning As System.Windows.Forms.CheckBox
    Friend WithEvents chkMaxAge As System.Windows.Forms.CheckBox
    Friend WithEvents numCountWarning As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMaxCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMaxAge As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboDateType As System.Windows.Forms.ComboBox
    Friend WithEvents cboAgeType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboFileType As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
