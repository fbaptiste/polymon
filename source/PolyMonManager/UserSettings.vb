Imports Microsoft.Win32
Imports System.Configuration
Imports System.Xml

Public Class UserSettings
#Region "Private Attributes"
    Private mRefreshIntervalMax As Integer = 0
    Private mRefreshInterval As Integer = 3
    Private mAudibleAlerts As Boolean = False
    Private mAudioAlertFile As String
    Private mBalloonAlerts As Boolean = True
    Private mMDIBackColor As System.Drawing.Color = Color.DeepSkyBlue
    Private mDashboardViewType As MonitorViewTypes = MonitorViewTypes.List
    Private mFailuresWarningsViewType As MonitorViewTypes = MonitorViewTypes.List


    Private mRefreshIntervals As New List(Of TimerInterval)
#End Region

#Region "Public Interface"
    Public Enum MonitorViewTypes As Integer
        List = 0
        Tiles = 1
    End Enum
    Public Sub New()
        LoadData()
    End Sub

    Public Property RefreshIntervalIndex() As Integer
        Get
            Return mRefreshInterval
        End Get
        Set(ByVal value As Integer)
            If value < 0 Or value > mRefreshIntervalMax Then
                Throw New System.Exception("Interval Index must be a number between 0 and " & CStr(mRefreshIntervalMax) & ".")
            Else
                mRefreshInterval = value
                My.Settings.StatusRefreshIntervalIndex = value
                My.Settings.Save()
            End If
        End Set
    End Property
    Public ReadOnly Property RefreshInterval() As TimerInterval
        Get
            Return mRefreshIntervals(mRefreshInterval)
        End Get
    End Property
    Public Property AudibleAlertsEnabled() As Boolean
        Get
            Return mAudibleAlerts
        End Get
        Set(ByVal value As Boolean)
            mAudibleAlerts = value
            My.Settings.AudibleAlerts = value
            My.Settings.Save()
        End Set
    End Property
    Public Property BalloonAlertsEnabled() As Boolean
        Get
            Return mBalloonAlerts
        End Get
        Set(ByVal value As Boolean)
            mBalloonAlerts = value
            My.Settings.BalloonAlerts = value
            My.Settings.Save()
        End Set
    End Property
    Public Property AudioAlertFile() As String
        Get
            Return mAudioAlertFile
        End Get
        Set(ByVal value As String)
            mAudioAlertFile = value
            My.Settings.AudioAlertFile = value
            My.Settings.Save()
        End Set
    End Property
    Public Property MDIBackColor() As System.Drawing.Color
        Get
            Return mMDIBackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            mMDIBackColor = value
            My.Settings.MDIBackColor = value
            My.Settings.Save()
        End Set
    End Property
    Public Property DashboardViewType() As MonitorViewTypes
        Get
            Return mDashboardViewType
        End Get
        Set(ByVal value As MonitorViewTypes)
            mDashboardViewType = value
            My.Settings.DashboardViewType = value
            My.Settings.Save()
        End Set
    End Property

    Public Property FailuresWarningsViewType() As MonitorViewTypes
        Get
            Return mFailuresWarningsViewType
        End Get
        Set(ByVal value As MonitorViewTypes)
            mFailuresWarningsViewType = value
            My.Settings.FailuresWarningsViewType = value
            My.Settings.Save()
        End Set
    End Property

    Public ReadOnly Property RefreshIntervals() As List(Of TimerInterval)
        Get
            Return mRefreshIntervals
        End Get
    End Property

    Public Class TimerInterval
        Private mName As String
        Private mInterval As Integer

        Friend Sub New(ByVal Interval As Integer, ByVal Name As String)
            mName = Name
            mInterval = Interval
        End Sub

        Public ReadOnly Property Interval() As Integer
            Get
                Return mInterval
            End Get
        End Property
        Public ReadOnly Property Name() As String
            Get
                Return mName
            End Get
        End Property
    End Class

    Public Property PanelGroupIsOpen(ByVal PanelGroupID As Integer) As Boolean
        Get
            Dim XMLRoot As XmlDocument
            Dim PanelNode As XmlNode
            XMLRoot = My.Settings.PanelGroupState
            PanelNode = XMLRoot.DocumentElement.SelectSingleNode("Panel[@ID='" & PanelGroupID & "']")
            If PanelNode Is Nothing Then
                Dim Panel As XmlNode = XMLRoot.CreateNode(XmlNodeType.Element, "Panel", "")
                XMLRoot.DocumentElement.AppendChild(Panel)

                Dim ID As XmlNode = XMLRoot.CreateNode(XmlNodeType.Attribute, "ID", "")
                ID.Value = CStr(PanelGroupID)
                Panel.Attributes.SetNamedItem(ID)

                Dim IsOpen As XmlNode = XMLRoot.CreateNode(XmlNodeType.Attribute, "IsOpen", "")
                IsOpen.Value = CStr(True)
                Panel.Attributes.SetNamedItem(IsOpen)

                My.Settings.PanelGroupState = XMLRoot
                My.Settings.Save()
                Return True
            Else
                Try
                    Return CBool(PanelNode.Attributes("IsOpen").Value)
                Catch ex As Exception
                    PanelNode.Attributes("IsOpen").Value = CStr(True)
                    My.Settings.Save()
                    Return True
                End Try
            End If
        End Get
        Set(ByVal value As Boolean)
            Dim XMLRoot As XmlDocument
            Dim PanelNode As XmlNode
            XMLRoot = My.Settings.PanelGroupState
            PanelNode = XMLRoot.DocumentElement.SelectSingleNode("Panel[@ID='" & PanelGroupID & "']")
            If PanelNode Is Nothing Then
                Dim Panel As XmlNode = XMLRoot.CreateNode(XmlNodeType.Element, "Panel", "")
                XMLRoot.DocumentElement.AppendChild(Panel)

                Dim ID As XmlNode = XMLRoot.CreateNode(XmlNodeType.Attribute, "ID", "")
                ID.Value = CStr(PanelGroupID)
                Panel.Attributes.SetNamedItem(ID)

                Dim IsOpen As XmlNode = XMLRoot.CreateNode(XmlNodeType.Attribute, "IsOpen", "")
                IsOpen.Value = CStr(value)
                Panel.Attributes.SetNamedItem(IsOpen)

                My.Settings.PanelGroupState = XMLRoot
                My.Settings.Save()
            Else
                PanelNode.Attributes("IsOpen").Value = CStr(value)
            End If
            My.Settings.Save()
        End Set

    End Property

    Public Sub Refresh()
        LoadData()
    End Sub
#End Region

#Region "Private Methods"
    Private Sub LoadData()
        'Initialize pre-set timer intervals
        BuildRefreshIntervalList()

        mRefreshInterval = My.Settings.StatusRefreshIntervalIndex

        mAudioAlertFile = My.Settings.AudioAlertFile
        mAudibleAlerts = My.Settings.AudibleAlerts
        mBalloonAlerts = My.Settings.BalloonAlerts
        mMDIBackColor = My.Settings.MDIBackColor
        mDashboardViewType = CType(My.Settings.DashboardViewType, MonitorViewTypes)
        mFailuresWarningsViewType = CType(My.Settings.FailuresWarningsViewType, MonitorViewTypes)

        If My.Settings.PanelGroupState Is Nothing Then
            My.Settings.PanelGroupState = New System.Xml.XmlDocument
            My.Settings.PanelGroupState.LoadXml("<PanelGroups/>")
            My.Settings.Save()
        End If
    End Sub
    Private Sub BuildRefreshIntervalList()
        mRefreshIntervals.Add(New TimerInterval(0, "Disabled"))
        mRefreshIntervals.Add(New TimerInterval(15, "15 seconds"))
        mRefreshIntervals.Add(New TimerInterval(30, "30 seconds"))
        mRefreshIntervals.Add(New TimerInterval(60, "1 minute"))
        mRefreshIntervals.Add(New TimerInterval(120, "2 minutes"))
        mRefreshIntervals.Add(New TimerInterval(300, "5 minutes"))
        mRefreshIntervals.Add(New TimerInterval(900, "15 minutes"))
        mRefreshIntervals.Add(New TimerInterval(1800, "30 minutes"))

        mRefreshIntervalMax = 7
    End Sub
#End Region

End Class
