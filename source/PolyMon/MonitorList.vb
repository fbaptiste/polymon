Imports System.Data.SqlClient

Namespace Monitors
    Public Class MonitorList
        Implements IEnumerable

#Region "Private/Friend Properties"
        Private mSQLConn As String
        Friend mMonitors As Collection
#End Region

#Region "Public Interface"
        Default Public ReadOnly Property Monitor(ByVal index As Integer) As PolyMon.Monitors.MonitorMetadata
            'For some reason, .NET defines Collection base as one, inconsistent with rest of framework
            'Need to code around this to make our collections zero based.
            Get
                Return CType(mMonitors.Item(index + 1), PolyMon.Monitors.MonitorMetadata)
            End Get
        End Property
        Public ReadOnly Property Count() As Integer
            Get
                Return mMonitors.Count
            End Get
        End Property
        Public ReadOnly Property Item(ByVal MonitorID As Integer) As PolyMon.Monitors.MonitorMetadata
            Get
                Dim FoundMonitor As PolyMon.Monitors.MonitorMetadata = Nothing
                For Each Monitor As PolyMon.Monitors.MonitorMetadata In mMonitors
                    If Monitor.MonitorID = MonitorID Then FoundMonitor = Monitor
                Next
                Return FoundMonitor
            End Get
        End Property

        Public Sub New()
            LoadMonitors()
        End Sub
        Public Sub Refresh()
            LoadMonitors()
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return New MonitorEnumerator(Me)
        End Function

        Public Class MonitorEnumerator
            Implements IEnumerator

            Private mIndex As Integer = -1
            Private mMonitors As MonitorList

            Public Sub New(ByVal Monitors As MonitorList)
                mMonitors = Monitors
            End Sub
            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    If mIndex > -1 Then
                        Return mMonitors.Monitor(mIndex)
                    Else
                        Return Nothing
                    End If
                End Get
            End Property
            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                mIndex += 1

                If mIndex < mMonitors.Count Then
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
        Private Sub LoadMonitors()
            'Retrieve Monitor Types
            mMonitors = Nothing
            mMonitors = New Collection
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_sel_MonitorList"

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
            End With

            Try
                SQLConn.Open()
                Dim drMonitors As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim Monitor As PolyMon.Monitors.MonitorMetadata
                While drMonitors.Read()
                    Monitor = New MonitorMetadata(CInt(drMonitors.Item("MonitorID")))
                    mMonitors.Add(Monitor, CStr(Monitor.MonitorID))
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
