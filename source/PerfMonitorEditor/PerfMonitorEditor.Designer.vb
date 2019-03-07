<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerfMonitorEditor
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.txtCategory = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCounter = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtInstance = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkFailMin = New System.Windows.Forms.CheckBox
        Me.txtFailMin = New System.Windows.Forms.TextBox
        Me.txtFailMax = New System.Windows.Forms.TextBox
        Me.chkFailMax = New System.Windows.Forms.CheckBox
        Me.txtWarnMax = New System.Windows.Forms.TextBox
        Me.chkWarnMax = New System.Windows.Forms.CheckBox
        Me.txtWarnMin = New System.Windows.Forms.TextBox
        Me.chkWarnMin = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnBrowser = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'txtHost
        '
        Me.txtHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHost.Location = New System.Drawing.Point(98, 14)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(242, 20)
        Me.txtHost.TabIndex = 1
        '
        'txtCategory
        '
        Me.txtCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCategory.Location = New System.Drawing.Point(98, 40)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(242, 20)
        Me.txtCategory.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Category"
        '
        'txtCounter
        '
        Me.txtCounter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCounter.Location = New System.Drawing.Point(98, 66)
        Me.txtCounter.Name = "txtCounter"
        Me.txtCounter.Size = New System.Drawing.Size(242, 20)
        Me.txtCounter.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Counter"
        '
        'txtInstance
        '
        Me.txtInstance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInstance.Location = New System.Drawing.Point(98, 92)
        Me.txtInstance.Name = "txtInstance"
        Me.txtInstance.Size = New System.Drawing.Size(242, 20)
        Me.txtInstance.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Instance"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(10, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fail Thresholds"
        '
        'chkFailMin
        '
        Me.chkFailMin.AutoSize = True
        Me.chkFailMin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFailMin.ForeColor = System.Drawing.Color.MediumBlue
        Me.chkFailMin.Location = New System.Drawing.Point(100, 157)
        Me.chkFailMin.Name = "chkFailMin"
        Me.chkFailMin.Size = New System.Drawing.Size(67, 17)
        Me.chkFailMin.TabIndex = 5
        Me.chkFailMin.Text = "Minimum"
        Me.chkFailMin.UseVisualStyleBackColor = True
        '
        'txtFailMin
        '
        Me.txtFailMin.Location = New System.Drawing.Point(177, 155)
        Me.txtFailMin.Name = "txtFailMin"
        Me.txtFailMin.Size = New System.Drawing.Size(120, 20)
        Me.txtFailMin.TabIndex = 6
        '
        'txtFailMax
        '
        Me.txtFailMax.Location = New System.Drawing.Point(177, 183)
        Me.txtFailMax.Name = "txtFailMax"
        Me.txtFailMax.Size = New System.Drawing.Size(120, 20)
        Me.txtFailMax.TabIndex = 8
        '
        'chkFailMax
        '
        Me.chkFailMax.AutoSize = True
        Me.chkFailMax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFailMax.ForeColor = System.Drawing.Color.MediumBlue
        Me.chkFailMax.Location = New System.Drawing.Point(97, 185)
        Me.chkFailMax.Name = "chkFailMax"
        Me.chkFailMax.Size = New System.Drawing.Size(70, 17)
        Me.chkFailMax.TabIndex = 7
        Me.chkFailMax.Text = "Maximum"
        Me.chkFailMax.UseVisualStyleBackColor = True
        '
        'txtWarnMax
        '
        Me.txtWarnMax.Location = New System.Drawing.Point(177, 251)
        Me.txtWarnMax.Name = "txtWarnMax"
        Me.txtWarnMax.Size = New System.Drawing.Size(120, 20)
        Me.txtWarnMax.TabIndex = 12
        '
        'chkWarnMax
        '
        Me.chkWarnMax.AutoSize = True
        Me.chkWarnMax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkWarnMax.ForeColor = System.Drawing.Color.MediumBlue
        Me.chkWarnMax.Location = New System.Drawing.Point(97, 253)
        Me.chkWarnMax.Name = "chkWarnMax"
        Me.chkWarnMax.Size = New System.Drawing.Size(70, 17)
        Me.chkWarnMax.TabIndex = 11
        Me.chkWarnMax.Text = "Maximum"
        Me.chkWarnMax.UseVisualStyleBackColor = True
        '
        'txtWarnMin
        '
        Me.txtWarnMin.Location = New System.Drawing.Point(177, 223)
        Me.txtWarnMin.Name = "txtWarnMin"
        Me.txtWarnMin.Size = New System.Drawing.Size(120, 20)
        Me.txtWarnMin.TabIndex = 10
        '
        'chkWarnMin
        '
        Me.chkWarnMin.AutoSize = True
        Me.chkWarnMin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkWarnMin.ForeColor = System.Drawing.Color.MediumBlue
        Me.chkWarnMin.Location = New System.Drawing.Point(100, 225)
        Me.chkWarnMin.Name = "chkWarnMin"
        Me.chkWarnMin.Size = New System.Drawing.Size(67, 17)
        Me.chkWarnMin.TabIndex = 9
        Me.chkWarnMin.Text = "Minimum"
        Me.chkWarnMin.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(10, 237)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Warn Thresholds"
        '
        'btnBrowser
        '
        Me.btnBrowser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowser.Location = New System.Drawing.Point(264, 119)
        Me.btnBrowser.Name = "btnBrowser"
        Me.btnBrowser.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowser.TabIndex = 14
        Me.btnBrowser.Text = "Browser..."
        Me.btnBrowser.UseVisualStyleBackColor = True
        '
        'PerfMonitorEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnBrowser)
        Me.Controls.Add(Me.txtWarnMax)
        Me.Controls.Add(Me.chkWarnMax)
        Me.Controls.Add(Me.txtWarnMin)
        Me.Controls.Add(Me.chkWarnMin)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFailMax)
        Me.Controls.Add(Me.chkFailMax)
        Me.Controls.Add(Me.txtFailMin)
        Me.Controls.Add(Me.chkFailMin)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtInstance)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCounter)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PerfMonitorEditor"
        Me.Size = New System.Drawing.Size(352, 285)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCounter As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInstance As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkFailMin As System.Windows.Forms.CheckBox
    Friend WithEvents txtFailMin As System.Windows.Forms.TextBox
    Friend WithEvents txtFailMax As System.Windows.Forms.TextBox
    Friend WithEvents chkFailMax As System.Windows.Forms.CheckBox
    Friend WithEvents txtWarnMax As System.Windows.Forms.TextBox
    Friend WithEvents chkWarnMax As System.Windows.Forms.CheckBox
    Friend WithEvents txtWarnMin As System.Windows.Forms.TextBox
    Friend WithEvents chkWarnMin As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBrowser As System.Windows.Forms.Button

End Class
