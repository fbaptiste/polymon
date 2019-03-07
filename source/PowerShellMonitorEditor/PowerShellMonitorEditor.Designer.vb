<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PowerShellMonitorEditor
	Inherits PolyMon.MonitorEditors.GenericMonitorEditor

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.txtScript = New System.Windows.Forms.RichTextBox
		Me.SuspendLayout()
		'
		'txtScript
		'
		Me.txtScript.Dock = System.Windows.Forms.DockStyle.Fill
		Me.txtScript.Location = New System.Drawing.Point(0, 0)
		Me.txtScript.Name = "txtScript"
		Me.txtScript.Size = New System.Drawing.Size(327, 186)
		Me.txtScript.TabIndex = 0
		Me.txtScript.Text = ""
		'
		'PowerShellMonitorEditor
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.txtScript)
		Me.Name = "PowerShellMonitorEditor"
		Me.Size = New System.Drawing.Size(327, 186)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents txtScript As System.Windows.Forms.RichTextBox

End Class
