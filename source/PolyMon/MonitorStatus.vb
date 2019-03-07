Imports System.Data.SqlClient

Namespace Monitors

    Public Class MonitorStatus
        Private mMonitorID As Integer
        Private mCurrentStatus As Current

        Public Enum eStatus As Integer
            Unknown = 0
            OK = 1
            Warning = 2
            Fail = 3
        End Enum

        Public Sub New(ByVal MonitorID As Integer)
            mMonitorID = MonitorID
            mCurrentStatus = New Current(MonitorID)
        End Sub

        Public ReadOnly Property CurrentStatus() As Current
            Get
                Return mCurrentStatus
            End Get
        End Property

        Public Class Current
            Private mSQLConn As String
            Private mMonitorID As Integer = Nothing
            Private mEventID As Integer = Nothing
            Private mEventDate As Date = Nothing
            Private mStatus As eStatus = eStatus.Unknown
            Private mStatusMessage As String = Nothing
			Private mLifetimePercUptime As Single = Nothing
			Private mStatusStartDT As DateTime = Nothing
			Private mStatusEndDT As DateTime = Nothing
			Private mStatusElapsedSecs As Integer = 0
			Private mStatusElapsedTxt As String = Nothing
			Private mCounters As DataTable = Nothing

            Friend Sub New(ByVal MonitorID As Integer)
                mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
				mMonitorID = MonitorID

				GetLastStatus(MonitorID)
            End Sub

            Public ReadOnly Property EventID() As Integer
                Get
                    Return mEventID
                End Get
            End Property
            Public ReadOnly Property EventDate() As Date
                Get
                    Return mEventDate
                End Get
            End Property
            Public ReadOnly Property Status() As eStatus
                Get
                    Return mStatus
                End Get
            End Property
            Public ReadOnly Property StatusMessage() As String
                Get
                    Return mStatusMessage
                End Get
            End Property
            Public ReadOnly Property LifetimePercUptime() As Single
                Get
                    Return mLifetimePercUptime
                End Get
			End Property
			Public ReadOnly Property StatusStartDT() As Date
				Get
					Return mStatusStartDT
				End Get
			End Property
			Public ReadOnly Property StatusEndDT() As Date
				Get
					Return mStatusEndDT
				End Get
			End Property
			Public ReadOnly Property StatusElapsedSecs() As Integer
				Get
					Return mStatusElapsedSecs
				End Get
			End Property
			Public ReadOnly Property StatusElapsedTxt() As String
				Get
					Return mStatusElapsedTxt
				End Get
			End Property
			Public ReadOnly Property Counters() As DataTable
				Get
					Return mCounters
				End Get
			End Property

			Private Sub GetLastStatus(ByVal MonitorID As Integer)
				Dim SQLConn As New SqlConnection(mSQLConn)

				Dim prmMonitorID As New SqlParameter
				With prmMonitorID
					.ParameterName = "@MonitorID"
					.Direction = ParameterDirection.Input
					.SqlDbType = SqlDbType.Int
					.Value = MonitorID
				End With

				Dim cmdSQL As New SqlCommand
				With cmdSQL
					.CommandType = CommandType.StoredProcedure
					.CommandText = "polymon_sel_LastMonitorStatus"
					.Connection = SQLConn
					.Parameters.Add(prmMonitorID)
				End With

				Dim dsResults As New DataSet
				Dim daSQL As New SqlDataAdapter(cmdSQL)
				Dim tblStatus As DataTable = Nothing
				Try
					SQLConn.Open()
					daSQL.Fill(dsResults)

					If dsResults.Tables.Count <= 0 Then
						mEventID = -1
						mStatus = eStatus.Unknown
						mEventDate = Nothing
						mStatusMessage = Nothing
					Else
						'First table is Status data
						tblStatus = dsResults.Tables(0)
						mEventID = CInt(tblStatus.Rows(0).Item("EventID"))
						mEventDate = CDate(tblStatus.Rows(0).Item("EventDT"))
						mStatus = CType(tblStatus.Rows(0).Item("StatusID"), eStatus)
						mStatusMessage = CStr(tblStatus.Rows(0).Item("StatusMessage"))
						mLifetimePercUptime = CSng(tblStatus.Rows(0).Item("LifetimePercUptime"))
						mStatusStartDT = CDate(tblStatus.Rows(0).Item("StatusStartDT"))
						mStatusEndDT = CDate(tblStatus.Rows(0).Item("StatusEndDT"))
						mStatusElapsedSecs = CInt(tblStatus.Rows(0).Item("TimeElapsedSecs"))
						mStatusElapsedTxt = CStr(tblStatus.Rows(0).Item("TimeElapsedTxt"))
						If dsResults.Tables.Count = 2 Then
							mCounters = dsResults.Tables(1)
						End If
					End If
					'''Dim rd As SqlDataReader = cmdSQL.ExecuteReader(CommandBehavior.CloseConnection)
					'''If Not (rd.HasRows()) Then
					'''	mEventID = -1
					'''	mStatus = eStatus.Unknown
					'''	mEventDate = Nothing
					'''	mStatusMessage = "N/A"
					'''Else
					'''	While rd.Read
					'''		mEventID = CInt(rd.Item("EventID"))
					'''		mEventDate = CDate(rd.Item("EventDT"))
					'''		mStatus = CType(rd.Item("StatusID"), eStatus)
					'''		mStatusMessage = CStr(rd.Item("StatusMessage"))
					'''		mLifetimePercUptime = CSng(rd.Item("LifetimePercUptime"))
					'''	End While

					'''	'Read next recordset (contains Counter data)
					'''	rd.NextResult()
					'''	Dim CounterName As String = Nothing
					'''	Dim CounterValue As Double = Nothing
					'''	While rd.Read

					'''		If IsDBNull(rd.Item("CounterName")) Then
					'''			CounterName = Nothing
					'''		Else
					'''			CounterName = CStr(rd.Item("CounterName"))
					'''		End If
					'''		If IsDBNull(rd.Item("CounterValue")) Then
					'''			CounterValue = Nothing
					'''		Else
					'''			CounterValue = CDbl(rd.Item("CounterValue"))
					'''		End If
					'''		If CounterName IsNot Nothing Then mCounters.Add(CounterName, CounterValue)
					'''	End While
					'''End If
				Catch ex As Exception
					Throw New System.Exception(ex.Message, ex)
				Finally
					If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
					daSQL.Dispose()
					SQLConn.Dispose()
				End Try
			End Sub
        End Class
    End Class
End Namespace