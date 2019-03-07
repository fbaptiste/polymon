<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenericXMLEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenericXMLEditor))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tbtnLoadTemplate = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tbtnUndo = New System.Windows.Forms.ToolStripButton
        Me.tbtnRedo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tcbFontSize = New System.Windows.Forms.ToolStripComboBox
        Me.txtXMLSettings = New System.Windows.Forms.RichTextBox
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnLoadTemplate, Me.ToolStripSeparator1, Me.tbtnUndo, Me.tbtnRedo, Me.ToolStripSeparator2, Me.tcbFontSize})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(351, 25)
        Me.ToolStrip1.TabIndex = 17
        '
        'tbtnLoadTemplate
        '
        Me.tbtnLoadTemplate.Image = CType(resources.GetObject("tbtnLoadTemplate.Image"), System.Drawing.Image)
        Me.tbtnLoadTemplate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnLoadTemplate.Name = "tbtnLoadTemplate"
        Me.tbtnLoadTemplate.Size = New System.Drawing.Size(119, 22)
        Me.tbtnLoadTemplate.Text = "Load XML Template"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnUndo
        '
        Me.tbtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnUndo.Image = CType(resources.GetObject("tbtnUndo.Image"), System.Drawing.Image)
        Me.tbtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnUndo.Name = "tbtnUndo"
        Me.tbtnUndo.Size = New System.Drawing.Size(23, 22)
        Me.tbtnUndo.Text = "ToolStripButton2"
        Me.tbtnUndo.ToolTipText = "Undo"
        '
        'tbtnRedo
        '
        Me.tbtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnRedo.Image = CType(resources.GetObject("tbtnRedo.Image"), System.Drawing.Image)
        Me.tbtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnRedo.Name = "tbtnRedo"
        Me.tbtnRedo.Size = New System.Drawing.Size(23, 22)
        Me.tbtnRedo.Text = "ToolStripButton3"
        Me.tbtnRedo.ToolTipText = "Redo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tcbFontSize
        '
        Me.tcbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tcbFontSize.Name = "tcbFontSize"
        Me.tcbFontSize.Size = New System.Drawing.Size(75, 25)
        Me.tcbFontSize.ToolTipText = "Select Font Size"
        '
        'txtXMLSettings
        '
        Me.txtXMLSettings.AcceptsTab = True
        Me.txtXMLSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtXMLSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtXMLSettings.DetectUrls = False
        Me.txtXMLSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXMLSettings.Location = New System.Drawing.Point(3, 28)
        Me.txtXMLSettings.Name = "txtXMLSettings"
        Me.txtXMLSettings.Size = New System.Drawing.Size(351, 227)
        Me.txtXMLSettings.TabIndex = 18
        Me.txtXMLSettings.Text = ""
        Me.txtXMLSettings.WordWrap = False
        '
        'GenericXMLEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtXMLSettings)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "GenericXMLEditor"
        Me.Size = New System.Drawing.Size(357, 258)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbtnLoadTemplate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnRedo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tcbFontSize As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents txtXMLSettings As System.Windows.Forms.RichTextBox

End Class
