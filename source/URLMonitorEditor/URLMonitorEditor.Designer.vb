<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class URLMonitorEditor
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
        Me.txtURL = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.numFailTimeout = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkWarnTimeout = New System.Windows.Forms.CheckBox
        Me.numWarnTimeout = New System.Windows.Forms.NumericUpDown
        Me.chkFailContent = New System.Windows.Forms.CheckBox
        Me.txtFailContent = New System.Windows.Forms.TextBox
        Me.txtWarnContent = New System.Windows.Forms.TextBox
        Me.chkWarnContent = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFailNegated = New System.Windows.Forms.ComboBox
        Me.cboWarnNegated = New System.Windows.Forms.ComboBox
        CType(Me.numFailTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWarnTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtURL
        '
        Me.txtURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtURL.Location = New System.Drawing.Point(160, 14)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(232, 20)
        Me.txtURL.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "URL"
        '
        'numFailTimeout
        '
        Me.numFailTimeout.Location = New System.Drawing.Point(160, 40)
        Me.numFailTimeout.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
        Me.numFailTimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numFailTimeout.Name = "numFailTimeout"
        Me.numFailTimeout.Size = New System.Drawing.Size(54, 20)
        Me.numFailTimeout.TabIndex = 2
        Me.numFailTimeout.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Timeout: Failure"
        '
        'chkWarnTimeout
        '
        Me.chkWarnTimeout.AutoSize = True
        Me.chkWarnTimeout.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkWarnTimeout.Location = New System.Drawing.Point(35, 74)
        Me.chkWarnTimeout.Name = "chkWarnTimeout"
        Me.chkWarnTimeout.Size = New System.Drawing.Size(110, 17)
        Me.chkWarnTimeout.TabIndex = 3
        Me.chkWarnTimeout.Text = "Timeout: Warning"
        Me.chkWarnTimeout.UseVisualStyleBackColor = True
        '
        'numWarnTimeout
        '
        Me.numWarnTimeout.Location = New System.Drawing.Point(160, 71)
        Me.numWarnTimeout.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
        Me.numWarnTimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numWarnTimeout.Name = "numWarnTimeout"
        Me.numWarnTimeout.Size = New System.Drawing.Size(54, 20)
        Me.numWarnTimeout.TabIndex = 4
        Me.numWarnTimeout.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkFailContent
        '
        Me.chkFailContent.AutoSize = True
        Me.chkFailContent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFailContent.Location = New System.Drawing.Point(11, 106)
        Me.chkFailContent.Name = "chkFailContent"
        Me.chkFailContent.Size = New System.Drawing.Size(134, 17)
        Me.chkFailContent.TabIndex = 5
        Me.chkFailContent.Text = "Check Content: Failure"
        Me.chkFailContent.UseVisualStyleBackColor = True
        '
        'txtFailContent
        '
        Me.txtFailContent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFailContent.Location = New System.Drawing.Point(160, 106)
        Me.txtFailContent.Multiline = True
        Me.txtFailContent.Name = "txtFailContent"
        Me.txtFailContent.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFailContent.Size = New System.Drawing.Size(232, 78)
        Me.txtFailContent.TabIndex = 6
        Me.txtFailContent.WordWrap = False
        '
        'txtWarnContent
        '
        Me.txtWarnContent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWarnContent.Location = New System.Drawing.Point(160, 196)
        Me.txtWarnContent.Multiline = True
        Me.txtWarnContent.Name = "txtWarnContent"
        Me.txtWarnContent.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtWarnContent.Size = New System.Drawing.Size(232, 82)
        Me.txtWarnContent.TabIndex = 9
        Me.txtWarnContent.WordWrap = False
        '
        'chkWarnContent
        '
        Me.chkWarnContent.AutoSize = True
        Me.chkWarnContent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkWarnContent.Location = New System.Drawing.Point(2, 196)
        Me.chkWarnContent.Name = "chkWarnContent"
        Me.chkWarnContent.Size = New System.Drawing.Size(143, 17)
        Me.chkWarnContent.TabIndex = 8
        Me.chkWarnContent.Text = "Check Content: Warning"
        Me.chkWarnContent.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "(seconds)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(220, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "(seconds)"
        '
        'cboFailNegated
        '
        Me.cboFailNegated.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFailNegated.FormattingEnabled = True
        Me.cboFailNegated.Items.AddRange(New Object() {"Fail if not found", "Fail if found"})
        Me.cboFailNegated.Location = New System.Drawing.Point(24, 129)
        Me.cboFailNegated.Name = "cboFailNegated"
        Me.cboFailNegated.Size = New System.Drawing.Size(121, 21)
        Me.cboFailNegated.TabIndex = 7
        '
        'cboWarnNegated
        '
        Me.cboWarnNegated.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWarnNegated.FormattingEnabled = True
        Me.cboWarnNegated.Items.AddRange(New Object() {"Warn if not found", "Warn if found"})
        Me.cboWarnNegated.Location = New System.Drawing.Point(24, 219)
        Me.cboWarnNegated.Name = "cboWarnNegated"
        Me.cboWarnNegated.Size = New System.Drawing.Size(121, 21)
        Me.cboWarnNegated.TabIndex = 10
        '
        'URLMonitorEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboWarnNegated)
        Me.Controls.Add(Me.cboFailNegated)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtWarnContent)
        Me.Controls.Add(Me.chkWarnContent)
        Me.Controls.Add(Me.txtFailContent)
        Me.Controls.Add(Me.chkFailContent)
        Me.Controls.Add(Me.numWarnTimeout)
        Me.Controls.Add(Me.chkWarnTimeout)
        Me.Controls.Add(Me.numFailTimeout)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.Label1)
        Me.Name = "URLMonitorEditor"
        Me.Size = New System.Drawing.Size(399, 284)
        CType(Me.numFailTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWarnTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numFailTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkWarnTimeout As System.Windows.Forms.CheckBox
    Friend WithEvents numWarnTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkFailContent As System.Windows.Forms.CheckBox
    Friend WithEvents txtFailContent As System.Windows.Forms.TextBox
    Friend WithEvents txtWarnContent As System.Windows.Forms.TextBox
    Friend WithEvents chkWarnContent As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFailNegated As System.Windows.Forms.ComboBox
    Friend WithEvents cboWarnNegated As System.Windows.Forms.ComboBox

End Class
