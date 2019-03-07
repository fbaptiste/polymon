Imports System.Data.SqlClient
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Collections.ObjectModel

Namespace Dashboard

    Public Class PanelGroups
#Region "Private Attributes"
        Private mSQLConn As String = Nothing
        Private mPanelGroups As List(Of PanelGroup)
#End Region

#Region "Public Interface"
        Public Sub New()
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
            mPanelGroups = GetGroups()
        End Sub
        Public Function AddGroup(ByVal GroupName As String, ByVal DisplayOrder As Integer) As PanelGroup
            Dim PanelGroup As New PanelGroup(GroupName, DisplayOrder)
            mPanelGroups.Sort()
            Return PanelGroup
        End Function
        Public Sub RemoveGroup(ByVal PanelGroup As PanelGroup)
            'Delete from database and remove from internal collection
            Try
                DeleteGroup(PanelGroup)
                Dim myIndex As Integer = -1
                Dim i As Integer
                For i = 0 To mPanelGroups.Count - 1
                    If mPanelGroups.Item(i).GroupID = PanelGroup.GroupID Then
                        myIndex = i
                        Exit For
                    End If
                Next
                If myIndex > -1 Then mPanelGroups.RemoveAt(myIndex)
                mPanelGroups.Sort()
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            End Try
        End Sub
        Public ReadOnly Property List() As ReadOnlyCollection(Of PanelGroup)
            Get
                mPanelGroups.Sort()
                Return mPanelGroups.AsReadOnly()
            End Get
        End Property
#End Region

#Region "Private Methods"
        Private Function GetGroups() As List(Of PanelGroup)
            GetGroups = New List(Of PanelGroup)

            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_sel_DashboardGroups"

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
            End With

            Try
                Dim GroupID As Integer
                Dim PanelGroup As PanelGroup

                SQLConn.Open()
                Dim rd As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                While rd.Read()
                    GroupID = CInt(rd.Item("groupID"))
                    PanelGroup = New PanelGroup(GroupID)
                    GetGroups.Add(PanelGroup)
                End While
            Catch ex As Exception
                GetGroups.Clear()
                GetGroups = Nothing
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Function
        Private Sub DeleteGroup(ByVal PanelGroup As PanelGroup)
            Dim SqlConn As New SqlConnection(mSQLConn)

            Dim prmGroupID As New SqlParameter
            With prmGroupID
                .ParameterName = "@GroupID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = PanelGroup.GroupID
            End With

            Dim SQLCmd As New SqlCommand
            With SQLCmd
                .CommandText = "polymon_del_DeleteDashboardGroup"
                .CommandType = CommandType.StoredProcedure
                .Connection = SqlConn
                .Parameters.Add(prmGroupID)
            End With

            Try
                SqlConn.Open()
                SQLCmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SqlConn.State <> ConnectionState.Closed Then SqlConn.Close()
                SqlConn.Dispose()
            End Try
        End Sub
#End Region
    End Class

    Public Class PanelGroup
        Implements IComparable

#Region "Private Attributes"
        Private mGroupID As Integer
        Private mName As String
        Private mDisplayOrder As Integer
        Private mIsNew As Boolean = False
        Private mSQLCOnn As String = Nothing
#End Region

#Region "Public Interface"
        Public ReadOnly Property GroupID() As Integer
            Get
                Return mGroupID
            End Get
        End Property
        Public Property Name() As String
            Get
                Return mName
            End Get
            Set(ByVal value As String)
                If value = Nothing OrElse value.Trim.Length = 0 Then
                    Throw New System.Exception("Group Name cannot be blank.")
                Else
                    If value.Length > 100 Then
                        Throw New System.Exception("Group Name cannot exceed 100 characters")
                    Else
                        mName = value.Trim()
                    End If
                End If
            End Set
        End Property
        Public Property DisplayOrder() As Integer
            Get
                Return mDisplayOrder
            End Get
            Set(ByVal value As Integer)
                mDisplayOrder = value
            End Set
        End Property

        Public Sub New(ByVal GroupID As Integer)
            'Retrieve existing record
            mSQLCOnn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
            LoadGroup(GroupID)
        End Sub
        Public Sub New(ByVal Name As String, ByVal DisplayOrder As Integer)
            'Create new record
            mSQLCOnn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
            Me.Name = Name
            Me.DisplayOrder = DisplayOrder
            mIsNew = True
        End Sub

        Public ReadOnly Property Panels() As ReadOnlyCollection(Of MonitorPanel)
            Get
                If Not (mIsNew) Then
                    Return New MonitorPanels(mGroupID).List
                Else
                    Return Nothing
                End If
            End Get
        End Property
        Public ReadOnly Property AvailableMonitors() As ReadOnlyCollection(Of PolyMon.Monitors.MonitorMetadata)
            Get
                Dim Monitors As New List(Of PolyMon.Monitors.MonitorMetadata)
                Monitors.Clear()

                Dim SQLConn As New SqlConnection(mSQLConn)
                Dim sp As String = "polymon_sel_DashboardGroupAvailableMonitors"



                Dim prmGroupID As New SqlParameter
                With prmGroupID
                    .ParameterName = "@GroupID"
                    .Direction = ParameterDirection.Input
                    .SqlDbType = SqlDbType.Int
                    .Value = mGroupID
                End With

                Dim sqlCmd As New SqlCommand
                With sqlCmd
                    .Connection = SQLConn
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = sp
                    .Parameters.Add(prmGroupID)
                End With

                Try
                    Dim MonitorID As Integer
                    Dim MonitorMetadata As PolyMon.Monitors.MonitorMetadata

                    SQLConn.Open()
                    Dim rd As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                    While rd.Read()
                        MonitorID = CInt(rd.Item("MonitorID"))
                        MonitorMetadata = New PolyMon.Monitors.MonitorMetadata(MonitorID)
                        Monitors.Add(MonitorMetadata)
                    End While
                    Return Monitors.AsReadOnly()
                Catch ex As Exception
                    AvailableMonitors = Nothing
                    Throw New System.Exception(ex.Message, ex)
                Finally
                    If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                    SQLConn.Dispose()
                End Try
            End Get
        End Property

        Public Sub Save()
            SaveGroup()
        End Sub
#End Region

#Region "Private Methods"
        Private Sub LoadGroup(ByVal GroupID As Integer)
            Dim SQLConn As New SqlConnection(mSQLCOnn)
            Dim sp As String = "polymon_sel_DashboardGroup"

            mGroupID = GroupID
            mIsNew = False

            Dim prmGroupID As New SqlParameter
            With prmGroupID
                .ParameterName = "@GroupID"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.Int
                .Value = GroupID
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
                .Parameters.Add(prmGroupID)
            End With

            Try
                SQLConn.Open()
                Dim rd As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                While rd.Read()
                    mName = CStr(rd.Item("Name"))
                    mDisplayOrder = CInt(rd.Item("DisplayOrder"))
                End While
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Sub
        Private Sub SaveGroup()
            Dim SQLConn As New SqlConnection(mSQLCOnn)
            Dim sp As String = "polymon_hyb_SaveDashboardGroup"

            Dim prmGroupID As New SqlParameter
            With prmGroupID
                .ParameterName = "@GroupID"
                .Direction = ParameterDirection.InputOutput
                .SqlDbType = SqlDbType.Int
                If mIsNew Then
                    .Value = System.Convert.DBNull
                Else
                    .Value = mGroupID
                End If
            End With

            Dim prmName As New SqlParameter
            With prmName
                .ParameterName = "@Name"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.VarChar
                .Size = 100
                .Value = mName
            End With

            Dim prmDisplayOrder As New SqlParameter
            With prmDisplayOrder
                .ParameterName = "@DisplayOrder"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.Int
                .Value = mDisplayOrder
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp

                .Parameters.Add(prmGroupID)
                .Parameters.Add(prmName)
                .Parameters.Add(prmDisplayOrder)
            End With

            Try
                SQLConn.Open()
                sqlCmd.ExecuteNonQuery()
                If mIsNew Then mGroupID = CInt(prmGroupID.Value)
                mIsNew = False
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Sub
#End Region

#Region "IComparable Implementation"
        Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
            If obj Is Nothing Then Return 1
            Dim other As PanelGroup = DirectCast(obj, PanelGroup)
            If other.DisplayOrder < Me.DisplayOrder Then
                Return 1
            ElseIf other.DisplayOrder = Me.DisplayOrder Then
                Return 0
            Else
                Return -1
            End If

        End Function
#End Region
    End Class


    Public Class MonitorPanels

#Region "Private Attributes"
        Dim mMonitorPanels As List(Of MonitorPanel)
        Dim mGroupID As Integer

        Private mSQLConn As String = Nothing
#End Region

#Region "Public Interface"
        Public Sub New(ByVal GroupID As Integer)
            'Maintain an internal list of sorted MonitorPanels for specified GroupID
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

            mMonitorPanels = GetPanels(GroupID)
        End Sub
        Public Function AddPanel(ByVal MonitorID As Integer, ByVal DisplayOrder As Integer) As Integer
            Dim MonitorPanel As MonitorPanel

            Try
                MonitorPanel = New MonitorPanel(mGroupID, MonitorID, DisplayOrder)
                mMonitorPanels.Add(MonitorPanel)
                Return MonitorPanel.PanelID
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            End Try
        End Function
        Public Sub RemovePanel(ByVal MonitorPanel As MonitorPanel)
            'Delete from database and remove from internal collection
            Try
                DeletePanel(MonitorPanel)
                'Find panel in list and remove it from the list
                Dim RemoveIndex As Integer = -1
                For Each Panel As MonitorPanel In mMonitorPanels
                    If Panel.PanelID = MonitorPanel.PanelID Then
                        RemoveIndex = mMonitorPanels.IndexOf(Panel)
                        Exit For
                    End If
                Next
                If RemoveIndex > -1 Then mMonitorPanels.RemoveAt(RemoveIndex)

                mMonitorPanels.Sort()
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            End Try
        End Sub
        Public ReadOnly Property List() As ReadOnlyCollection(Of MonitorPanel)
            Get
                mMonitorPanels.Sort()
                Return mMonitorPanels.AsReadOnly()
            End Get
        End Property
#End Region

#Region "Private Methods"
        Private Function GetPanels(ByVal GroupID As Integer) As List(Of MonitorPanel)
            GetPanels = New List(Of MonitorPanel)

            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_sel_DashboardGroupPanels"

            mGroupID = GroupID

            Dim prmGroupID As New SqlParameter
            With prmGroupID
                .ParameterName = "@GroupID"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.Int
                .Value = GroupID
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
                .Parameters.Add(prmGroupID)
            End With

            Try
                Dim PanelID As Integer
                Dim MonitorPanel As MonitorPanel

                SQLConn.Open()
                Dim rd As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                While rd.Read()
                    PanelID = CInt(rd.Item("PanelID"))
                    MonitorPanel = New MonitorPanel(PanelID)
                    GetPanels.Add(MonitorPanel)
                End While
            Catch ex As Exception
                GetPanels.Clear()
                GetPanels = Nothing
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Function
        Private Sub DeletePanel(ByVal MonitorPanel As MonitorPanel)
            Dim SqlConn As New SqlConnection(mSQLConn)

            Dim prmPanelID As New SqlParameter
            With prmPanelID
                .ParameterName = "@PanelID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = MonitorPanel.PanelID
            End With

            Dim SQLCmd As New SqlCommand
            With SQLCmd
                .CommandText = "polymon_del_DeleteDashboardPanel"
                .CommandType = CommandType.StoredProcedure
                .Connection = SqlConn
                .Parameters.Add(prmPanelID)
            End With

            Try
                SqlConn.Open()
                SQLCmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SqlConn.State <> ConnectionState.Closed Then SqlConn.Close()
                SqlConn.Dispose()
            End Try
        End Sub
#End Region

    End Class
    Public Class MonitorPanel
        Implements IComparable

#Region "Private Attributes"
        Private mIsPanel As Boolean = True
        Private mPanelID As Integer
        Private mGroupID As Integer
        Private mMonitorID As Integer
        Private mDisplayOrder As Integer
        Private mIsNew As Boolean = False
        Private mSQLConn As String = Nothing
        Private mMonitorName As String = Nothing
        Private mMonitorType As String = Nothing
#End Region

#Region "Public Interface"
        Public ReadOnly Property PanelID() As Integer
            Get
                Return mPanelID
            End Get
        End Property
        Public ReadOnly Property GroupID() As Integer
            Get
                Return mGroupID
            End Get
        End Property
        Public ReadOnly Property MonitorID() As Integer
            Get
                Return mMonitorID
            End Get
        End Property
        Public Property DisplayOrder() As Integer
            Get
                Return mDisplayOrder
            End Get
            Set(ByVal value As Integer)
                mDisplayOrder = value
            End Set
        End Property
        Public ReadOnly Property MonitorName() As String
            Get
                Return mMonitorName
            End Get
        End Property
        Public ReadOnly Property MonitorType() As String
            Get
                Return mMonitorType
            End Get
        End Property
        Public Sub New(ByVal PanelID As Integer)
            'Retrieve an existing Monitor Panel
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
            LoadPanel(PanelID)
        End Sub
        Public Sub New(ByVal MonitorID As Integer, ByVal UseMonitorID As Boolean)
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
            LoadMonitor(MonitorID)
        End Sub
        Public Sub New(ByVal GroupID As Integer, ByVal MonitorID As Integer, ByVal DisplayOrder As Integer)
            'Create a new Monitor Panel
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
            Me.mGroupID = GroupID
            Me.mMonitorID = MonitorID
            Me.mDisplayOrder = DisplayOrder
            mIsPanel = True
            mIsNew = True
        End Sub
        Public Sub Save()
            If mIsPanel Then SavePanel()
        End Sub
#End Region

#Region "Private Methods"
        Private Sub LoadPanel(ByVal PanelID As Integer)
            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_sel_DashboardPanel"

            mIsPanel = True
            mPanelID = PanelID
            mIsNew = False

            Dim prmPanelID As New SqlParameter
            With prmPanelID
                .ParameterName = "@PanelID"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.Int
                .Value = PanelID
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
                .Parameters.Add(prmPanelID)
            End With

            Try
                SQLConn.Open()
                Dim rd As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                While rd.Read()
                    mGroupID = CInt(rd.Item("GroupID"))
                    mMonitorID = CInt(rd.Item("MonitorID"))
                    mDisplayOrder = CInt(rd.Item("DisplayOrder"))
                    mMonitorName = CStr(rd.Item("MonitorName"))
                    mMonitorType = CStr(rd.Item("MonitorType"))
                End While
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Sub
        Private Sub LoadMonitor(ByVal MonitorID As Integer)
            mIsPanel = False
            'Load Monitor metadata from Monitor table, not from Panel table
            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_sel_MonitorMetadata"

            mIsPanel = False
            mPanelID = -1
            mIsNew = False

            mMonitorID = MonitorID
            mGroupID = -1
            mDisplayOrder = -1

            Dim prmMonitorID As New SqlParameter
            With prmMonitorID
                .ParameterName = "@MonitorID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = MonitorID
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
                .Parameters.Add(prmMonitorID)
            End With

            Try
                SQLConn.Open()
                Dim rd As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                While rd.Read()
                    mMonitorName = CStr(rd.Item("Name"))
                    mMonitorType = CStr(rd.Item("MonitorTypeName"))
                End While
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try

        End Sub
        Private Sub SavePanel()
            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_hyb_SaveDashboardPanel"

            Dim prmPanelID As New SqlParameter
            With prmPanelID
                .ParameterName = "@PanelID"
                .Direction = ParameterDirection.InputOutput
                .SqlDbType = SqlDbType.Int
                If mIsNew Then
                    .Value = System.Convert.DBNull
                Else
                    .Value = mPanelID
                End If
            End With

            Dim prmGroupID As New SqlParameter
            With prmGroupID
                .ParameterName = "@GroupID"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.Int
                .Value = mGroupID
            End With

            Dim prmMonitorID As New SqlParameter
            With prmMonitorID
                .ParameterName = "@MonitorID"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.Int
                .Value = mMonitorID
            End With

            Dim prmDisplayOrder As New SqlParameter
            With prmDisplayOrder
                .ParameterName = "@DisplayOrder"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.Int
                .Value = mDisplayOrder
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp

                .Parameters.Add(prmPanelID)
                .Parameters.Add(prmGroupID)
                .Parameters.Add(prmMonitorID)
                .Parameters.Add(prmDisplayOrder)
            End With

            Try
                SQLConn.Open()
                sqlCmd.ExecuteNonQuery()
                If mIsNew Then mPanelID = CInt(prmPanelID.Value)
                mIsNew = False
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Sub
#End Region

#Region "IComparable Implementation"
        Private Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
            If obj Is Nothing Then Return 1
            Dim other As MonitorPanel = DirectCast(obj, MonitorPanel)
            If other.DisplayOrder < Me.DisplayOrder Then
                Return 1
            ElseIf other.DisplayOrder = Me.DisplayOrder Then
                Return 0
            Else
                Return -1
            End If
        End Function
#End Region
    End Class
End Namespace