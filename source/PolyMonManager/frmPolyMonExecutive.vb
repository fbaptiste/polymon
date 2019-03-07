Imports System.ServiceProcess

Public Class frmPolyMonExecutive

#Region "Private Attributes"
    Private mSysSettings As PolyMon.General.SysSettings
    Private Const mServiceName As String = "PolyMonExecutive"
#End Region

#Region "Event Handlers"
    Private Sub frmPolyMonExecutive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSysSettings()
        LoadExecutiveStatus()
    End Sub

    Private Sub btnExecutiveStatusRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecutiveStatusRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        LoadExecutiveStatus()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnExecutiveStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecutiveStart.Click
        Me.Cursor = Cursors.WaitCursor
        StartService()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnExecutiveStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecutiveStop.Click
        Me.Cursor = Cursors.WaitCursor
        StopService()
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Private Methods"
    Private Sub LoadSysSettings()
        Try
            mSysSettings = New PolyMon.General.SysSettings
        Catch ex As Exception
            MsgBox("Error retrieving data from database:" & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.InnerException.Message, MsgBoxStyle.Exclamation, "PolyMon Error")
        End Try
    End Sub
    Private Sub LoadExecutiveStatus()
        Dim Host As String = mSysSettings.ServiceServer
        Dim sc As ServiceController
        Dim ServiceStatus As ServiceControllerStatus

        Try
            sc = New ServiceController(mServiceName, Host)
            ServiceStatus = sc.Status
            Select Case ServiceStatus
                Case ServiceControllerStatus.Stopped
                    Me.lblExecutiveStatus.Text = "Service Stopped."
                    Me.pcbExecutiveStatus.Image = My.Resources.ServiceStopped.ToBitmap

                    Me.btnExecutiveStart.Enabled = True
                    Me.btnExecutiveStop.Enabled = False
                Case ServiceControllerStatus.Running
                    Me.lblExecutiveStatus.Text = "Service Running."
                    Me.pcbExecutiveStatus.Image = My.Resources.ServiceStarted.ToBitmap
                    Me.btnExecutiveStart.Enabled = False
                    Me.btnExecutiveStop.Enabled = True
                Case ServiceControllerStatus.Paused
                    Me.lblExecutiveStatus.Text = "Service Paused."
                    Me.pcbExecutiveStatus.Image = My.Resources.ServicePaused.ToBitmap
                    Me.btnExecutiveStart.Enabled = True
                    Me.btnExecutiveStop.Enabled = False
                Case ServiceControllerStatus.PausePending
                    Me.lblExecutiveStatus.Text = "Pausing Service..."
                    Me.pcbExecutiveStatus.Image = My.Resources.ServiceStarted.ToBitmap
                    Me.btnExecutiveStart.Enabled = False
                    Me.btnExecutiveStop.Enabled = False
                Case ServiceControllerStatus.StartPending
                    Me.lblExecutiveStatus.Text = "Starting Service..."
                    Me.pcbExecutiveStatus.Image = My.Resources.ServiceStopped.ToBitmap
                    Me.btnExecutiveStart.Enabled = False
                    Me.btnExecutiveStop.Enabled = False
                Case ServiceControllerStatus.StopPending
                    Me.lblExecutiveStatus.Text = "Stopping Service..."
                    Me.pcbExecutiveStatus.Image = My.Resources.ServiceStarted.ToBitmap
                    Me.btnExecutiveStart.Enabled = False
                    Me.btnExecutiveStop.Enabled = False
                Case ServiceControllerStatus.ContinuePending
                    Me.lblExecutiveStatus.Text = "Resuming service from Pause..."
                    Me.pcbExecutiveStatus.Image = My.Resources.ServicePaused.ToBitmap
                    Me.btnExecutiveStart.Enabled = False
                    Me.btnExecutiveStop.Enabled = False
                Case Else
                    Me.lblExecutiveStatus.Text = "Unknown Service Status"
                    Me.pcbExecutiveStatus.Image = My.Resources.ServiceUnknown.ToBitmap
                    Me.btnExecutiveStart.Enabled = False
                    Me.btnExecutiveStop.Enabled = False
            End Select

            Me.lblServiceHost.Text = sc.MachineName

            Dim ParentKey As String = "SYSTEM\CurrentControlSet\Services\PolyMonExecutive"
            'Image Path: Registry: HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\PolyMonExecutive\ImagePath
            Dim ImagePath As String = ReadRegistryKey(Host, ParentKey, "ImagePath")
            Me.lblPath.Text = ImagePath

            'Start Type: Registry: HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\PolyMonExecutive\Start
            '0=Boot, 1=System, 2=Automatic, 3=Manual, 4=Disabled
            Dim StartType As Integer = CInt(ReadRegistryKey(Host, ParentKey, "Start"))
            Select Case StartType
                Case 0 : Me.lblStartupType.Text = "Boot"
                Case 1 : Me.lblStartupType.Text = "System"
                Case 2 : Me.lblStartupType.Text = "Automatic"
                Case 3 : Me.lblStartupType.Text = "Manual"
                Case 4 : Me.lblStartupType.Text = "Disabled"
                Case Else : Me.lblStartupType.Text = "Unknown"
            End Select

            'Log on as: Registry: HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\PolyMonExecutive\ObjectName
            'LocalSystem or Account Name
            Dim LogOnAs As String = ReadRegistryKey(Host, ParentKey, "ObjectName")
            If LogOnAs = "LocalSystem" Then
                Me.lblLogOnAs.Text = "Local System"
            Else
                Me.lblLogOnAs.Text = LogOnAs
            End If

        Catch ex As Exception
            Me.lblExecutiveStatus.Text = "Unknown Service Status"
            Me.pcbExecutiveStatus.Image = My.Resources.ServiceUnknown.ToBitmap
            Me.btnExecutiveStart.Enabled = False
            Me.btnExecutiveStop.Enabled = False
            MsgBox("Could not query PolyMon Executive Service." & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.InnerException.Message, MsgBoxStyle.Exclamation, "PolyMon Error")
        Finally
            Me.pcbExecutiveStatus.Refresh()
            Me.lblExecutiveStatus.Refresh()
        End Try

    End Sub
    Private Sub StartService()
        Dim Host As String = mSysSettings.ServiceServer
        Dim sc As ServiceController
        Dim TimeOut As New TimeSpan(0, 0, 30)

        Try
            sc = New ServiceController(mServiceName, Host)
            sc.Start()
            sc.WaitForStatus(ServiceControllerStatus.Running, TimeOut)
            LoadExecutiveStatus()
        Catch ex As Exception
            MsgBox("Error Starting service..." & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "Polymon Executive Error...")
        End Try
    End Sub
    Private Sub StopService()
        Dim Host As String = mSysSettings.ServiceServer
        Dim sc As ServiceController
        Dim TimeOut As New TimeSpan(0, 0, 30)

        Try
            sc = New ServiceController(mServiceName, Host)
            sc.Stop()
            sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeOut)
            LoadExecutiveStatus()
        Catch ex As Exception
            MsgBox("Error Stopping service..." & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.InnerException.Message, MsgBoxStyle.Exclamation, "Polymon Executive Error...")
        End Try
    End Sub

    Private Function ReadRegistryKey(ByVal Host As String, ByVal ParentRegistryKey As String, ByVal RegistryKey As String) As String
        Dim Value As String = Nothing
        Dim Key As Microsoft.Win32.RegistryKey = Nothing

        Dim HKLMKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine

        Try
            Key = Microsoft.Win32.RegistryKey.OpenRemoteBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Host).OpenSubKey(ParentRegistryKey)
            Value = Key.GetValue(RegistryKey).ToString()
            Key.Close()
        Catch ex As Exception
            Return Nothing
        End Try

        Return Value
    End Function
#End Region


End Class