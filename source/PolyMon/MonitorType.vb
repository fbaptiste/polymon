Imports System.Data.SqlClient
Namespace MonitorTypes
    Public Class MonitorType

#Region "Private Properties"
        Private mSQLConn As String
        Private mMonitorTypeID As Integer
        Private mName As String
        Private mMonitorAssembly As String
        Private mEditorAssembly As String
        Private mMonitorXMLTemplate As String
#End Region

#Region "Public Interface"
        Public ReadOnly Property MonitorTypeID() As Integer
            Get
                Return mMonitorTypeID
            End Get
        End Property
        Public Property Name() As String
            Get
                Return mName
            End Get
            Set(ByVal Value As String)
                If Value.Length > 50 Then
                    Throw New System.Exception("Monitor Type Name cannot exceed 50 characters.")
                Else
                    mName = Value
                End If
            End Set
        End Property
        Public Property MonitorAssembly() As String
            Get
                Return mMonitorAssembly
            End Get
            Set(ByVal Value As String)
                If Value.Length > 255 Then
                    Throw New System.Exception("Monitor Assembly path/name cannot exceed 255 characters")
                Else
                    mMonitorAssembly = Value
                End If
            End Set
        End Property
        Public Property EditorAssembly() As String
            Get
                Return mEditorAssembly
            End Get
            Set(ByVal Value As String)
                If Value.Length > 255 Then
                    Throw New System.Exception("Editor Assembly path/name cannot exceed 255 characters.")
                Else
                    mEditorAssembly = Value
                End If
            End Set
        End Property
        Public Property XMLTemplate() As String
            Get
                Return mMonitorXMLTemplate
            End Get
            Set(ByVal Value As String)
                mMonitorXMLTemplate = Value
            End Set
        End Property

        Public Sub New()
            InitClassState()
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
        End Sub
        Public Sub New(ByVal MonitorTypeID As Integer)
            InitClassState()
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

            mMonitorTypeID = MonitorTypeID

            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_sel_MonitorType"

            Dim prmMonitorTypeID As New SqlParameter
            With prmMonitorTypeID
                .ParameterName = "@MonitorTypeID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = MonitorTypeID
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
                .Parameters.Add(prmMonitorTypeID)
            End With

            Try
                Dim drMonitorType As SqlDataReader
                SQLConn.Open()
                drMonitorType = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                If Not (drMonitorType.HasRows) Then
                    Throw New System.Exception("Specified Monitor Type ID does not exist.")
                End If
                drMonitorType.Read()

                With drMonitorType
                    mName = CStr(.Item("Name"))
                    mMonitorAssembly = CStr(.Item("MonitorAssembly"))
                    mEditorAssembly = CStr(.Item("EditorAssembly"))
                    If IsDBNull(.Item("MonitorXMLTemplate")) Then
                        mMonitorXMLTemplate = Nothing
                    Else
                        mMonitorXMLTemplate = CStr(.Item("MonitorXMLTemplate"))
                    End If
                End With
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Sub
        Public Sub Save()
            Dim SqlConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_hyb_SaveMonitorType"

            Dim prmMonitorTypeID As New SqlParameter
            With prmMonitorTypeID
                .ParameterName = "@MonitorTypeID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.InputOutput
                .Value = mMonitorTypeID
            End With

            Dim prmName As New SqlParameter
            With prmName
                .ParameterName = "@Name"
                .SqlDbType = SqlDbType.VarChar
                .Size = 50
                .Value = mName
            End With

            Dim prmMonitorAssembly As New SqlParameter
            With prmMonitorAssembly
                .ParameterName = "@MonitorAssembly"
                .SqlDbType = SqlDbType.VarChar
                .Size = 255
                .Value = mMonitorAssembly
            End With

            Dim prmEditorAssembly As New SqlParameter
            With prmEditorAssembly
                .ParameterName = "@EditorAssembly"
                .SqlDbType = SqlDbType.VarChar
                .Size = 255
                .Value = mEditorAssembly
            End With

            Dim prmMonitorXMLTemplate As New SqlParameter
            With prmMonitorXMLTemplate
                .ParameterName = "@MonitorXMLTemplate"
                .SqlDbType = SqlDbType.NText
                If mMonitorXMLTemplate = Nothing Then
                    .Value = System.Convert.DBNull
                Else
                    .Value = mMonitorXMLTemplate
                End If

            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SqlConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
                .Parameters.Add(prmMonitorTypeID)
                .Parameters.Add(prmName)
                .Parameters.Add(prmMonitorAssembly)
                .Parameters.Add(prmEditorAssembly)
                .Parameters.Add(prmMonitorXMLTemplate)
            End With

            Try
                SqlConn.Open()
                sqlCmd.ExecuteNonQuery()
                mMonitorTypeID = CInt(prmMonitorTypeID.Value)
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SqlConn.State <> ConnectionState.Closed Then SqlConn.Close()
                SqlConn.Dispose()
                sqlCmd.Dispose()
            End Try
        End Sub
        Public Sub Delete()
            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_del_DeleteMonitorType"

            Dim prmMonitorTypeID As New SqlParameter
            With prmMonitorTypeID
                .ParameterName = "@MonitorTypeID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = mMonitorTypeID
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
                .Parameters.Add(prmMonitorTypeID)
            End With

            Try
                SQLConn.Open()
                sqlCmd.ExecuteNonQuery()
                InitClassState()
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
                sqlCmd.Dispose()
            End Try
        End Sub

#End Region

#Region "Private Methods"
        Private Sub InitClassState()
            mMonitorTypeID = -1
            mName = Nothing
            mMonitorAssembly = Nothing
            mEditorAssembly = Nothing
            mMonitorXMLTemplate = Nothing
        End Sub
#End Region

    End Class
End Namespace