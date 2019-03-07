<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportData
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
        Me.dgvStatus = New System.Windows.Forms.DataGridView()
        Me.dgvCounters = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblMonitorType = New System.Windows.Forms.Label()
        Me.lblMonitor = New System.Windows.Forms.Label()
        CType(Me.dgvStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCounters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvStatus
        '
        Me.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStatus.Location = New System.Drawing.Point(0, 0)
        Me.dgvStatus.Name = "dgvStatus"
        Me.dgvStatus.Size = New System.Drawing.Size(629, 216)
        Me.dgvStatus.TabIndex = 0
        '
        'dgvCounters
        '
        Me.dgvCounters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCounters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCounters.Location = New System.Drawing.Point(0, 0)
        Me.dgvCounters.Name = "dgvCounters"
        Me.dgvCounters.Size = New System.Drawing.Size(629, 213)
        Me.dgvCounters.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblMonitorType)
        Me.Panel1.Controls.Add(Me.lblMonitor)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(629, 31)
        Me.Panel1.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.SplitContainer1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 31)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(629, 433)
        Me.Panel3.TabIndex = 5
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvStatus)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvCounters)
        Me.SplitContainer1.Size = New System.Drawing.Size(629, 433)
        Me.SplitContainer1.SplitterDistance = 216
        Me.SplitContainer1.TabIndex = 2
        '
        'lblMonitorType
        '
        Me.lblMonitorType.BackColor = System.Drawing.Color.Transparent
        Me.lblMonitorType.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblMonitorType.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonitorType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMonitorType.Location = New System.Drawing.Point(410, 0)
        Me.lblMonitorType.Name = "lblMonitorType"
        Me.lblMonitorType.Size = New System.Drawing.Size(219, 31)
        Me.lblMonitorType.TabIndex = 6
        Me.lblMonitorType.Text = "Monitor Name"
        Me.lblMonitorType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMonitor
        '
        Me.lblMonitor.BackColor = System.Drawing.Color.Transparent
        Me.lblMonitor.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblMonitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonitor.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMonitor.Location = New System.Drawing.Point(0, 0)
        Me.lblMonitor.Name = "lblMonitor"
        Me.lblMonitor.Size = New System.Drawing.Size(236, 31)
        Me.lblMonitor.TabIndex = 5
        Me.lblMonitor.Text = "Monitor Name"
        Me.lblMonitor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmReportData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 464)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmReportData"
        Me.Text = "Report Data"
        CType(Me.dgvStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCounters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
	Friend WithEvents dgvStatus As System.Windows.Forms.DataGridView
	Friend WithEvents dgvCounters As System.Windows.Forms.DataGridView
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblMonitorType As System.Windows.Forms.Label
    Friend WithEvents lblMonitor As System.Windows.Forms.Label
End Class
