Imports System.Data.SqlClient

Namespace Operators
    Public Class PMOperator

#Region "Private Properties"
        Private mSQLConn As String
        Private mOperatorID As Integer
        Private mName As String
        Private mIsEnabled As Boolean
        Private mEmailAddress As String
        Private mIncludeMessageBody As Boolean
		Private mOfflineTime As IOfflineTime
		Private mQueuedNotify As QueuedNotifyFlags
		Private mSummaryNotify As Boolean
		Private mSummaryNotifyOK As Boolean
		Private mSummaryNotifyWarn As Boolean
		Private mSummaryNotifyFail As Boolean
		Private mSummaryNotifyTime As String
		Private mSummaryNextNotifyDT As DateTime
#End Region

#Region "Public Enums"
		Public Enum QueuedNotifyFlags As Integer
			Send_Nothing = 0
			Send_All = 1
			Send_RecapOnly = 2
		End Enum
#End Region
#Region "Public Interface"
        Public Sub New()
            InitClassState()
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
        End Sub
        Public Sub New(ByVal OperatorID As Integer)
            InitClassState()
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

            mOperatorID = OperatorID

            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_sel_Operator"

            Dim prmOperatorID As New SqlParameter
            With prmOperatorID
                .ParameterName = "@OperatorID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = OperatorID
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp
                .Parameters.Add(prmOperatorID)
            End With

            Try
                Dim drOperator As SqlDataReader
                SQLConn.Open()
                drOperator = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                If Not (drOperator.HasRows()) Then
                    Throw New System.Exception("Specified Operator ID does not exist.")
                End If
                drOperator.Read()

                With drOperator
                    mName = CStr(.Item("Name"))
                    mIsEnabled = CBool(.Item("IsEnabled"))
                    mEmailAddress = CStr(.Item("EmailAddress"))
                    mOfflineTime = New IOfflineTime(CStr(.Item("OfflineTimeStart")), CStr(.Item("OfflineTimeEnd")))
					mIncludeMessageBody = CBool(.Item("IncludeMessageBody"))
					mQueuedNotify = CType(.Item("QueuedNotify"), QueuedNotifyFlags)
					mSummaryNotify = CBool(.Item("SummaryNotify"))
					mSummaryNotifyOK = CBool(.Item("SummaryNotifyOK"))
					mSummaryNotifyWarn = CBool(.Item("SummaryNotifyWarn"))
					mSummaryNotifyFail = CBool(.Item("SummaryNotifyFail"))
					mSummaryNotifyTime = CStr(.Item("SummaryNotifyTime"))
					mSummaryNextNotifyDT = CDate(.Item("SummaryNextNotifyDT"))
                End With
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Sub

        Public ReadOnly Property OperatorID() As Integer
            Get
                Return mOperatorID
            End Get
        End Property
        Public Property Name() As String
            Get
                Return mName
            End Get
            Set(ByVal Value As String)
                If Value.Length > 255 Then
                    Throw New System.Exception("Operator Name cannot exceed 255 characters.")
                Else
                    mName = Value
                End If
            End Set
        End Property
        Public Property IsEnabled() As Boolean
            Get
                Return mIsEnabled
            End Get
            Set(ByVal Value As Boolean)
                mIsEnabled = Value
            End Set
        End Property
        Public Property EmailAddress() As String
            Get
                Return mEmailAddress
            End Get
            Set(ByVal Value As String)
                If Value.Length > 255 Then
                    Throw New System.Exception("Email Address cannot exceed 255 characters.")
                Else
                    mEmailAddress = Value
                End If
            End Set
        End Property
        Public Property OfflineTime() As IOfflineTime
            Get
                Return mOfflineTime
            End Get
            Set(ByVal Value As IOfflineTime)
                mOfflineTime = Value
            End Set
        End Property
        Public Property IncludeMessageBody() As Boolean
            Get
                Return mIncludeMessageBody
            End Get
            Set(ByVal Value As Boolean)
                mIncludeMessageBody = Value
            End Set
        End Property
		Public Property QueuedNotify() As QueuedNotifyFlags
			Get
				Return mQueuedNotify
			End Get
			Set(ByVal value As QueuedNotifyFlags)
				mQueuedNotify = value
			End Set
		End Property
		Public Property SummaryNotify() As Boolean
			Get
				Return mSummaryNotify
			End Get
			Set(ByVal value As Boolean)
				mSummaryNotify = value
			End Set
		End Property
		Public Property SummaryNotifyOK() As Boolean
			Get
				Return mSummaryNotifyOK
			End Get
			Set(ByVal value As Boolean)
				mSummaryNotifyOK = value
			End Set
		End Property
		Public Property SummaryNotifyWarn() As Boolean
			Get
				Return mSummaryNotifyWarn
			End Get
			Set(ByVal value As Boolean)
				mSummaryNotifyWarn = value
			End Set
		End Property
		Public Property SummaryNotifyFail() As Boolean
			Get
				Return mSummaryNotifyFail
			End Get
			Set(ByVal value As Boolean)
				mSummaryNotifyFail = value
			End Set
		End Property

		Public Property SummaryNotifyTime() As String
			Get
				Return mSummaryNotifyTime
			End Get
			Set(ByVal value As String)
				mSummaryNotifyTime = value
			End Set
		End Property
		Public ReadOnly Property SummaryNextNotifyDT() As Date
			Get
				Return mSummaryNextNotifyDT
			End Get
		End Property

        Public Function Save() As Integer
            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_hyb_SaveOperator"

            Dim prmOperatorID As New SqlParameter
            With prmOperatorID
                .ParameterName = "@OperatorID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.InputOutput
                If mOperatorID = -1 Then
                    .Value = System.Convert.DBNull 'Nothing 'System.Data.SqlTypes.SqlInt32.Null
                Else
                    .Value = mOperatorID
                End If
            End With

            Dim prmName As New SqlParameter
            With prmName
                .ParameterName = "@Name"
                .SqlDbType = SqlDbType.NVarChar
                .Size = 255
                .Direction = ParameterDirection.Input
                .Value = mName
            End With

            Dim prmIsEnabled As New SqlParameter
            With prmIsEnabled
                .ParameterName = "@IsEnabled"
                .SqlDbType = SqlDbType.Bit
                .Direction = ParameterDirection.Input
                .Value = mIsEnabled
            End With

            Dim prmEmailAddress As New SqlParameter
            With prmEmailAddress
                .ParameterName = "@EmailAddress"
                .SqlDbType = SqlDbType.VarChar
                .Size = 255
                .Direction = ParameterDirection.Input
                .Value = mEmailAddress
            End With

            Dim prmOfflineTimeStart As New SqlParameter
            With prmOfflineTimeStart
                .ParameterName = "@OfflineTimeStart"
                .SqlDbType = SqlDbType.Char
                .Size = 5
                .Direction = ParameterDirection.Input
                .Value = mOfflineTime.StartTime
            End With

            Dim prmOfflineTimeEnd As New SqlParameter
            With prmOfflineTimeEnd
                .ParameterName = "@OfflineTimeEnd"
                .SqlDbType = SqlDbType.VarChar
                .Size = 5
                .Direction = ParameterDirection.Input
                .Value = mOfflineTime.EndTime
            End With

            Dim prmIncludeMessageBody As New SqlParameter
            With prmIncludeMessageBody
                .ParameterName = "@IncludeMessageBody"
                .SqlDbType = SqlDbType.Bit
                .Direction = ParameterDirection.Input
                .Value = mIncludeMessageBody
            End With

			Dim prmQueuedNotify As New SqlParameter
			With prmQueuedNotify
				.ParameterName = "@QueuedNotify"
				.SqlDbType = SqlDbType.TinyInt
				.Direction = ParameterDirection.Input
				.Value = mQueuedNotify
			End With

			Dim prmSummaryNotify As New SqlParameter
			With prmSummaryNotify
				.ParameterName = "@SummaryNotify"
				.SqlDbType = SqlDbType.TinyInt
				.Direction = ParameterDirection.Input
				.Value = mSummaryNotify
			End With

			Dim prmSummaryNotifyOK As New SqlParameter
			With prmSummaryNotifyOK
				.ParameterName = "@SummaryNotifyOK"
				.SqlDbType = SqlDbType.Bit
				.Direction = ParameterDirection.Input
				.Value = mSummaryNotifyOK
			End With

			Dim prmSummaryNotifyWarn As New SqlParameter
			With prmSummaryNotifyWarn
				.ParameterName = "@SummaryNotifyWarn"
				.SqlDbType = SqlDbType.Bit
				.Direction = ParameterDirection.Input
				.Value = mSummaryNotifyWarn
			End With

			Dim prmSummaryNotifyFail As New SqlParameter
			With prmSummaryNotifyFail
				.ParameterName = "@SummaryNotifyFail"
				.SqlDbType = SqlDbType.Bit
				.Direction = ParameterDirection.Input
				.Value = mSummaryNotifyFail
			End With

			Dim prmSummaryNotifyTime As New SqlParameter
			With prmSummaryNotifyTime
				.ParameterName = "@SummaryNotifyTime"
                .SqlDbType = SqlDbType.Char 'changed from datetime to char to match SQL sproc
				.Size = 5
				.Direction = ParameterDirection.Input
				.Value = mSummaryNotifyTime
			End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp

                .Parameters.Add(prmOperatorID)
                .Parameters.Add(prmName)
                .Parameters.Add(prmIsEnabled)
                .Parameters.Add(prmEmailAddress)
                .Parameters.Add(prmOfflineTimeStart)
                .Parameters.Add(prmOfflineTimeEnd)
				.Parameters.Add(prmIncludeMessageBody)
				.Parameters.Add(prmQueuedNotify)
				.Parameters.Add(prmSummaryNotify)
				.Parameters.Add(prmSummaryNotifyOK)
				.Parameters.Add(prmSummaryNotifyWarn)
				.Parameters.Add(prmSummaryNotifyFail)
				.Parameters.Add(prmSummaryNotifyTime)
            End With

            Try
                SQLConn.Open()
                sqlCmd.ExecuteNonQuery()
                mOperatorID = CInt(prmOperatorID.Value) 'CType(prmOperatorID.Value, System.Data.SqlTypes.SqlInt32).Value
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
                SQLConn.Dispose()
            End Try

            Return mOperatorID
        End Function
        Public Sub Delete()
            If mOperatorID = -1 Then Exit Sub 'nothing to delete

            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_del_DeleteOperator"

            Dim prmOperatorID As New SqlParameter
            With prmOperatorID
                .ParameterName = "@OperatorID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = mOperatorID
            End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = sp

                .Parameters.Add(prmOperatorID)
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
            End Try
        End Sub

        Public Class IOfflineTime
            Private mStartTime As String
            Private mEndTime As String

            Public Property StartTime() As String
                Get
                    Return mStartTime
                End Get
                Set(ByVal Value As String)
                    mStartTime = Value
                End Set
            End Property
            Public Property EndTime() As String
                Get
                    Return mEndTime
                End Get
                Set(ByVal Value As String)
                    mEndTime = Value
                End Set
            End Property
            Public Sub New(ByVal StartTime As String, ByVal EndTime As String)
                mStartTime = StartTime
                mEndTime = EndTime
            End Sub
            Friend Function IsOfflineTime() As Boolean
                'Determines if current time is within stated offline times
                Dim OffStart As Integer
                Dim OffEnd As Integer
                Dim CurrTime As Integer
                Dim IsOffline As Boolean = False

                OffStart = CInt(mStartTime.Replace(":", Nothing))
                OffEnd = CInt(mEndTime.Replace(":", Nothing))
                CurrTime = CInt(Format(Now(), "HH:mm").Replace(":", Nothing))

                If OffStart < OffEnd Then
                    If CurrTime >= OffStart And CurrTime <= OffEnd Then IsOffline = True
                ElseIf OffStart > OffEnd Then
                    If (CurrTime >= OffStart And CurrTime <= 2400) Or (CurrTime < OffEnd) Then IsOffline = True
                End If

                Return IsOffline
            End Function
        End Class
#End Region

#Region "Private Methods"
        Private Sub InitClassState()
            mOperatorID = -1
            mName = Nothing
            mIsEnabled = True
            mEmailAddress = Nothing
            mIncludeMessageBody = True
            mOfflineTime = New IOfflineTime("00:00", "00:00")
        End Sub
#End Region

    End Class
End Namespace