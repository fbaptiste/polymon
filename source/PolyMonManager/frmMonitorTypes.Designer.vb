<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitorTypes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonitorTypes))
        Me.tsMonitorTypesEditor = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tscMonitorTypes = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.txtXMLTemplate = New System.Windows.Forms.RichTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMonitorAssembly = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtEditorAssembly = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tsMonitorTypesEditor.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMonitorTypesEditor
        '
        Me.tsMonitorTypesEditor.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMonitorTypesEditor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.tscMonitorTypes, Me.ToolStripSeparator2, Me.tsbNew, Me.tsbSave, Me.ToolStripSeparator1, Me.tsbCancel, Me.ToolStripSeparator3, Me.tsbDelete})
        Me.tsMonitorTypesEditor.Location = New System.Drawing.Point(0, 0)
        Me.tsMonitorTypesEditor.Name = "tsMonitorTypesEditor"
        Me.tsMonitorTypesEditor.Size = New System.Drawing.Size(547, 25)
        Me.tsMonitorTypesEditor.TabIndex = 16
        Me.tsMonitorTypesEditor.Text = "Monitor Types"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripLabel1.Text = "Monitor Type"
        '
        'tscMonitorTypes
        '
        Me.tscMonitorTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscMonitorTypes.MaxDropDownItems = 10
        Me.tscMonitorTypes.Name = "tscMonitorTypes"
        Me.tscMonitorTypes.Size = New System.Drawing.Size(150, 25)
        Me.tscMonitorTypes.Sorted = True
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbNew
        '
        Me.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNew.Image = Global.PolyMonManager.My.Resources.Resources.AddTableHS
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(23, 22)
        Me.tsbNew.Text = "tsbMonitorTypes_New"
        Me.tsbNew.ToolTipText = "Create New Monitor Type"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSave.Image = Global.PolyMonManager.My.Resources.Resources.saveHS
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(23, 22)
        Me.tsbSave.Text = "ToolStripButton1"
        Me.tsbSave.ToolTipText = "Save Monitor Type Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbCancel
        '
        Me.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCancel.Image = Global.PolyMonManager.My.Resources.Resources.Edit_UndoHS
        Me.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancel.Name = "tsbCancel"
        Me.tsbCancel.Size = New System.Drawing.Size(23, 22)
        Me.tsbCancel.Text = "tsbMonitorTypes_Undo"
        Me.tsbCancel.ToolTipText = "Cancel all changes"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDelete.Image = Global.PolyMonManager.My.Resources.Resources.DeleteHS
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(23, 22)
        Me.tsbDelete.Text = "ToolStripButton1"
        Me.tsbDelete.ToolTipText = "Delete Monitor Type"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "polymon.chm"
        '
        'txtXMLTemplate
        '
        Me.txtXMLTemplate.AcceptsTab = True
        Me.txtXMLTemplate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtXMLTemplate.Location = New System.Drawing.Point(110, 106)
        Me.txtXMLTemplate.Name = "txtXMLTemplate"
        Me.txtXMLTemplate.Size = New System.Drawing.Size(425, 349)
        Me.txtXMLTemplate.TabIndex = 28
        Me.txtXMLTemplate.Text = ""
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(11, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 20)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Name"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(280, 30)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(221, 53)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "Note: Please refer to Help file for instructions on where dll's for Monitor and M" & _
    "onitor Editors need to be located"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(11, 105)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 20)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "XML Template"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(11, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 20)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Monitor Assembly"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMonitorAssembly
        '
        Me.txtMonitorAssembly.Location = New System.Drawing.Point(110, 46)
        Me.txtMonitorAssembly.MaxLength = 255
        Me.txtMonitorAssembly.Name = "txtMonitorAssembly"
        Me.txtMonitorAssembly.Size = New System.Drawing.Size(164, 20)
        Me.txtMonitorAssembly.TabIndex = 26
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(110, 20)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(164, 20)
        Me.txtName.TabIndex = 25
        '
        'txtEditorAssembly
        '
        Me.txtEditorAssembly.Location = New System.Drawing.Point(110, 72)
        Me.txtEditorAssembly.MaxLength = 255
        Me.txtEditorAssembly.Name = "txtEditorAssembly"
        Me.txtEditorAssembly.Size = New System.Drawing.Size(164, 20)
        Me.txtEditorAssembly.TabIndex = 27
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(11, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 20)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Editor Assembly"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmMonitorTypes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 475)
        Me.Controls.Add(Me.txtXMLTemplate)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtMonitorAssembly)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtEditorAssembly)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.tsMonitorTypesEditor)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "17")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMonitorTypes"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "MonitorTypes"
        Me.tsMonitorTypesEditor.ResumeLayout(False)
        Me.tsMonitorTypesEditor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMonitorTypesEditor As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscMonitorTypes As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents txtXMLTemplate As System.Windows.Forms.RichTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMonitorAssembly As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtEditorAssembly As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
