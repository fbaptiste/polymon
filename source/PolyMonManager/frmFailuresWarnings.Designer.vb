<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFailuresWarnings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFailuresWarnings))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tbtnViews = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tbtnViewList = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbtnViewTiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.flpMain = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.tbtnRefresh, Me.tbtnViews})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(691, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        Me.tbtnViewList.Size = New System.Drawing.Size(152, 22)
        Me.tbtnViewList.Text = "List"
        '
        'tbtnViewTiles
        '
        Me.tbtnViewTiles.Image = CType(resources.GetObject("tbtnViewTiles.Image"), System.Drawing.Image)
        Me.tbtnViewTiles.Name = "tbtnViewTiles"
        Me.tbtnViewTiles.Size = New System.Drawing.Size(152, 22)
        Me.tbtnViewTiles.Text = "Tiles"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "polymon.chm"
        '
        'flpMain
        '
        Me.flpMain.AutoScroll = True
        Me.flpMain.BackColor = System.Drawing.Color.Transparent
        Me.flpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpMain.Location = New System.Drawing.Point(0, 25)
        Me.flpMain.Name = "flpMain"
        Me.flpMain.Size = New System.Drawing.Size(691, 533)
        Me.flpMain.TabIndex = 3
        '
        'frmFailuresWarnings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(691, 558)
        Me.Controls.Add(Me.flpMain)
        Me.Controls.Add(Me.ToolStrip1)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "11")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFailuresWarnings"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Failures and Warnings"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnViews As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tbtnViewList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbtnViewTiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents flpMain As System.Windows.Forms.FlowLayoutPanel
End Class
