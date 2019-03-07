<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboard))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnOrderGroups = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tbtnNewGroup = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnViews = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tbtnViewList = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbtnViewTiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 36)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(445, 384)
        Me.FlowLayoutPanel1.TabIndex = 0
        Me.FlowLayoutPanel1.TabStop = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.tbtnOrderGroups, Me.ToolStripSeparator2, Me.tbtnRefresh, Me.tbtnNewGroup, Me.ToolStripSeparator3, Me.tbtnViews})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(469, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnOrderGroups
        '
        Me.tbtnOrderGroups.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnOrderGroups.Image = CType(resources.GetObject("tbtnOrderGroups.Image"), System.Drawing.Image)
        Me.tbtnOrderGroups.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnOrderGroups.Name = "tbtnOrderGroups"
        Me.tbtnOrderGroups.Size = New System.Drawing.Size(23, 22)
        Me.tbtnOrderGroups.Text = "Re-order Groups"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnRefresh
        '
        Me.tbtnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnRefresh.Image = Global.PolyMonManager.My.Resources.Resources.Refresh
        Me.tbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnRefresh.Name = "tbtnRefresh"
        Me.tbtnRefresh.Size = New System.Drawing.Size(23, 22)
        Me.tbtnRefresh.Text = "Refresh"
        Me.tbtnRefresh.ToolTipText = "Refresh Now"
        '
        'tbtnNewGroup
        '
        Me.tbtnNewGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnNewGroup.Image = Global.PolyMonManager.My.Resources.Resources.NewDocumentHS
        Me.tbtnNewGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnNewGroup.Name = "tbtnNewGroup"
        Me.tbtnNewGroup.Size = New System.Drawing.Size(23, 22)
        Me.tbtnNewGroup.Text = "New Group"
        Me.tbtnNewGroup.ToolTipText = "Create new Group"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnViews
        '
        Me.tbtnViews.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnViewList, Me.tbtnViewTiles})
        Me.tbtnViews.Image = CType(resources.GetObject("tbtnViews.Image"), System.Drawing.Image)
        Me.tbtnViews.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnViews.Name = "tbtnViews"
        Me.tbtnViews.Size = New System.Drawing.Size(66, 22)
        Me.tbtnViews.Text = "Views"
        '
        'tbtnViewList
        '
        Me.tbtnViewList.Image = CType(resources.GetObject("tbtnViewList.Image"), System.Drawing.Image)
        Me.tbtnViewList.Name = "tbtnViewList"
        Me.tbtnViewList.Size = New System.Drawing.Size(98, 22)
        Me.tbtnViewList.Text = "List"
        '
        'tbtnViewTiles
        '
        Me.tbtnViewTiles.Image = CType(resources.GetObject("tbtnViewTiles.Image"), System.Drawing.Image)
        Me.tbtnViewTiles.Name = "tbtnViewTiles"
        Me.tbtnViewTiles.Size = New System.Drawing.Size(98, 22)
        Me.tbtnViewTiles.Text = "Tiles"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "polymon.chm"
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(469, 432)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "12")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDashboard"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Dashboard"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnOrderGroups As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnNewGroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnViews As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tbtnViewList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbtnViewTiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
End Class
