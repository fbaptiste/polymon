Imports System.Data.SqlClient

Namespace General
	Public Class DefaultRetentionSettings
		Private mSQLConn As String = Nothing
		Private mRaw As Integer = 24
		Private mDaily As Integer = 36
		Private mWeekly As Integer = 60
		Private mMonthly As Integer = 60

		Public Sub New()
			mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
			LoadDefaultSettings()
		End Sub

		Public Property Raw() As Integer
			Get
				Return mRaw
			End Get
			Set(ByVal value As Integer)
				mRaw = value
			End Set
		End Property
		Public Property Daily() As Integer
			Get
				Return mDaily
			End Get
			Set(ByVal value As Integer)
				mDaily = value
			End Set
		End Property
		Public Property Weekly() As Integer
			Get
				Return mWeekly
			End Get
			Set(ByVal value As Integer)
				mWeekly = value
			End Set
		End Property
		Public Property Monthly() As Integer
			Get
				Return mMonthly
			End Get
			Set(ByVal value As Integer)
				mMonthly = value
			End Set
		End Property

		Private Sub LoadDefaultSettings()
			Dim sqlConn As New SqlConnection(mSQLConn)
			Dim SP As String = "polymon_sel_SysSettings"

			Dim sqlCmd As New SqlCommand
			With sqlCmd
				.Connection = sqlConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = SP
			End With

			Try
				sqlConn.Open()
				Dim drSettings As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.SingleRow)
				If drSettings.HasRows Then
					With drSettings
						.Read()
						mRaw = CInt(.Item("RetentionMaxMonthsRaw"))
						mDaily = CInt(.Item("RetentionMaxMonthsDaily"))
						mWeekly = CInt(.Item("RetentionMaxMonthsWeekly"))
						mMonthly = CInt(.Item("RetentionMaxMonthsMonthly"))
					End With
				Else
					mRaw = 24
					mDaily = 36
					mWeekly = 60
					mMonthly = 60
				End If

			Catch ex As Exception
				Throw New System.Exception(ex.Message, ex)
			Finally
				If sqlConn.State <> ConnectionState.Closed Then sqlConn.Close()
				sqlConn.Dispose()
				sqlCmd.Dispose()
			End Try
		End Sub

		Public Sub Save()
			Dim SQLConn As New SqlConnection(mSQLConn)
			Dim SP As String = "polymon_hyb_SaveDefaultRetentionSettings"

			Dim prmRaw As New SqlParameter
			With prmRaw
				.ParameterName = "@RetentionMaxMonthsRaw"
				.SqlDbType = SqlDbType.SmallInt
				.Direction = ParameterDirection.Input
				.Value = mRaw
			End With

			Dim prmDaily As New SqlParameter
			With prmDaily
				.ParameterName = "@RetentionMaxMonthsDaily"
				.SqlDbType = SqlDbType.SmallInt
				.Direction = ParameterDirection.Input
				.Value = mDaily
			End With

			Dim prmWeekly As New SqlParameter
			With prmWeekly
				.ParameterName = "@RetentionMaxMonthsWeekly"
				.SqlDbType = SqlDbType.SmallInt
				.Direction = ParameterDirection.Input
				.Value = mWeekly
			End With

			Dim prmMonthly As New SqlParameter
			With prmMonthly
				.ParameterName = "@RetentionMaxMonthsMonthly"
				.SqlDbType = SqlDbType.SmallInt
				.Direction = ParameterDirection.Input
				.Value = mMonthly
			End With

			Dim sqlCmd As New SqlCommand
			With sqlCmd
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = SP

				.Parameters.Add(prmRaw)
				.Parameters.Add(prmDaily)
				.Parameters.Add(prmWeekly)
				.Parameters.Add(prmMonthly)
			End With

			Try
				SQLConn.Open()
				sqlCmd.ExecuteNonQuery()
			Catch ex As Exception
				Throw New System.Exception(ex.Message, ex)
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
				sqlCmd.Dispose()
			End Try
		End Sub
	End Class
End Namespace