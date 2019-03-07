Public Class dlgDeleting
	Private mAllowClose As Boolean = False

	Public Sub New(ByVal Message As String)
		InitializeComponent()

		Me.lblMessage.Text = Message
		mAllowClose = False
	End Sub

	Private Sub dlgDeleting_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		If Not mAllowClose Then
			e.Cancel = True
		End If
	End Sub

	Public Sub CloseDialog()
		mAllowClose = True
		Me.Close()
	End Sub
End Class