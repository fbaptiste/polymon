Imports System.Data.SqlClient

Namespace Operators
    Public Class PMOperators
        Implements IEnumerable
#Region "Private/Friend Properties"
        Private mSQLConn As String
        Friend mPMOperators As Collection
#End Region

#Region "Public Interface"
        Default Public ReadOnly Property PMOperator(ByVal index As Integer) As PMOperator
            'For some reason, .NET defines Collection base as one, inconsistent with rest of framework
            'Need to code around this to make our collections zero based.
            Get
                Return CType(mPMOperators.Item(index + 1), PMOperator)
            End Get
        End Property
        Public ReadOnly Property Count() As Integer
            Get
                Return mPMOperators.Count
            End Get
        End Property
        Public ReadOnly Property Item(ByVal PMOperatorID As Integer) As PolyMon.Operators.PMOperator
            Get
                Dim FoundPMOperator As PolyMon.Operators.PMOperator = Nothing
                For Each PMOperator As PolyMon.Operators.PMOperator In mPMOperators
                    If PMOperator.OperatorID = PMOperatorID Then FoundPMOperator = PMOperator
                Next
                Return FoundPMOperator
            End Get
        End Property

        Public Sub New()
            LoadPMOperators()
        End Sub
        Public Sub Refresh()
            LoadPMOperators()
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return New PMOperatorEnumerator(Me)
        End Function

        Public Class PMOperatorEnumerator
            Implements IEnumerator

            Private mIndex As Integer = -1
            Private mPMOperators As PMOperators

            Public Sub New(ByVal PMOperators As PMOperators)
                mPMOperators = PMOperators
            End Sub
            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    If mIndex > -1 Then
                        Return mPMOperators.PMOperator(mIndex)
                    Else
                        Return Nothing
                    End If
                End Get
            End Property
            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                mIndex += 1

                If mIndex < mPMOperators.Count Then
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
        Private Sub LoadPMOperators()
            'Retrieve Monitor Types
            mPMOperators = Nothing
            mPMOperators = New Collection
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_sel_Operators"

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
            End With

            Try
                SQLConn.Open()
                Dim drOperators As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim PMOperator As PolyMon.Operators.PMOperator
                While drOperators.Read()
                    PMOperator = New PMOperator(CInt(drOperators.Item("OperatorID")))
                    mPMOperators.Add(PMOperator, CStr(PMOperator.OperatorID))
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
