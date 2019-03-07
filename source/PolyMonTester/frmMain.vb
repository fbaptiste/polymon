Imports System
Imports PolyMon.Monitors
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class MainForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnRefreshMonitorList As System.Windows.Forms.Button
    Friend WithEvents btnRunTests As System.Windows.Forms.Button
    Friend WithEvents txtResults As System.Windows.Forms.TextBox
    Friend WithEvents lstMonitors As System.Windows.Forms.ComboBox
    Friend WithEvents btnTestOperatorClass As System.Windows.Forms.Button
    Friend WithEvents btnTestMonitorOperatorsClass As System.Windows.Forms.Button
    Friend WithEvents btnMonitorCreate As System.Windows.Forms.Button
    Friend WithEvents btnMonitorType As System.Windows.Forms.Button
    Friend WithEvents btnSysSettings As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnRefreshMonitorList = New System.Windows.Forms.Button
        Me.btnRunTests = New System.Windows.Forms.Button
        Me.txtResults = New System.Windows.Forms.TextBox
        Me.lstMonitors = New System.Windows.Forms.ComboBox
        Me.btnTestOperatorClass = New System.Windows.Forms.Button
        Me.btnTestMonitorOperatorsClass = New System.Windows.Forms.Button
        Me.btnMonitorCreate = New System.Windows.Forms.Button
        Me.btnMonitorType = New System.Windows.Forms.Button
        Me.btnSysSettings = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnRefreshMonitorList
        '
        Me.btnRefreshMonitorList.Location = New System.Drawing.Point(296, 12)
        Me.btnRefreshMonitorList.Name = "btnRefreshMonitorList"
        Me.btnRefreshMonitorList.Size = New System.Drawing.Size(68, 20)
        Me.btnRefreshMonitorList.TabIndex = 1
        Me.btnRefreshMonitorList.Text = "Refresh"
        '
        'btnRunTests
        '
        Me.btnRunTests.Location = New System.Drawing.Point(20, 48)
        Me.btnRunTests.Name = "btnRunTests"
        Me.btnRunTests.Size = New System.Drawing.Size(68, 24)
        Me.btnRunTests.TabIndex = 3
        Me.btnRunTests.Text = "Run"
        '
        'txtResults
        '
        Me.txtResults.Location = New System.Drawing.Point(20, 84)
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.ReadOnly = True
        Me.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResults.Size = New System.Drawing.Size(364, 280)
        Me.txtResults.TabIndex = 5
        Me.txtResults.Text = ""
        '
        'lstMonitors
        '
        Me.lstMonitors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstMonitors.Location = New System.Drawing.Point(20, 12)
        Me.lstMonitors.Name = "lstMonitors"
        Me.lstMonitors.Size = New System.Drawing.Size(264, 21)
        Me.lstMonitors.TabIndex = 6
        '
        'btnTestOperatorClass
        '
        Me.btnTestOperatorClass.Location = New System.Drawing.Point(24, 380)
        Me.btnTestOperatorClass.Name = "btnTestOperatorClass"
        Me.btnTestOperatorClass.Size = New System.Drawing.Size(96, 24)
        Me.btnTestOperatorClass.TabIndex = 7
        Me.btnTestOperatorClass.Text = "Operator"
        '
        'btnTestMonitorOperatorsClass
        '
        Me.btnTestMonitorOperatorsClass.Location = New System.Drawing.Point(128, 380)
        Me.btnTestMonitorOperatorsClass.Name = "btnTestMonitorOperatorsClass"
        Me.btnTestMonitorOperatorsClass.Size = New System.Drawing.Size(96, 24)
        Me.btnTestMonitorOperatorsClass.TabIndex = 8
        Me.btnTestMonitorOperatorsClass.Text = "List Operators"
        '
        'btnMonitorCreate
        '
        Me.btnMonitorCreate.Location = New System.Drawing.Point(232, 380)
        Me.btnMonitorCreate.Name = "btnMonitorCreate"
        Me.btnMonitorCreate.Size = New System.Drawing.Size(96, 24)
        Me.btnMonitorCreate.TabIndex = 9
        Me.btnMonitorCreate.Text = "Monitor Create"
        '
        'btnMonitorType
        '
        Me.btnMonitorType.Location = New System.Drawing.Point(24, 416)
        Me.btnMonitorType.Name = "btnMonitorType"
        Me.btnMonitorType.Size = New System.Drawing.Size(96, 24)
        Me.btnMonitorType.TabIndex = 10
        Me.btnMonitorType.Text = "Monitor Type"
        '
        'btnSysSettings
        '
        Me.btnSysSettings.Location = New System.Drawing.Point(132, 416)
        Me.btnSysSettings.Name = "btnSysSettings"
        Me.btnSysSettings.Size = New System.Drawing.Size(96, 24)
        Me.btnSysSettings.TabIndex = 11
        Me.btnSysSettings.Text = "Sys Settings"
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(396, 458)
        Me.Controls.Add(Me.btnSysSettings)
        Me.Controls.Add(Me.btnMonitorType)
        Me.Controls.Add(Me.btnMonitorCreate)
        Me.Controls.Add(Me.btnTestMonitorOperatorsClass)
        Me.Controls.Add(Me.btnTestOperatorClass)
        Me.Controls.Add(Me.lstMonitors)
        Me.Controls.Add(Me.txtResults)
        Me.Controls.Add(Me.btnRunTests)
        Me.Controls.Add(Me.btnRefreshMonitorList)
        Me.Name = "MainForm"
        Me.Text = "PolyMon Tester"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private mSQLConn As String

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'mSQLConn = CStr(System.Configuration.ConfigurationSettings.AppSettings("SQLConn"))
        mSQLConn = CStr(ConfigurationManager.AppSettings("SQLConn"))
        LoadMonitorList()
    End Sub
    Private Sub btnRefreshMonitorList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshMonitorList.Click
        LoadMonitorList()
    End Sub
    Private Sub btnRunTests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunTests.Click
        Dim myMonitor As MonitorExecutor

        myMonitor = CType(Me.lstMonitors.SelectedItem, MonitorExecutor)
        myMonitor.RunMonitor()

        txtResults.Text = "Status: " & myMonitor.Status.ToString
        txtResults.Text &= vbCrLf & "Status Message: " & myMonitor.StatusMessage


        Dim Counter As MonitorExecutor.Counter
        If myMonitor.MonitorCounters.Count > 0 Then
            txtResults.Text &= vbCrLf & vbCrLf & "Counters:"
            For Each Counter In myMonitor.MonitorCounters
                txtResults.Text &= vbCrLf & Counter.CounterName & " = " & CStr(Counter.CounterValue)
            Next
        End If
    End Sub

    Private Sub LoadMonitorList()
        Dim SQLConn As New SqlConnection(mSQLConn)
        Dim SP As String = "polymon_sel_MonitorList"

        Dim sqlCmd As New SqlCommand
        sqlCmd.Connection = SQLConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = SP

        Dim MonitorID As Integer
        Dim MonitorName As String
        Dim MonitorAssembly As String
        Dim EditorAssembly As String
        Dim MonitorType As String
        Dim myMonitor As PolyMon.Monitors.MonitorExecutor
        Try
            Me.lstMonitors.Items.Clear()
            Me.lstMonitors.DisplayMember = "MonitorName"
            SQLConn.Open()
            Dim drMonitorList As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
            With drMonitorList
                While .Read()
                    MonitorID = CInt(.Item("MonitorID"))
                    MonitorName = CStr(.Item("Name"))
                    MonitorType = CStr(.Item("MonitorType"))
                    MonitorAssembly = CStr(.Item("MonitorAssembly"))
                    EditorAssembly = CStr(.Item("EditorAssembly"))

                    myMonitor = LoadMonitorObject(MonitorID, MonitorAssembly)
                    myMonitor.ManualOverride = False
                    Me.lstMonitors.Items.Add(myMonitor)
                End While
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQLConn.Close()
            SQLConn.Dispose()
        End Try
    End Sub
    Private Function LoadMonitorObject(ByVal MonitorID As Integer, ByVal MonitorAssembly As String) As PolyMon.Monitors.MonitorExecutor
        Dim myMonitor As PolyMon.Monitors.MonitorExecutor = Nothing

        Dim asm As Reflection.Assembly
        Dim MonitorType As Type = Nothing
        Dim ty As Type
        Dim types() As Type
        Dim ci As Reflection.ConstructorInfo
        Dim params() As Object
        Dim obj As Object
        Dim apppath As String = System.AppDomain.CurrentDomain.BaseDirectory()

        asm = Reflection.Assembly.LoadFrom(apppath & MonitorAssembly)
        For Each ty In asm.GetExportedTypes
            If ty.BaseType.FullName = GetType(PolyMon.Monitors.MonitorExecutor).FullName Then
                MonitorType = ty
                Exit For
            End If
        Next
        If Not (MonitorType Is Nothing) Then
            types = New Type() {GetType(System.Int32)}
            ci = MonitorType.GetConstructor(types)
            params = New Object() {MonitorID}
            obj = ci.Invoke(params)
            myMonitor = DirectCast(obj, PolyMon.Monitors.MonitorExecutor)
        End If

        Return myMonitor
    End Function

    Private Sub btnTestOperatorClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestOperatorClass.Click
        Dim PMOperator As PolyMon.Operators.PMOperator
        Dim OperatorID As Integer

        Try
            'Create/Update/Delete Operator
            PMOperator = New PolyMon.Operators.PMOperator
            With PMOperator
                .Name = "Fred Baptiste"
                .IsEnabled = True
                .EmailAddress = "fbaptiste@gmail.com"
                .OfflineTime.StartTime = "1:00"
                .OfflineTime.EndTime = "3:00"
                .IncludeMessageBody = True

                .Save()

                OperatorID = .OperatorID
            End With

            PMOperator = Nothing
            PMOperator = New PolyMon.Operators.PMOperator(OperatorID)
            PMOperator.Name = "F. Baptiste"
            PMOperator.Save()

            PMOperator.Delete()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnTestMonitorOperatorsClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestMonitorOperatorsClass.Click
        Dim MonitorID As Integer = 1
        Dim MonitorOperators As New PolyMon.Operators.MonitorOperators(MonitorID)
        Dim PMOperator As PolyMon.Operators.PMOperator

        For Each PMOperator In MonitorOperators
            MsgBox(PMOperator.Name)
        Next

        MsgBox("Adding Operator ID=13 to Monitor")
        PMOperator = New PolyMon.Operators.PMOperator(13)
        MonitorOperators.Add(PMOperator)
        For Each PMOperator In MonitorOperators
            MsgBox(PMOperator.Name)
        Next

        MsgBox("Removing Operator ID=13 from Monitor")
        MonitorOperators.Remove(PMOperator)
        For Each PMOperator In MonitorOperators
            MsgBox(PMOperator.Name)
        Next


    End Sub

    Private Sub btnMonitorCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonitorCreate.Click
        Dim Monitor As New PolyMon.Monitors.MonitorMetadata

        With Monitor
            .MonitorName = "Test"
            .MonitorTypeID = 1
            .MonitorXMLString = "<PingMonitor><Host>xpfbaptiste</Host><NumTries>5</NumTries><MaxFail>2</MaxFail><Timeout>2000</Timeout><TTL>32</TTL><DataSize>32</DataSize></PingMonitor>"
            .OfflineTime1.StartTime = "01:00"
            .OfflineTime1.EndTime = "02:00"
            .OfflineTime2.StartTime = "03:00"
            .OfflineTime2.EndTime = "04:00"
            .MessageSubjectTemplate = "<SubjectTemplate>"
            .MessageBodyTemplate = "<%BodyTemplate%>"
            .TriggerMod = 1
            .Enabled = True

            .AlertAfterEveryNEvent = 1
            .AlertAfterEveryNewFailure = True
            .AlertAfterEveryNFailures = 2
            .AlertAfterEveryFailToOK = True
            .AlertAfterEveryNewWarning = True
            .AlertAfterEveryNWarnings = 3
            .AlertAfterEveryWarnToOK = True

            .Save()
        End With


        Dim MonitorTester As PolyMon.Monitors.MonitorExecutor
        MonitorTester = Me.LoadMonitorObject(Monitor.MonitorID, Monitor.MonitorAssembly)

        MonitorTester.RunMonitor()

        txtResults.Text = "Status: " & MonitorTester.Status.ToString
        txtResults.Text &= vbCrLf & "Status Message: " & MonitorTester.StatusMessage


        Dim Counter As MonitorExecutor.Counter
        If MonitorTester.MonitorCounters.Count > 0 Then
            txtResults.Text &= vbCrLf & vbCrLf & "Counters:"
            For Each Counter In MonitorTester.MonitorCounters
                txtResults.Text &= vbCrLf & Counter.CounterName & " = " & CStr(Counter.CounterValue)
            Next
        End If

        Monitor.Delete()
        Monitor = Nothing
    End Sub

    Private Sub btnMonitorType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonitorType.Click
        Dim MonitorTypes As New PolyMon.MonitorTypes.MonitorTypes
        Dim MonitorType As PolyMon.MonitorTypes.MonitorType

        For Each MonitorType In MonitorTypes
            MsgBox(MonitorType.Name)
        Next

        MsgBox("Creating new Monitor Type")
        Dim NewMonitorType As New PolyMon.MonitorTypes.MonitorType
        With NewMonitorType
            .Name = "Test"
            .MonitorAssembly = "1.dll"
            .EditorAssembly = "2.dll"
            .XMLTemplate = Nothing

            .Save()
        End With

        MonitorTypes.Refresh()
        For Each MonitorType In MonitorTypes
            MsgBox(MonitorType.Name)
        Next

        MsgBox("Deleting newly create Monitor Type")
        NewMonitorType.Delete()
        MonitorTypes.Refresh()
        For Each MonitorType In MonitorTypes
            MsgBox(MonitorType.Name)
        Next

    End Sub


    Private Sub btnSysSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSysSettings.Click
        Dim Sys As New PolyMon.General.SysSettings

        txtResults.Text = "Name: " & Sys.Name
        txtResults.Text &= vbCrLf & "IsEnabled: " & Sys.IsEnabled
        txtResults.Text &= vbCrLf & "ServiceServer: " & Sys.ServiceServer
        txtResults.Text &= vbCrLf & "MainTimerInterval: " & Sys.MainTimerInterval
        txtResults.Text &= vbCrLf & "UseInternalSMTP: " & Sys.UseInternalSMTP
        txtResults.Text &= vbCrLf & "SMTPFromName: " & Sys.SMTPFromName
        txtResults.Text &= vbCrLf & "SMTPFromAddress: " & Sys.SMTPFromAddress
        txtResults.Text &= vbCrLf & "ExtSMTPServer: " & Sys.ExtSMTPServer
        txtResults.Text &= vbCrLf & "ExtSMTPPort: " & Sys.ExtSMTPPort
        txtResults.Text &= vbCrLf & "ExtSMTPUserID: " & Sys.ExtSMTPUserID
        txtResults.Text &= vbCrLf & "ExtSMTPPwd: " & Sys.ExtSMTPPwd

        Try
			Sys.UseInternalSMTP = True
            'Sys.Name = Nothing
            'Sys.ServiceServer = Nothing
            'Sys.MainTimerInterval = 0
            'Sys.SetSMTPFrom(Nothing, Nothing)
            'Sys.SetExtSMTP("mysmtpserver", 10, Nothing, "something")
            Sys.Save()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sys = Nothing
        End Try
    End Sub
End Class
