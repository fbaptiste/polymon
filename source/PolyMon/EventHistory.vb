Imports System.Data.SqlClient

Namespace MonitorEvents
    Public Class EventHistory
        Private mInclOK As Boolean
        Private mInclWarning As Boolean
        Private mInclFail As Boolean
        Private mStartDate As Date
        Private mEndDate As Date

        Private mSQLConn As String
        Private mResults As DataTable

        Public Sub New(ByVal InclOK As Boolean, ByVal InclWarning As Boolean, ByVal InclFail As Boolean, ByVal StartDate As Date, ByVal EndDate As Date)
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

            mInclOK = InclOK
            mInclWarning = InclWarning
            mInclFail = InclFail

            mStartDate = StartDate
            mEndDate = EndDate

            GetEventData()
        End Sub

        Public ReadOnly Property EventHistory() As DataTable
            Get
                Return mResults
            End Get
        End Property

        Private Sub GetEventData()
            Dim SQLConn As New SqlConnection(mSQLConn)

            Dim prmInclOK As New SqlParameter
            With prmInclOK
                .ParameterName = "@InclOK"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.Bit
                .Value = mInclOK
            End With

            Dim prmInclWarning As New SqlParameter
            With prmInclWarning
                .ParameterName = "@InclWarning"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.Bit
                .Value = mInclWarning
            End With

            Dim prmInclFail As New SqlParameter
            With prmInclFail
                .ParameterName = "@InclFail"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.Bit
                .Value = mInclFail
            End With

            Dim prmStartDate As New SqlParameter
            With prmStartDate
                .ParameterName = "@StartDate"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.DateTime
                .Value = mStartDate
            End With

            Dim prmEndDate As New SqlParameter
            With prmEndDate
                .ParameterName = "@EndDate"
                .Direction = ParameterDirection.Input
                .SqlDbType = SqlDbType.DateTime
                .Value = mEndDate
            End With

            Dim cmdSQL As New SqlCommand
            With cmdSQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "polymon_sel_EventHistory"
                .Connection = SQLConn
                .Parameters.Add(prmInclOK)
                .Parameters.Add(prmInclWarning)
                .Parameters.Add(prmInclFail)
                .Parameters.Add(prmStartDate)
                .Parameters.Add(prmEndDate)
            End With

            Dim dsResults As New DataSet
            Dim daSQL As New SqlDataAdapter(cmdSQL)

            Try
                SQLConn.Open()
                daSQL.Fill(dsResults)
                If dsResults.Tables.Count > 0 Then
                    mResults = dsResults.Tables(0)
                Else
                    mResults = Nothing
                End If
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                daSQL.Dispose()
                SQLConn.Dispose()
            End Try
        End Sub
    End Class
End Namespace
