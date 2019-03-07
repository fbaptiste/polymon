Imports System.Data.SqlClient

Public Class frmFailuresWarnings

#Region "Public Interface"
    Public Event AlertEvent As EventHandler
    Public Event AllNominal As EventHandler

    Public Sub RefreshMonitors(ByVal RaiseErrors As Boolean)
        Dim sp As String = "polymon_sel_NonNominalMonitors"
        Dim strSQLConn As String = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
        Dim SQLConn As New SqlConnection(strSQLConn)
        Dim UserSettings As New UserSettings()

        Dim SQLCmd As New SqlCommand
        With SQLCmd
            .Connection = SQLConn
            .CommandType = CommandType.StoredProcedure
            .CommandText = sp
        End With

        Dim rdResults As SqlDataReader
        Dim ErrorsWarnings As Boolean = False
        Dim NumWarnings As Integer = 0
        Dim NumFailures As Integer = 0
        Try
            Me.flpMain.Controls.Clear()
            SQLConn.Open()
            rdResults = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rdResults.Read()
                ErrorsWarnings = True
                Select Case UserSettings.FailuresWarningsViewType
                    Case PolyMonManager.UserSettings.MonitorViewTypes.List
                        Dim myMonitorPanel As New UCMonitorPanelListView(CInt(rdResults.Item("MonitorID")), True)
                        Select Case myMonitorPanel.CurrentStatus.Status
                            Case PolyMon.Monitors.MonitorStatus.eStatus.Fail
                                NumFailures += 1
                            Case PolyMon.Monitors.MonitorStatus.eStatus.Warning
                                NumWarnings += 1
                        End Select
                        Me.flpMain.Controls.Add(myMonitorPanel)
                    Case PolyMonManager.UserSettings.MonitorViewTypes.Tiles
                        Dim myMonitorPanel As New UCMonitorPanelDetailsView(CInt(rdResults.Item("MonitorID")), True)
                        Select Case myMonitorPanel.CurrentStatus.Status
                            Case PolyMon.Monitors.MonitorStatus.eStatus.Fail
                                NumFailures += 1
                            Case PolyMon.Monitors.MonitorStatus.eStatus.Warning
                                NumWarnings += 1
                        End Select
                        Me.flpMain.Controls.Add(myMonitorPanel)
                End Select
            End While

            If ErrorsWarnings Then
                If RaiseErrors Then RaiseEvent AlertEvent(Me, System.EventArgs.Empty)
            Else
                RaiseEvent AllNominal(Me, System.EventArgs.Empty)
            End If
        Catch ex As Exception
            MsgBox("Error loading Monitor Panels." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Polymon")
        Finally
            If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
            SQLConn.Dispose()
        End Try

    End Sub
#End Region

#Region "Event Handlers"
    Private Sub frmFailuresWarnings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim UserSettings As New UserSettings()
        If UserSettings.FailuresWarningsViewType = PolyMonManager.UserSettings.MonitorViewTypes.List Then
            tbtnViewList.Checked = True
            tbtnViewTiles.Checked = False
        Else
            tbtnViewList.Checked = False
            tbtnViewTiles.Checked = True
        End If
    End Sub
    Private Sub tbtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRefresh.Click
        CType(Me.MdiParent, frmMain).RefreshMonitorStatuses(False, frmMain.StatusForms.FailuresWarnings)
    End Sub
    Private Sub tbtnViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnViewList.Click
        If tbtnViewList.Checked Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim UserSettings As New UserSettings()
        UserSettings.FailuresWarningsViewType = PolyMonManager.UserSettings.MonitorViewTypes.List
        tbtnViewList.Checked = True
        tbtnViewTiles.Checked = False
        RefreshMonitors(False)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tbtnViewTiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnViewTiles.Click
        If tbtnViewTiles.Checked Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim UserSettings As New UserSettings()
        UserSettings.FailuresWarningsViewType = PolyMonManager.UserSettings.MonitorViewTypes.Tiles
        tbtnViewList.Checked = False
        tbtnViewTiles.Checked = True
        RefreshMonitors(False)
        Me.Cursor = Cursors.Default
    End Sub
#End Region

End Class