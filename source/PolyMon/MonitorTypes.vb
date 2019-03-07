Imports System.Data.SqlClient

Namespace MonitorTypes
    Public Class MonitorTypes
        Implements IEnumerable

#Region "Private/Friend Properties"
        Private mSQLConn As String
        Friend mMonitorTypes As Collection
#End Region

#Region "Public Interface"
        Default Public ReadOnly Property MonitorType(ByVal index As Integer) As MonitorType
            'For some reason, .NET defines Collection base as one, inconsistent with rest of framework
            'Need to code around this to make our collections zero based.
            Get
                Return CType(mMonitorTypes.Item(index + 1), MonitorType)
            End Get
        End Property
        Public ReadOnly Property Count() As Integer
            Get
                Return mMonitorTypes.Count
            End Get
        End Property
        Public ReadOnly Property Item(ByVal MonitorTypeID As Integer) As PolyMon.MonitorTypes.MonitorType
            Get
                Dim FoundMType As PolyMon.MonitorTypes.MonitorType = Nothing
                For Each MType As PolyMon.MonitorTypes.MonitorType In mMonitorTypes
                    If MType.MonitorTypeID = MonitorTypeID Then FoundMType = MType
                Next
                Return FoundMType
            End Get
        End Property

        Public Sub New()
            LoadMonitorTypes()
        End Sub
        Public Sub Refresh()
            LoadMonitorTypes()
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return New MonitorTypeEnumerator(Me)
        End Function
        Public Class MonitorTypeEnumerator
            Implements IEnumerator

            Private mIndex As Integer = -1
            Private mMonitorTypes As MonitorTypes

            Public Sub New(ByVal MonitorTypes As MonitorTypes)
                mMonitorTypes = MonitorTypes
            End Sub
            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    If mIndex > -1 Then
                        Return mMonitorTypes.MonitorType(mIndex)
                    Else
                        Return Nothing
                    End If
                End Get
            End Property
            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                mIndex += 1

                If mIndex < mMonitorTypes.Count Then
                    Return True
                Else
                    Return False
                End If

            End Function
            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                mIndex = -1
            End Sub
        End Class
#End Region

#Region "Private Methods"
        Private Sub LoadMonitorTypes()
            'Retrieve Monitor Types
            mMonitorTypes = Nothing
            mMonitorTypes = New Collection
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_sel_MonitorTypes"

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
            End With

            Try
                SQLConn.Open()
                Dim drMonitorTypes As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim MonitorType As PolyMon.MonitorTypes.MonitorType
                While drMonitorTypes.Read()
                    MonitorType = New MonitorType(CInt(drMonitorTypes.Item("MonitorTypeID")))
                    mMonitorTypes.Add(MonitorType, CStr(MonitorType.MonitorTypeID))
                End While
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Sub
#End Region

    End Class
End Namespace