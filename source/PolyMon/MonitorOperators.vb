Imports PolyMon.Operators
Imports System.Data.SqlClient
Namespace Operators
    Public Class MonitorOperators
        Implements IEnumerable

#Region "Private/Friend Properties"
        Private mSQLConn As String
        Private mMonitorID As Integer
        Friend mMonitorOperators As Collection
#End Region

#Region "Public Interface"
        Public ReadOnly Property MonitorID() As Integer
            Get
                Return mMonitorID
            End Get
        End Property
        Default Public ReadOnly Property PMOperator(ByVal index As Integer) As PMOperator
            'For some reason, .NET defines Collection base as one, inconsistent with rest of framework
            'Need to code around this to make our collections zero based.
            Get
                Return CType(mMonitorOperators.Item(index + 1), PMOperator)
            End Get
        End Property
        Public ReadOnly Property Count() As Integer
            Get
                Return mMonitorOperators.Count
            End Get
        End Property
        Public Sub New(ByVal MonitorID As Integer)
            mMonitorID = MonitorID
            mMonitorOperators = New Collection

            'Retrieve currently defined Monitor Operators for specified MonitorID
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_sel_MonitorOperators"

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
                Dim drOperators As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim PMOperator As PolyMon.Operators.PMOperator
                While drOperators.Read()
                    PMOperator = New PMOperator(CInt(drOperators.Item("OperatorID")))
                    mMonitorOperators.Add(PMOperator, CStr(PMOperator.OperatorID))
                End While
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Sub
        Public Sub Add(ByVal value As PMOperator)
            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_ins_AssignMonitorOperator"
            Dim WasCreated As Boolean

            Dim prmMonitorID As New SqlParameter
            With prmMonitorID
                .ParameterName = "@MonitorID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = mMonitorID
            End With

            Dim prmOperatorID As New SqlParameter
            With prmOperatorID
                .ParameterName = "@OperatorID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = value.OperatorID
            End With

            Dim prmWasCreated As New SqlParameter
            With prmWasCreated
                .ParameterName = "@WasCreated"
                .SqlDbType = SqlDbType.Bit
                .Direction = ParameterDirection.Output
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
                .Parameters.Add(prmMonitorID)
                .Parameters.Add(prmOperatorID)
                .Parameters.Add(prmWasCreated)
            End With

            Try
                SQLConn.Open()
                sqlCmd.ExecuteNonQuery()
                WasCreated = CBool(prmWasCreated.Value)

                If WasCreated Then mMonitorOperators.Add(value, CStr(value.OperatorID))
            Catch ex As Exception
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Sub
        Public Sub Remove(ByVal value As PMOperator)
            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_del_RemoveMonitorOperator"
            Dim WasRemoved As Boolean

            Dim prmMonitorID As New SqlParameter
            With prmMonitorID
                .ParameterName = "@MonitorID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = mMonitorID
            End With

            Dim prmOperatorID As New SqlParameter
            With prmOperatorID
                .ParameterName = "@OperatorID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = value.OperatorID
            End With

            Dim prmWasRemoved As New SqlParameter
            With prmWasRemoved
                .ParameterName = "@WasRemoved"
                .SqlDbType = SqlDbType.Bit
                .Direction = ParameterDirection.Output
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
                .Parameters.Add(prmMonitorID)
                .Parameters.Add(prmOperatorID)
                .Parameters.Add(prmWasRemoved)
            End With

            Try
                SQLConn.Open()
                sqlCmd.ExecuteNonQuery()
                WasRemoved = CBool(prmWasRemoved.Value)

                If WasRemoved Then mMonitorOperators.Remove(CStr(value.OperatorID))
            Catch ex As Exception
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try

        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return New MonitorOperatorEnumerator(Me)
        End Function
        Public Class MonitorOperatorEnumerator
            Implements IEnumerator

            Private mIndex As Integer = -1
            Private mMonitorOperators As MonitorOperators

            Public Sub New(ByVal MonitorOperators As MonitorOperators)
                mMonitorOperators = MonitorOperators
            End Sub


            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    If mIndex > -1 Then
                        Return mMonitorOperators.PMOperator(mIndex)
                    Else
                        Return Nothing
                    End If
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                mIndex += 1

                If mIndex < mMonitorOperators.mMonitorOperators.Count Then
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

    End Class
End Namespace