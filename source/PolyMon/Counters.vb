
Namespace Status
#Region "Counter Classes"
	Public Class Counter
		Private mCounterName As String
		Private mCounterValue As Double

		Public Sub New(ByVal CounterName As String, ByVal CounterValue As Double)
			mCounterName = Left(CounterName.Trim(), 255)
			mCounterValue = CounterValue
		End Sub
		Public ReadOnly Property CounterName() As String
			Get
				Return mCounterName
			End Get
		End Property
		Public ReadOnly Property CounterValue() As Double
			Get
				Return mCounterValue
			End Get
		End Property
	End Class
	Public Class CounterList
		Inherits CollectionBase

		Default Public Property Item(ByVal index As Integer) As Counter
			Get
				Return CType(InnerList.Item(index), Counter)
			End Get
			Set(ByVal Value As Counter)
				InnerList.Item(index) = Value
			End Set
		End Property
		Public Property Counter(ByVal CounterName As String) As Counter
			Get
				Dim MyIndex As Integer = -1
				MyIndex = IndexOf(CounterName)
				If MyIndex < 0 Then
					Throw New System.Exception("Counter does not exist.")
				Else
					Return CType(InnerList.Item(MyIndex), Counter)
				End If
			End Get
			Set(ByVal value As Counter)
				Dim myIndex As Integer = -1
				myIndex = IndexOf(CounterName)
				If myIndex < 0 Then
					Throw New System.Exception("Counter does not exist")
				Else
					InnerList.Item(myIndex) = value
				End If
			End Set
		End Property
		Public Sub Add(ByVal value As Counter)
			InnerList.Add(value)
		End Sub

		Private Function IndexOf(ByVal CounterName As String) As Integer
			Dim myIndex As Integer = -1
			Dim i As Integer
			For i = 0 To InnerList.Count - 1
				If CType(InnerList.Item(i), Counter).CounterName.ToLower.Trim = CounterName.ToLower.Trim Then
					myIndex = i
					Exit For
				End If
			Next
			Return myIndex
		End Function
	End Class
#End Region

#Region "Status Classes"
	Public Class Status
		Private mStatusID As Integer
		Private mStatus As String

		Public Enum StatusCodes As Integer
			OK = 1
			Warn = 2
			Fail = 3
		End Enum

		Public Sub New(ByVal StatusID As Integer)
			mStatusID = StatusID
			Select Case mStatusID
				Case 1
					mStatus = "OK"
				Case 2
					mStatus = "Warning"
				Case 3
					mStatus = "Fail"
				Case Else
					mStatus = "Unknown"
			End Select
		End Sub

		Public ReadOnly Property StatusID() As Integer
			Get
				Return mStatusID
			End Get
		End Property
		Public ReadOnly Property Status() As String
			Get
				Return mStatus
			End Get
		End Property
	End Class
#End Region

End Namespace