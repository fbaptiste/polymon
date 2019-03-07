Imports System.Threading

Friend Class SNMPGet

    Private mHost As String
    Private mCommunity As String
    Private mOID() As UInt32
    Dim mTimeout As Integer

    Private mIsTimeout As Boolean = False
    Private mIsOK As Boolean = False
    Private mStatusMessage As String = "Not Run."
    Private mSNMPValue As String

    Public ReadOnly Property IsOK() As Boolean
        Get
            Return mIsOK
        End Get
    End Property

    Public ReadOnly Property StatusMessage() As String
        Get
            Return mStatusMessage
        End Get
    End Property
    Public ReadOnly Property SNMPValue() As String
        Get
            Return mSNMPValue
        End Get
    End Property
    Public Sub New(ByVal Host As String, ByVal Community As String, ByVal OID As String, ByVal Timeout As Integer)
        mHost = Host
        mCommunity = Community
        mTimeout = Timeout

        'Extract OID from string into a uint32 array
        If Left(OID, 1) = "." Then OID = Mid(OID, 2)
        Dim strOID() As String = OID.Split(CChar("."))
        Dim i As Integer
        ReDim mOID(strOID.GetLength(0) - 1)
        For i = 0 To strOID.GetLength(0) - 1
            mOID(i) = UInt32.Parse(strOID(i))
        Next
    End Sub
    Public Sub SNMPGet()
        Dim mySNMPSyncGet As New SNMPSyncGet(mHost, mCommunity, mOID)

        mIsTimeout = False
        mIsOK = False
        mStatusMessage = Nothing
        mSNMPValue = Nothing

        Dim StartDT As DateTime = Date.Now()
        mySNMPSyncGet.SNMPGet()
        While Not (mySNMPSyncGet.IsDone)
            If Date.Now.Subtract(StartDT).TotalMilliseconds > mTimeout Then
                'Timeout reached
                mySNMPSyncGet.StopGet()
                mIsTimeout = True
            Else
                'Timeout not reached yet, continue
                Thread.Sleep(10)
            End If
        End While

        mIsOK = mySNMPSyncGet.IsOK
        mStatusMessage = mySNMPSyncGet.StatusMessage
        mSNMPValue = mySNMPSyncGet.SNMPValue
    End Sub

    Private Class SNMPSyncGet
        Dim mHost As String
        Dim mCommunity As String
        Dim mOID() As UInt32

        Dim mIsAborted As Boolean = False
        Dim mIsStarted As Boolean = False
        Dim mIsDone As Boolean = False
        Dim mIsOK As Boolean = False
        Dim mStatusMessage As String = Nothing
        Dim mSNMPValue As String = Nothing

        Dim mManagerSession As Snmp.ManagerSession
        Dim mManagerItem As Snmp.ManagerItem

        Public ReadOnly Property IsStarted() As Boolean
            Get
                Return mIsStarted
            End Get
        End Property
        Public ReadOnly Property IsDone() As Boolean
            Get
                Return mIsDone
            End Get
        End Property
        Public ReadOnly Property IsOK() As Boolean
            Get
                Return mIsOK
            End Get
        End Property
        Public ReadOnly Property StatusMessage() As String
            Get
                Return mStatusMessage
            End Get
        End Property
        Public ReadOnly Property SNMPValue() As String
            Get
                Return mSNMPValue
            End Get
        End Property

        Public Sub New(ByVal Host As String, ByVal Community As String, ByVal OID() As UInt32)
            mHost = Host
            mCommunity = Community
            mOID = OID
        End Sub
        Public Sub SNMPGet()
            mIsDone = False
            mIsOK = False
            mStatusMessage = Nothing
            mSNMPValue = Nothing

            'Run sync GET on a separate thread
            Dim ThreadSNMPGet As New Thread(New ThreadStart(AddressOf StartGet))
            ThreadSNMPGet.Start()
        End Sub

        Private Sub StartGet()
            Try
                mIsAborted = True
                mIsStarted = True
                mManagerSession = New Snmp.ManagerSession(mHost, mCommunity)
                mManagerItem = New Snmp.ManagerItem(mManagerSession, mOID)
                mSNMPValue = mManagerItem.Value.ToString()
                mIsDone = True
                mIsOK = True
                mStatusMessage = "OK."
                mManagerItem = Nothing
                mManagerSession.Close()
                mManagerSession = Nothing
                mIsStarted = False
            Catch ex As Exception
                mIsDone = True
                mIsOK = False
                mSNMPValue = Nothing
                If Not (mIsAborted) Then mStatusMessage = ex.Message
                mManagerItem = Nothing
                If Not (mManagerSession Is Nothing) Then mManagerSession.Close()
                mManagerSession = Nothing
            End Try
        End Sub
        Public Sub StopGet()
            mIsAborted = True
            mIsStarted = False
            mIsOK = False
            mIsDone = True
            mStatusMessage = "Operation timeout reached."
            mSNMPValue = Nothing
            mManagerSession.Close()
            mManagerItem = Nothing
            mManagerSession = Nothing
        End Sub
    End Class
End Class

