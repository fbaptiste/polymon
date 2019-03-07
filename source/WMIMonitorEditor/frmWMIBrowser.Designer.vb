<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWMIBrowser
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWMIBrowser))
		Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
		Me.Label2 = New System.Windows.Forms.Label
		Me.btnClearFilter = New System.Windows.Forms.Button
		Me.btnFilter = New System.Windows.Forms.Button
		Me.txtFilter = New System.Windows.Forms.TextBox
		Me.txtHost = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.btnGetClasses = New System.Windows.Forms.Button
		Me.lstClasses = New System.Windows.Forms.ListBox
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.lstInstances = New System.Windows.Forms.ListBox
		Me.dgvProperties = New System.Windows.Forms.DataGridView
		Me.btnGenerateQuery = New System.Windows.Forms.Button
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
		Me.tlblHost = New System.Windows.Forms.ToolStripStatusLabel
		Me.tlblCount = New System.Windows.Forms.ToolStripStatusLabel
		Me.tlblStatus = New System.Windows.Forms.ToolStripStatusLabel
		Me.tlblCancel = New System.Windows.Forms.ToolStripStatusLabel
		Me.Label3 = New System.Windows.Forms.Label
		Me.TabControl1 = New System.Windows.Forms.TabControl
		Me.tpWMIBrowser = New System.Windows.Forms.TabPage
		Me.tpWMIQuery = New System.Windows.Forms.TabPage
		Me.Label8 = New System.Windows.Forms.Label
		Me.btnSendQueryBack = New System.Windows.Forms.Button
		Me.Label7 = New System.Windows.Forms.Label
		Me.lstProperties = New System.Windows.Forms.ListBox
		Me.Label6 = New System.Windows.Forms.Label
		Me.btnRunQuery = New System.Windows.Forms.Button
		Me.txtResults = New System.Windows.Forms.TextBox
		Me.Label4 = New System.Windows.Forms.Label
		Me.txtQuery = New System.Windows.Forms.TextBox
		Me.txtQueryHost = New System.Windows.Forms.TextBox
		Me.Label5 = New System.Windows.Forms.Label
		Me.SplitContainer2.Panel1.SuspendLayout()
		Me.SplitContainer2.Panel2.SuspendLayout()
		Me.SplitContainer2.SuspendLayout()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		CType(Me.dgvProperties, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StatusStrip1.SuspendLayout()
		Me.TabControl1.SuspendLayout()
		Me.tpWMIBrowser.SuspendLayout()
		Me.tpWMIQuery.SuspendLayout()
		Me.SuspendLayout()
		'
		'SplitContainer2
		'
		Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.SplitContainer2.Location = New System.Drawing.Point(6, 6)
		Me.SplitContainer2.Name = "SplitContainer2"
		'
		'SplitContainer2.Panel1
		'
		Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
		Me.SplitContainer2.Panel1.Controls.Add(Me.btnClearFilter)
		Me.SplitContainer2.Panel1.Controls.Add(Me.btnFilter)
		Me.SplitContainer2.Panel1.Controls.Add(Me.txtFilter)
		Me.SplitContainer2.Panel1.Controls.Add(Me.txtHost)
		Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
		Me.SplitContainer2.Panel1.Controls.Add(Me.btnGetClasses)
		Me.SplitContainer2.Panel1.Controls.Add(Me.lstClasses)
		'
		'SplitContainer2.Panel2
		'
		Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
		Me.SplitContainer2.Size = New System.Drawing.Size(850, 384)
		Me.SplitContainer2.SplitterDistance = 375
		Me.SplitContainer2.TabIndex = 15
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label2.Location = New System.Drawing.Point(3, 37)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(29, 13)
		Me.Label2.TabIndex = 7
		Me.Label2.Text = "Filter"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnClearFilter
		'
		Me.btnClearFilter.Location = New System.Drawing.Point(279, 52)
		Me.btnClearFilter.Name = "btnClearFilter"
		Me.btnClearFilter.Size = New System.Drawing.Size(67, 23)
		Me.btnClearFilter.TabIndex = 4
		Me.btnClearFilter.Text = "Clear Filter"
		Me.btnClearFilter.UseVisualStyleBackColor = True
		'
		'btnFilter
		'
		Me.btnFilter.Location = New System.Drawing.Point(207, 52)
		Me.btnFilter.Name = "btnFilter"
		Me.btnFilter.Size = New System.Drawing.Size(67, 23)
		Me.btnFilter.TabIndex = 3
		Me.btnFilter.Text = "Apply Filter"
		Me.btnFilter.UseVisualStyleBackColor = True
		'
		'txtFilter
		'
		Me.txtFilter.Location = New System.Drawing.Point(6, 53)
		Me.txtFilter.Name = "txtFilter"
		Me.txtFilter.Size = New System.Drawing.Size(196, 20)
		Me.txtFilter.TabIndex = 2
		'
		'txtHost
		'
		Me.txtHost.Location = New System.Drawing.Point(41, 7)
		Me.txtHost.Name = "txtHost"
		Me.txtHost.Size = New System.Drawing.Size(196, 20)
		Me.txtHost.TabIndex = 0
		Me.txtHost.Text = "localhost"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label1.Location = New System.Drawing.Point(3, 11)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(29, 13)
		Me.Label1.TabIndex = 6
		Me.Label1.Text = "Host"
		'
		'btnGetClasses
		'
		Me.btnGetClasses.Location = New System.Drawing.Point(243, 6)
		Me.btnGetClasses.Name = "btnGetClasses"
		Me.btnGetClasses.Size = New System.Drawing.Size(102, 23)
		Me.btnGetClasses.TabIndex = 1
		Me.btnGetClasses.Text = "Retrieve Classes"
		Me.btnGetClasses.UseVisualStyleBackColor = True
		'
		'lstClasses
		'
		Me.lstClasses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lstClasses.ColumnWidth = 200
		Me.lstClasses.DisplayMember = "Name"
		Me.lstClasses.FormattingEnabled = True
		Me.lstClasses.IntegralHeight = False
		Me.lstClasses.Location = New System.Drawing.Point(0, 80)
		Me.lstClasses.Name = "lstClasses"
		Me.lstClasses.Size = New System.Drawing.Size(375, 304)
		Me.lstClasses.Sorted = True
		Me.lstClasses.TabIndex = 1
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.lstInstances)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.dgvProperties)
		Me.SplitContainer1.Size = New System.Drawing.Size(471, 384)
		Me.SplitContainer1.SplitterDistance = 136
		Me.SplitContainer1.TabIndex = 11
		'
		'lstInstances
		'
		Me.lstInstances.DisplayMember = "Name"
		Me.lstInstances.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstInstances.FormattingEnabled = True
		Me.lstInstances.IntegralHeight = False
		Me.lstInstances.Location = New System.Drawing.Point(0, 0)
		Me.lstInstances.Name = "lstInstances"
		Me.lstInstances.Size = New System.Drawing.Size(471, 136)
		Me.lstInstances.Sorted = True
		Me.lstInstances.TabIndex = 9
		'
		'dgvProperties
		'
		Me.dgvProperties.BackgroundColor = System.Drawing.Color.White
		Me.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvProperties.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvProperties.Location = New System.Drawing.Point(0, 0)
		Me.dgvProperties.Name = "dgvProperties"
		Me.dgvProperties.Size = New System.Drawing.Size(471, 244)
		Me.dgvProperties.TabIndex = 10
		'
		'btnGenerateQuery
		'
		Me.btnGenerateQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnGenerateQuery.Location = New System.Drawing.Point(778, 396)
		Me.btnGenerateQuery.Name = "btnGenerateQuery"
		Me.btnGenerateQuery.Size = New System.Drawing.Size(75, 23)
		Me.btnGenerateQuery.TabIndex = 14
		Me.btnGenerateQuery.Text = "WMI Query"
		Me.btnGenerateQuery.UseVisualStyleBackColor = True
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlblHost, Me.tlblCount, Me.tlblStatus, Me.tlblCancel})
		Me.StatusStrip1.Location = New System.Drawing.Point(3, 424)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(853, 22)
		Me.StatusStrip1.SizingGrip = False
		Me.StatusStrip1.TabIndex = 13
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'tlblHost
		'
		Me.tlblHost.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
		Me.tlblHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.tlblHost.Name = "tlblHost"
		Me.tlblHost.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
		Me.tlblHost.Size = New System.Drawing.Size(43, 17)
		Me.tlblHost.Text = "Host"
		'
		'tlblCount
		'
		Me.tlblCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
		Me.tlblCount.Name = "tlblCount"
		Me.tlblCount.Size = New System.Drawing.Size(4, 17)
		'
		'tlblStatus
		'
		Me.tlblStatus.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
		Me.tlblStatus.Name = "tlblStatus"
		Me.tlblStatus.Size = New System.Drawing.Size(786, 17)
		Me.tlblStatus.Spring = True
		Me.tlblStatus.Text = "Ready"
		Me.tlblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tlblCancel
		'
		Me.tlblCancel.BackColor = System.Drawing.SystemColors.Control
		Me.tlblCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.tlblCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
		Me.tlblCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.tlblCancel.Image = CType(resources.GetObject("tlblCancel.Image"), System.Drawing.Image)
		Me.tlblCancel.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tlblCancel.IsLink = True
		Me.tlblCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
		Me.tlblCancel.Margin = New System.Windows.Forms.Padding(0, 2, 0, 1)
		Me.tlblCancel.Name = "tlblCancel"
		Me.tlblCancel.Padding = New System.Windows.Forms.Padding(10, 0, 10, 4)
		Me.tlblCancel.Size = New System.Drawing.Size(59, 19)
		Me.tlblCancel.Text = "Cancel"
		Me.tlblCancel.Visible = False
		'
		'Label3
		'
		Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label3.AutoSize = True
		Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label3.Location = New System.Drawing.Point(268, 401)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(504, 13)
		Me.Label3.TabIndex = 16
		Me.Label3.Text = "To generate WMI query, select Class, Instance or one or more Properties and click" & _
			" the WMI Query button"
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.tpWMIBrowser)
		Me.TabControl1.Controls.Add(Me.tpWMIQuery)
		Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TabControl1.Location = New System.Drawing.Point(0, 0)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(867, 475)
		Me.TabControl1.TabIndex = 17
		'
		'tpWMIBrowser
		'
		Me.tpWMIBrowser.Controls.Add(Me.SplitContainer2)
		Me.tpWMIBrowser.Controls.Add(Me.StatusStrip1)
		Me.tpWMIBrowser.Controls.Add(Me.Label3)
		Me.tpWMIBrowser.Controls.Add(Me.btnGenerateQuery)
		Me.tpWMIBrowser.Location = New System.Drawing.Point(4, 22)
		Me.tpWMIBrowser.Name = "tpWMIBrowser"
		Me.tpWMIBrowser.Padding = New System.Windows.Forms.Padding(3)
		Me.tpWMIBrowser.Size = New System.Drawing.Size(859, 449)
		Me.tpWMIBrowser.TabIndex = 0
		Me.tpWMIBrowser.Text = "WMI Browser"
		Me.tpWMIBrowser.UseVisualStyleBackColor = True
		'
		'tpWMIQuery
		'
		Me.tpWMIQuery.Controls.Add(Me.Label8)
		Me.tpWMIQuery.Controls.Add(Me.btnSendQueryBack)
		Me.tpWMIQuery.Controls.Add(Me.Label7)
		Me.tpWMIQuery.Controls.Add(Me.lstProperties)
		Me.tpWMIQuery.Controls.Add(Me.Label6)
		Me.tpWMIQuery.Controls.Add(Me.btnRunQuery)
		Me.tpWMIQuery.Controls.Add(Me.txtResults)
		Me.tpWMIQuery.Controls.Add(Me.Label4)
		Me.tpWMIQuery.Controls.Add(Me.txtQuery)
		Me.tpWMIQuery.Controls.Add(Me.txtQueryHost)
		Me.tpWMIQuery.Controls.Add(Me.Label5)
		Me.tpWMIQuery.Location = New System.Drawing.Point(4, 22)
		Me.tpWMIQuery.Name = "tpWMIQuery"
		Me.tpWMIQuery.Padding = New System.Windows.Forms.Padding(3)
		Me.tpWMIQuery.Size = New System.Drawing.Size(859, 449)
		Me.tpWMIQuery.TabIndex = 1
		Me.tpWMIQuery.Text = "WMI Query"
		Me.tpWMIQuery.UseVisualStyleBackColor = True
		'
		'Label8
		'
		Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label8.Location = New System.Drawing.Point(682, 342)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(169, 56)
		Me.Label8.TabIndex = 24
		Me.Label8.Text = "Click this button to close WMI Query Builder and send current Query back to Monit" & _
			"or Definition Editor"
		'
		'btnSendQueryBack
		'
		Me.btnSendQueryBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnSendQueryBack.Location = New System.Drawing.Point(682, 401)
		Me.btnSendQueryBack.Name = "btnSendQueryBack"
		Me.btnSendQueryBack.Size = New System.Drawing.Size(169, 40)
		Me.btnSendQueryBack.TabIndex = 23
		Me.btnSendQueryBack.Text = "Use this Query in Monitor Definition"
		Me.btnSendQueryBack.UseVisualStyleBackColor = True
		'
		'Label7
		'
		Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Label7.AutoSize = True
		Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label7.Location = New System.Drawing.Point(8, 305)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(241, 13)
		Me.Label7.TabIndex = 22
		Me.Label7.Text = "Counters that will be Saved to PolyMon Database"
		'
		'lstProperties
		'
		Me.lstProperties.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lstProperties.FormattingEnabled = True
		Me.lstProperties.IntegralHeight = False
		Me.lstProperties.Location = New System.Drawing.Point(11, 322)
		Me.lstProperties.Name = "lstProperties"
		Me.lstProperties.Size = New System.Drawing.Size(326, 124)
		Me.lstProperties.TabIndex = 0
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label6.Location = New System.Drawing.Point(6, 150)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(73, 13)
		Me.Label6.TabIndex = 21
		Me.Label6.Text = "Query Results"
		'
		'btnRunQuery
		'
		Me.btnRunQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnRunQuery.Location = New System.Drawing.Point(776, 137)
		Me.btnRunQuery.Name = "btnRunQuery"
		Me.btnRunQuery.Size = New System.Drawing.Size(75, 23)
		Me.btnRunQuery.TabIndex = 16
		Me.btnRunQuery.Text = "Run Query"
		Me.btnRunQuery.UseVisualStyleBackColor = True
		'
		'txtResults
		'
		Me.txtResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtResults.Location = New System.Drawing.Point(8, 166)
		Me.txtResults.Multiline = True
		Me.txtResults.Name = "txtResults"
		Me.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtResults.Size = New System.Drawing.Size(843, 126)
		Me.txtResults.TabIndex = 17
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label4.Location = New System.Drawing.Point(8, 49)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(35, 13)
		Me.Label4.TabIndex = 19
		Me.Label4.Text = "Query"
		'
		'txtQuery
		'
		Me.txtQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtQuery.Location = New System.Drawing.Point(8, 65)
		Me.txtQuery.Multiline = True
		Me.txtQuery.Name = "txtQuery"
		Me.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtQuery.Size = New System.Drawing.Size(843, 66)
		Me.txtQuery.TabIndex = 15
		'
		'txtQueryHost
		'
		Me.txtQueryHost.Location = New System.Drawing.Point(8, 19)
		Me.txtQueryHost.Name = "txtQueryHost"
		Me.txtQueryHost.Size = New System.Drawing.Size(196, 20)
		Me.txtQueryHost.TabIndex = 14
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label5.Location = New System.Drawing.Point(8, 3)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(29, 13)
		Me.Label5.TabIndex = 18
		Me.Label5.Text = "Host"
		'
		'frmWMIBrowser
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(867, 475)
		Me.Controls.Add(Me.TabControl1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmWMIBrowser"
		Me.Text = "WMI Query Builder"
		Me.SplitContainer2.Panel1.ResumeLayout(False)
		Me.SplitContainer2.Panel1.PerformLayout()
		Me.SplitContainer2.Panel2.ResumeLayout(False)
		Me.SplitContainer2.ResumeLayout(False)
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.ResumeLayout(False)
		CType(Me.dgvProperties, System.ComponentModel.ISupportInitialize).EndInit()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.TabControl1.ResumeLayout(False)
		Me.tpWMIBrowser.ResumeLayout(False)
		Me.tpWMIBrowser.PerformLayout()
		Me.tpWMIQuery.ResumeLayout(False)
		Me.tpWMIQuery.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents btnClearFilter As System.Windows.Forms.Button
	Friend WithEvents btnFilter As System.Windows.Forms.Button
	Friend WithEvents txtFilter As System.Windows.Forms.TextBox
	Friend WithEvents txtHost As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents btnGetClasses As System.Windows.Forms.Button
	Friend WithEvents lstClasses As System.Windows.Forms.ListBox
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents lstInstances As System.Windows.Forms.ListBox
	Friend WithEvents dgvProperties As System.Windows.Forms.DataGridView
	Friend WithEvents btnGenerateQuery As System.Windows.Forms.Button
	Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
	Friend WithEvents tlblHost As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents tlblCount As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents tlblStatus As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents tlblCancel As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
	Friend WithEvents tpWMIBrowser As System.Windows.Forms.TabPage
	Friend WithEvents tpWMIQuery As System.Windows.Forms.TabPage
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents lstProperties As System.Windows.Forms.ListBox
	Friend WithEvents btnRunQuery As System.Windows.Forms.Button
	Friend WithEvents txtResults As System.Windows.Forms.TextBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents txtQuery As System.Windows.Forms.TextBox
	Friend WithEvents txtQueryHost As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents btnSendQueryBack As System.Windows.Forms.Button
	Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
