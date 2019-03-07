<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCPanelGroup
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCPanelGroup))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tbtnCollapse = New System.Windows.Forms.ToolStripButton()
        Me.tbtnExpand = New System.Windows.Forms.ToolStripButton()
        Me.tlblGroupName = New System.Windows.Forms.ToolStripLabel()
        Me.tbtnRefreshPanelStatus = New System.Windows.Forms.ToolStripButton()
        Me.tbtnOrderPanels = New System.Windows.Forms.ToolStripButton()
        Me.tbtnAddPanel = New System.Windows.Forms.ToolStripButton()
        Me.tbtnDeleteGroup = New System.Windows.Forms.ToolStripButton()
        Me.tbtnEditGroupName = New System.Windows.Forms.ToolStripButton()
        Me.pnlMain = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Orange
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnCollapse, Me.tbtnExpand, Me.tlblGroupName, Me.tbtnRefreshPanelStatus, Me.tbtnOrderPanels, Me.tbtnAddPanel, Me.tbtnDeleteGroup, Me.tbtnEditGroupName})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(388, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tbtnCollapse
        '
        Me.tbtnCollapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnCollapse.Image = CType(resources.GetObject("tbtnCollapse.Image"), System.Drawing.Image)
        Me.tbtnCollapse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnCollapse.Name = "tbtnCollapse"
        Me.tbtnCollapse.Size = New System.Drawing.Size(23, 22)
        Me.tbtnCollapse.Text = "Collapse"
        '
        'tbtnExpand
        '
        Me.tbtnExpand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnExpand.Image = CType(resources.GetObject("tbtnExpand.Image"), System.Drawing.Image)
        Me.tbtnExpand.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnExpand.Name = "tbtnExpand"
        Me.tbtnExpand.Size = New System.Drawing.Size(23, 22)
        Me.tbtnExpand.Text = "Expand"
        '
        'tlblGroupName
        '
        Me.tlblGroupName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tlblGroupName.ForeColor = System.Drawing.Color.Black
        Me.tlblGroupName.Name = "tlblGroupName"
        Me.tlblGroupName.Size = New System.Drawing.Size(81, 22)
        Me.tlblGroupName.Text = "Panel Group"
        '
        'tbtnRefreshPanelStatus
        '
        Me.tbtnRefreshPanelStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbtnRefreshPanelStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnRefreshPanelStatus.Image = Global.PolyMonManager.My.Resources.Resources.Refresh
        Me.tbtnRefreshPanelStatus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnRefreshPanelStatus.Name = "tbtnRefreshPanelStatus"
        Me.tbtnRefreshPanelStatus.Size = New System.Drawing.Size(23, 22)
        Me.tbtnRefreshPanelStatus.Text = "Refresh All Panel Status"
        '
        'tbtnOrderPanels
        '
        Me.tbtnOrderPanels.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbtnOrderPanels.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnOrderPanels.Image = CType(resources.GetObject("tbtnOrderPanels.Image"), System.Drawing.Image)
        Me.tbtnOrderPanels.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnOrderPanels.Name = "tbtnOrderPanels"
        Me.tbtnOrderPanels.Size = New System.Drawing.Size(23, 22)
        Me.tbtnOrderPanels.Text = "Re-Order Panels"
        '
        'tbtnAddPanel
        '
        Me.tbtnAddPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbtnAddPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnAddPanel.Image = CType(resources.GetObject("tbtnAddPanel.Image"), System.Drawing.Image)
        Me.tbtnAddPanel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnAddPanel.Name = "tbtnAddPanel"
        Me.tbtnAddPanel.Size = New System.Drawing.Size(23, 22)
        Me.tbtnAddPanel.Text = "Add Monitor"
        '
        'tbtnDeleteGroup
        '
        Me.tbtnDeleteGroup.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbtnDeleteGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnDeleteGroup.Image = Global.PolyMonManager.My.Resources.Resources.DeleteHS
        Me.tbtnDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnDeleteGroup.Name = "tbtnDeleteGroup"
        Me.tbtnDeleteGroup.Size = New System.Drawing.Size(23, 22)
        Me.tbtnDeleteGroup.Text = "Delete Group"
        '
        'tbtnEditGroupName
        '
        Me.tbtnEditGroupName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbtnEditGroupName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnEditGroupName.Image = Global.PolyMonManager.My.Resources.Resources.NewCardHS
        Me.tbtnEditGroupName.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnEditGroupName.Name = "tbtnEditGroupName"
        Me.tbtnEditGroupName.Size = New System.Drawing.Size(23, 22)
        Me.tbtnEditGroupName.Text = "Edit Group Name"
        '
        'pnlMain
        '
        Me.pnlMain.AutoSize = True
        Me.pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlMain.BackColor = System.Drawing.Color.Transparent
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(388, 438)
        Me.pnlMain.TabIndex = 5
        '
        'UCPanelGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "UCPanelGroup"
        Me.Size = New System.Drawing.Size(388, 438)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbtnCollapse As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnExpand As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlblGroupName As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tbtnRefreshPanelStatus As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnOrderPanels As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnAddPanel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnDeleteGroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnEditGroupName As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlMain As System.Windows.Forms.FlowLayoutPanel

End Class
