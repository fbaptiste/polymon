Imports System.Data.SqlClient

Namespace General
    Public Class SysSettings

#Region "Private Properties"
        Private mSQLConn As String

        Private mName As String
        Private mIsEnabled As Boolean
        Private mServiceServer As String
        Private mMainTimerInterval As Integer
        Private mUseInternalSMTP As Boolean
        Private mSMTPFromName As String
        Private mSMTPFromAddress As String
        Private mExtSMTPServer As String
        Private mExtSMTPPort As Integer
        Private mExtSMTPUserID As String
		Private mExtSMTPPwd As String
		Private mExtSMTPUseSSL As Boolean
		Private mDBVersion As Single
#End Region

#Region "Public Interface"
        Public Property Name() As String
            Get
                Return mName
            End Get
            Set(ByVal Value As String)
                If Value = Nothing OrElse Value.Trim.Length = 0 Then
                    Throw New System.Exception("Name cannot be blank")
                ElseIf Value.Length > 50 Then
                    Throw New System.Exception("Name cannot exceed 50 characters.")
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
        Public Property ServiceServer() As String
            Get
                Return mServiceServer
            End Get
            Set(ByVal Value As String)
                If Value = Nothing OrElse Value.Trim.Length = 0 Then
                    Throw New System.Exception("Service Server cannot be blank.")
                ElseIf Value.Length > 255 Then
                    Throw New System.Exception("Service Server cannot exceed 255 characters.")
                Else
                    mServiceServer = Value
                End If
            End Set
        End Property
        Public Property MainTimerInterval() As Integer
            Get
                Return mMainTimerInterval
            End Get
            Set(ByVal Value As Integer)
                If Value <= 0 Then
                    Throw New System.Exception("Main Timer Interval must be greater than zero. Interval is specified in seconds.")
                Else
                    mMainTimerInterval = Value
                End If
            End Set
        End Property
		Public Property UseInternalSMTP() As Boolean
			Get
				Return mUseInternalSMTP
			End Get
			Set(ByVal Value As Boolean)
				mUseInternalSMTP = Value
				'If mUseInternalSMTP Then
				'    mExtSMTPServer = Nothing
				'    mExtSMTPPort = Nothing
				'    mExtSMTPUserID = Nothing
				'    mExtSMTPPwd = Nothing
				'End If
			End Set
		End Property
        Public ReadOnly Property SMTPFromName() As String
            Get
                Return mSMTPFromName
            End Get
        End Property
        Public ReadOnly Property SMTPFromAddress() As String
            Get
                Return mSMTPFromAddress
            End Get
        End Property
        Public ReadOnly Property ExtSMTPServer() As String
            Get
                Return mExtSMTPServer
            End Get
        End Property
        Public ReadOnly Property ExtSMTPPort() As Integer
            Get
                Return mExtSMTPPort
            End Get
        End Property
        Public ReadOnly Property ExtSMTPUserID() As String
            Get
                Return mExtSMTPUserID
            End Get
        End Property
        Public ReadOnly Property ExtSMTPPwd() As String
            Get
                Return mExtSMTPPwd
            End Get
        End Property
		Public ReadOnly Property ExtSMTPUseSSL() As Boolean
			Get
				Return mExtSMTPUseSSL
			End Get
		End Property
		Public ReadOnly Property DBVersion() As Single
			Get
				Return mDBVersion
			End Get
		End Property

		Public Sub SetSMTPFrom(ByVal FromName As String, ByVal FromAddress As String)
			If FromName = Nothing OrElse FromName.Trim.Length = 0 Then
				Throw New System.Exception("SMTP FromName cannot be blank.")
			End If
			If FromName.Length > 50 Then
				Throw New System.Exception("SMTP FromName cannot exceed 50 characters.")
			End If
			If FromAddress = Nothing OrElse FromAddress.Trim.Length = 0 Then
				Throw New System.Exception("SMTP FromAddress cannot be blank.")
			End If
			If FromAddress.Length > 255 Then
				Throw New System.Exception("SMTP FromAddress cannot exceed 255 characters")
			End If

			mSMTPFromName = FromName.Trim()
			mSMTPFromAddress = FromAddress.Trim()
		End Sub
		Public Sub SetExtSMTP(ByVal SMTPServer As String, ByVal SMTPPort As Integer, ByVal UserID As String, ByVal UserPwd As String, ByVal UseSSL As Boolean)
			If mUseInternalSMTP Then
				Throw New System.Exception("Specifying external SMTP settings is not allowed because UseInternalSMTP has been set to true.")
			End If

			If SMTPServer = Nothing OrElse SMTPServer.Trim.Length = 0 Then
				Throw New System.Exception("SMTP Server cannot be blank.")
			End If
			If SMTPServer.Trim.Length > 255 Then
				Throw New System.Exception("SMTP Server cannot exceed 255 characters.")
			End If

			If SMTPPort = Nothing Then
				Throw New System.Exception("SMTP Port cannot be blank.")
			End If

			If Not (UserID = Nothing) AndAlso UserID.Trim.Length > 50 Then
				Throw New System.Exception("SMTP UserID cannot exceed 50 characters.")
			End If

			If Not (UserPwd = Nothing) AndAlso UserPwd.Trim.Length > 50 Then
				Throw New System.Exception("SMTP Password cannot exceed 50 characters.")
			End If

			If Not (UserID = Nothing) AndAlso UserPwd = Nothing Then
				Throw New System.Exception("SMTP: A Password must be provided when a UserID is specified.")
			End If

			If UserID = Nothing AndAlso Not (UserPwd = Nothing) Then
				Throw New System.Exception("SMTP: A UserID must be provided when a Password is specified.")
			End If

			mExtSMTPServer = SMTPServer.Trim()
			mExtSMTPPort = SMTPPort


			If UserID = Nothing OrElse UserID.Trim.Length = 0 Then
				mExtSMTPUserID = Nothing
			Else
				mExtSMTPUserID = UserID.Trim
			End If

			If UserPwd = Nothing OrElse UserPwd.Trim.Length = 0 Then
				mExtSMTPPwd = Nothing
			Else
				mExtSMTPPwd = UserPwd.Trim
			End If

			mExtSMTPUseSSL = UseSSL
		End Sub

        Public Sub New()
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
            InitClass()
        End Sub
        Public Sub Save()
            Dim ValidateFailReason As String = Nothing
            Dim IsValid As Boolean = ValidateData(ValidateFailReason)
            If Not (IsValid) Then
                Throw New System.Exception(ValidateFailReason)
                Exit Sub
            End If

            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim SP As String = "polymon_hyb_SaveSysSettings"

            Dim prmName As New SqlParameter
            With prmName
                .ParameterName = "@Name"
                .SqlDbType = SqlDbType.VarChar
                .Size = 50
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

            Dim prmServiceServer As New SqlParameter
            With prmServiceServer
                .ParameterName = "@ServiceServer"
                .SqlDbType = SqlDbType.VarChar
                .Size = 255
                .Direction = ParameterDirection.Input
                .Value = mServiceServer
            End With

            Dim prmMainTimerInterval As New SqlParameter
            With prmMainTimerInterval
                .ParameterName = "@MainTimerInterval"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = mMainTimerInterval
            End With

            Dim prmUseInternalSMTP As New SqlParameter
            With prmUseInternalSMTP
                .ParameterName = "@UseInternalSMTP"
                .SqlDbType = SqlDbType.Bit
                .Direction = ParameterDirection.Input
                .Value = mUseInternalSMTP
            End With

            Dim prmSMTPFromName As New SqlParameter
            With prmSMTPFromName
                .ParameterName = "@SMTPFromName"
                .SqlDbType = SqlDbType.VarChar
                .Size = 50
                .Direction = ParameterDirection.Input
                .Value = mSMTPFromName
            End With

            Dim prmSMTPFromAddress As New SqlParameter
            With prmSMTPFromAddress
                .ParameterName = "@SMTPFromAddress"
                .SqlDbType = SqlDbType.VarChar
                .Size = 255
                .Direction = ParameterDirection.Input
                .Value = mSMTPFromAddress
            End With

            Dim prmExtSMTPServer As New SqlParameter
            With prmExtSMTPServer
                .ParameterName = "@ExtSMTPServer"
                .SqlDbType = SqlDbType.VarChar
                .Size = 255
                .Direction = ParameterDirection.Input
                .Value = mExtSMTPServer
            End With

            Dim prmExtSMTPPort As New SqlParameter
            With prmExtSMTPPort
                .ParameterName = "@ExtSMTPPort"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = mExtSMTPPort
            End With

            Dim prmExtSMTPUserID As New SqlParameter
            With prmExtSMTPUserID
                .ParameterName = "@ExtSMTPUserID"
                .SqlDbType = SqlDbType.VarChar
                .Size = 50
                .Direction = ParameterDirection.Input
                .Value = mExtSMTPUserID
            End With

            Dim prmExtSMTPPwd As New SqlParameter
            With prmExtSMTPPwd
                .ParameterName = "@ExtSMTPPwd"
                .SqlDbType = SqlDbType.VarChar
                .Size = 50
                .Direction = ParameterDirection.Input
                .Value = mExtSMTPPwd
            End With

			Dim prmExtSMTPUseSSL As New SqlParameter
			With prmExtSMTPUseSSL
				.ParameterName = "@ExtSMTPUseSSL"
				.SqlDbType = SqlDbType.Bit
				.Direction = ParameterDirection.Input
				.Value = mExtSMTPUseSSL
			End With

            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .Connection = SQLConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = SP

                .Parameters.Add(prmName)
                .Parameters.Add(prmIsEnabled)
                .Parameters.Add(prmServiceServer)
                .Parameters.Add(prmMainTimerInterval)
                .Parameters.Add(prmUseInternalSMTP)
                .Parameters.Add(prmSMTPFromName)
                .Parameters.Add(prmSMTPFromAddress)
                .Parameters.Add(prmExtSMTPServer)
                .Parameters.Add(prmExtSMTPPort)
                .Parameters.Add(prmExtSMTPUserID)
				.Parameters.Add(prmExtSMTPPwd)
				.Parameters.Add(prmExtSMTPUseSSL)
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
#End Region

#Region "Private Methods"
        Private Function ValidateData(ByRef FailReason As String) As Boolean
            FailReason = Nothing
            If mName = Nothing Then
                FailReason = "Name cannot be blank."
                Return False
            End If

            If mServiceServer = Nothing Then
                FailReason = "Service Server cannot be blank."
                Return False
            End If

            If mMainTimerInterval = Nothing Then
                FailReason = "Main Timer Interval value must be specified."
                Return False
            End If

            If mSMTPFromName = Nothing Then
                FailReason = "SMTP FromName cannot be blank."
                Return False
            End If

            If mSMTPFromAddress = Nothing Then
                FailReason = "SMTP FromAddress cannot be blank."
                Return False
            End If

            If Not (mUseInternalSMTP) Then
                If mExtSMTPServer = Nothing Then
                    FailReason = "Ext SMTP Server cannot be blank when Use Internal SMTP is not enabled."
                    Return False
                End If
                If mExtSMTPPort = Nothing Then
                    FailReason = "Ext SMTP Port cannot be blank when Use Internal SMTP is not enabled."
                    Return False
                End If

                If mExtSMTPUserID = Nothing AndAlso Not (mExtSMTPPwd = Nothing) Then
                    FailReason = "A blank Ext UserID is not allowed when an Ext Password is specified and Use Internal SMTP is not enabled."
                    Return False
                End If
            End If

            Return True
        End Function
        Private Sub InitClass()
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
                        mName = CStr(.Item("Name"))
                        mIsEnabled = CBool(.Item("IsEnabled"))
                        mServiceServer = CStr(.Item("ServiceServer"))
                        mMainTimerInterval = CInt(.Item("MainTimerInterval"))
                        mUseInternalSMTP = CBool(.Item("UseInternalSMTP"))
                        mSMTPFromName = CStr(.Item("SMTPFromName"))
                        mSMTPFromAddress = CStr(.Item("SMTPFromAddress"))

                        If Not (IsDBNull(.Item("ExtSMTPServer"))) Then
                            mExtSMTPServer = CStr(.Item("ExtSMTPServer"))
                        Else
                            mExtSMTPServer = Nothing
                        End If
                        If Not (IsDBNull(.Item("ExtSMTPPort"))) Then
                            mExtSMTPPort = CInt(.Item("ExtSMTPPort"))
                        Else
                            mExtSMTPPort = Nothing
                        End If
                        If Not (IsDBNull(.Item("ExtSMTPUserID"))) Then
                            mExtSMTPUserID = CStr(.Item("ExtSMTPUserID"))
                        Else
                            mExtSMTPUserID = Nothing
                        End If
                        If Not (IsDBNull(.Item("ExtSMTPPwd"))) Then
                            mExtSMTPPwd = CStr(.Item("ExtSMTPPwd"))
                        Else
                            mExtSMTPPwd = Nothing
						End If
						mExtSMTPUseSSL = CBool(.Item("ExtSMTPUseSSL"))

						If Not (IsDBNull(.Item("DBVersion"))) Then
							mDBVersion = CSng(.Item("DBVersion"))
						Else
							mDBVersion = 0
						End If
                    End With
                Else
                    mName = Nothing
                    mIsEnabled = False
                    mServiceServer = Nothing
                    mMainTimerInterval = 60
                    mUseInternalSMTP = True
                    mSMTPFromName = Nothing
                    mSMTPFromAddress = Nothing
                    mExtSMTPServer = Nothing
                    mExtSMTPPort = Nothing
                    mExtSMTPUserID = Nothing
					mExtSMTPPwd = Nothing
					mExtSMTPUseSSL = Nothing
					mDBVersion = Nothing
                End If

            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If sqlConn.State <> ConnectionState.Closed Then sqlConn.Close()
                sqlConn.Dispose()
                sqlCmd.Dispose()
            End Try
        End Sub
#End Region

    End Class
End Namespace