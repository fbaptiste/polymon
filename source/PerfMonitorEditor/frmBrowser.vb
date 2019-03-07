Public Class frmBrowser

#Region "Public Interface"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtHost.Text = "127.0.0.1"
        cboCategory.Items.Clear()
        lstCounters.Items.Clear()
        lstInstances.Items.Clear()
    End Sub

    Public ReadOnly Property Host() As String
        Get
            Host = txtHost.Text
            If Not String.IsNullOrEmpty(Host) AndAlso Host.ToUpper.Contains("LOCALHOST") Then
                Return "127.0.0.1"
            Else
                Return Host
            End If
        End Get
    End Property
    Public ReadOnly Property Category() As String
        Get
            Return cboCategory.Text
        End Get
    End Property
    Public ReadOnly Property Counter() As String
		Get
			If lstCounters.SelectedItems.Count = 0 Then
				Return Nothing
			Else
				Return lstCounters.SelectedItem.ToString()
			End If
		End Get
    End Property
    Public ReadOnly Property Instance() As String
		Get
			If lstInstances.SelectedItems.Count = 0 Then
				Return Nothing
			Else
				Return lstInstances.SelectedItem.ToString()
			End If
		End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub btnRefreshCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshCategories.Click
        Me.Cursor = Cursors.WaitCursor
        Dim Host As String = txtHost.Text

        lstCounters.Items.Clear()
        lstInstances.Items.Clear()

        RefreshCategories(Host)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Me.lstCounters.Items.Clear()
        Me.lstInstances.Items.Clear()

        Dim Host As String = txtHost.Text
        Dim Category As String = cboCategory.Text

        If String.IsNullOrEmpty(Category) Then Exit Sub

        RefreshCounterLists(Host, Category)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

#Region "Private Methods"
    Private Sub RefreshCategories(ByVal Host As String)
        Try
            cboCategory.Items.Clear()

            Dim PerfCat As PerformanceCounterCategory

            If String.IsNullOrEmpty(Host) OrElse Host.ToUpper.Contains("LOCALHOST") Then
                For Each PerfCat In System.Diagnostics.PerformanceCounterCategory.GetCategories()
                    cboCategory.Items.Add(PerfCat.CategoryName)
                Next
            Else
                For Each PerfCat In System.Diagnostics.PerformanceCounterCategory.GetCategories(Host)
                    cboCategory.Items.Add(PerfCat.CategoryName)
                Next
            End If
        Catch ex As Exception
            MsgBox("Cannot refresh Category list: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon")
        End Try
    End Sub
    Private Sub RefreshCounterLists(ByVal Host As String, ByVal Category As String)
        Try
            Dim PerfCat As PerformanceCounterCategory
            If String.IsNullOrEmpty(Host) OrElse Host.ToUpper.Contains("LOCALHOST") Then
                PerfCat = New PerformanceCounterCategory(Category)
            Else
                PerfCat = New PerformanceCounterCategory(Category, Host)
            End If


            If PerfCat.CategoryType = PerformanceCounterCategoryType.SingleInstance Then
                lstInstances.Enabled = False
                lblInstances.Enabled = False

                Dim PerfCounter As PerformanceCounter
                For Each PerfCounter In PerfCat.GetCounters()
                    lstCounters.Items.Add(PerfCounter.CounterName)
                Next
            Else
                lstInstances.Enabled = True
                lblInstances.Enabled = True

                Dim PerfInstance As String = ""
                For Each PerfInstance In PerfCat.GetInstanceNames()
                    lstInstances.Items.Add(PerfInstance)
                Next

                Dim PerfCounter As PerformanceCounter
                For Each PerfCounter In PerfCat.GetCounters(PerfInstance)
                    lstCounters.Items.Add(PerfCounter.CounterName)
                Next
            End If
        Catch ex As Exception
            MsgBox("Error retrieving Counters/Instances: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon")
        End Try
    End Sub
#End Region
End Class