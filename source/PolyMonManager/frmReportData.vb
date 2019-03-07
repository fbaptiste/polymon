Public Class frmReportData
	Private mMonitorID As Integer

	Public Sub New(ByVal MonitorID As Integer, ByVal MonitorName As String, ByVal MonitorType As String, ByVal tblStatus As DataTable, ByVal tblCounters As DataTable)
		InitializeComponent()


		mMonitorID = MonitorID
		Me.lblMonitor.Text = MonitorName
		Me.lblMonitorType.Text = MonitorType

		dgvStatus.BackgroundColor = Color.White
		dgvCounters.BackgroundColor = Color.White

		If tblStatus IsNot Nothing Then
			With dgvStatus
				.SuspendLayout()

				.DataSource = tblStatus

				.EnableHeadersVisualStyles = False
				.DefaultCellStyle.BackColor = Color.WhiteSmoke
				.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None

				Dim HStyle As New DataGridViewCellStyle
				HStyle.ForeColor = Color.White
				HStyle.BackColor = Color.DarkBlue
				HStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
				HStyle.Padding = New Padding(5)
				.ColumnHeadersDefaultCellStyle = HStyle

				.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None
				.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single

				.RowHeadersVisible = False

				.AllowUserToResizeRows = False
				.AllowUserToAddRows = False
				.AllowUserToDeleteRows = False
				.SelectionMode = DataGridViewSelectionMode.FullRowSelect
				.ReadOnly = True
				.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue

				For Each Col As DataColumn In tblStatus.Columns
					.Columns(Col.ColumnName).Visible = CBool(Col.ExtendedProperties("Visible"))
					.Columns(Col.ColumnName).HeaderText = Col.Caption
					.Columns(Col.ColumnName).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
					.Columns(Col.ColumnName).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
					.Columns(Col.ColumnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				Next

				.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
				.ResumeLayout()
			End With
		End If

		If tblCounters IsNot Nothing Then
			With dgvCounters
				.SuspendLayout()
				.DataSource = tblCounters

				.EnableHeadersVisualStyles = False
				.DefaultCellStyle.BackColor = Color.WhiteSmoke
				.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None

				Dim HStyle As New DataGridViewCellStyle
				HStyle.ForeColor = Color.White
				HStyle.BackColor = Color.DarkBlue
				HStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
				HStyle.Padding = New Padding(5)
				.ColumnHeadersDefaultCellStyle = HStyle

				.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None
				.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single

				.RowHeadersVisible = False

				.AllowUserToResizeRows = False
				.AllowUserToAddRows = False
				.AllowUserToDeleteRows = False
				.SelectionMode = DataGridViewSelectionMode.FullRowSelect
				.ReadOnly = True
				.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue


				For Each Col As DataColumn In tblCounters.Columns
					.Columns(Col.ColumnName).Visible = CBool(Col.ExtendedProperties("Visible"))
					.Columns(Col.ColumnName).HeaderText = Col.Caption
					.Columns(Col.ColumnName).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
					.Columns(Col.ColumnName).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
					.Columns(Col.ColumnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				Next

				.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
				.ResumeLayout()
				.Invalidate()
			End With
		End If

	End Sub
	
End Class