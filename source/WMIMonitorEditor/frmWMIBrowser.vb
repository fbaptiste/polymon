Imports System.Management
Imports System.Windows.Forms
Imports System.Text

Public Class frmWMIBrowser

	Private mIsCancel As Boolean = False
	Private mLastFocus As WindowControl
	Private mClassList As New List(Of WMIH)
	Private mFilterText As String = Nothing
	Private mIsFiltering As Boolean = False

	Private mQuery As String = Nothing

	Public Sub New(ByVal Host As String, ByVal Query As String)
		InitializeComponent()

		Me.txtQueryHost.Text = Host
		Me.txtQuery.Text = Query
	End Sub

	Public ReadOnly Property Query() As String
		Get
			Return mQuery
		End Get
	End Property

	Private Enum WindowControl As Integer
		Other = 0
		Classes = 1
		Instances = 2
		Properties = 3
	End Enum

	Private Class WMIH
		Private _Name As String
		Private _WMIObj As ManagementObject

		Public Sub New(ByVal Name As String, ByVal MO As ManagementObject)
			_Name = Name
			_WMIObj = MO
		End Sub

		Public ReadOnly Property Name() As String
			Get
				Return _Name
			End Get
		End Property
		Public ReadOnly Property WMIObj() As ManagementObject
			Get
				Return _WMIObj
			End Get
		End Property
	End Class

	Private Sub btnGetClasses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetClasses.Click
		lstClasses.DataSource = Nothing
		lstInstances.Items.Clear()
        ClearPropertiesGrid()
        mFilterText = Nothing
		Dim Server As String = Nothing
		If String.IsNullOrEmpty(txtHost.Text) Then
			Server = "localhost"
		Else
			Server = txtHost.Text.Trim()
		End If
		StatusHost(Server)
		GenerateClassList(Server, Me.lstClasses)
	End Sub

	Private Sub lstClasses_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstClasses.GotFocus
		mLastFocus = WindowControl.Classes
	End Sub

	Private Sub lstClasses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstClasses.SelectedIndexChanged
		If Not (mIsFiltering) AndAlso lstClasses.SelectedItem IsNot Nothing Then
			Dim MOClass As ManagementObject = CType(lstClasses.SelectedItem, WMIH).WMIObj
			lstInstances.Items.Clear()
			ClearPropertiesGrid()
			GenerateInstanceList(MOClass, lstInstances)
		End If
	End Sub

	Private Sub lstInstances_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstInstances.GotFocus
		mLastFocus = WindowControl.Instances
	End Sub

	Private Sub lstInstances_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstInstances.SelectedIndexChanged
		If lstInstances.SelectedItem IsNot Nothing Then
			ClearPropertiesGrid()
			Dim WMIInstance As ManagementObject = CType(lstInstances.SelectedItem, WMIH).WMIObj
			GeneratePropertiesList(WMIInstance)
		End If
	End Sub

#Region "WMI Browsing"
	Private Sub GenerateClassList(ByVal Server As String, ByRef List As ListBox)
		mClassList.Clear()
		mIsCancel = False
		StatusText(String.Format("Retrieving Classes from {0}\cimv2", Server), True)
		StatusCount(Nothing)
		Dim Scope As New ManagementScope(String.Format("\\{0}\root\cimv2", Server))

		Dim WMIRoot As New ManagementClass(Scope, New ManagementPath(""), Nothing)
		Dim WMIChild As New ManagementObject

		Dim options As New EnumerationOptions
		options.EnumerateDeep = True 'Set recursive enumeration

		List.DataSource = Nothing
		Dim Cnt As Integer = 0
		For Each WMIChild In WMIRoot.GetSubclasses(options)
			Application.DoEvents()
			If mIsCancel Then Exit For
			Cnt += 1
			If Cnt Mod 10 = 0 Then StatusCount(String.Format("# Classes: {0}", Cnt))
			mClassList.Add(New WMIH(WMIChild("__CLASS").ToString, WMIChild))
		Next
		List.DataSource = mClassList
		StatusCount(String.Format("# Classes: {0}", mClassList.Count))
		If mIsCancel Then StatusText("Cancelled.", False) Else StatusText("Ready.", False)
	End Sub

	Private Sub GenerateInstanceList(ByRef MOClass As ManagementObject, ByRef List As ListBox)
		StatusText("Retrieving Instances...", True)
		StatusCount(Nothing)
		mIsCancel = False
		List.Items.Clear()
		Dim Query As WqlObjectQuery
		Query = New WqlObjectQuery(String.Format("select * from {0}", MOClass("__CLASS").ToString))

		Dim Scope As New ManagementScope(String.Format("\\{0}\root\cimv2", MOClass.Path.Server))

		Dim Searcher As New ManagementObjectSearcher(Scope, Query)
		Searcher.Options.Timeout = New System.TimeSpan(0, 0, 45)

		Dim WMIChild As ManagementObject
		Dim DisplayName As String
		Dim Cnt As Integer = 0
		Try
			List.BeginUpdate()
			For Each WMIChild In Searcher.Get()
				Application.DoEvents()
				If mIsCancel Then Exit For
				Cnt += 1
				StatusCount(String.Format("# Instances: {0}", Cnt))
				DisplayName = Nothing
				Try	'Error is thrown if Name property does not exist...
					DisplayName = WMIChild.Item("Name").ToString
				Catch
					DisplayName = Nothing
				End Try

				If String.IsNullOrEmpty(DisplayName) Then
					DisplayName = GetKeyValue(WMIChild)
				End If

				If String.IsNullOrEmpty(DisplayName) Then
					Try
						DisplayName = WMIChild("__CLASS").ToString()
					Catch ex As Exception
						DisplayName = "--Unknown--"
					End Try
				End If

				List.Items.Add(New WMIH(DisplayName, WMIChild))
			Next
		Catch ex As Exception
			MsgBox("Error occurred: " & vbCrLf & ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "PolyMon - WMI Error")
		Finally
			List.EndUpdate()
		End Try
		If mIsCancel Then StatusText("Cancelled.", False) Else StatusText("Ready.", False)
	End Sub

	Private Sub GeneratePropertiesList(ByVal WMIInstance As ManagementObject)
		'List properties for selected instance
		mIsCancel = False
		StatusText("Retrieving Properties...", True)

		'Create a datatable to hold data so we can bind to datagridview (nneded to allow multi-column sorting)
		Dim dt As New DataTable
		dt.Columns.Add("Key", System.Type.GetType("System.Boolean"))
		dt.Columns.Add("Property", System.Type.GetType("System.String"))
		dt.Columns.Add("Value", System.Type.GetType("System.String"))
		dt.Columns.Add("Local", System.Type.GetType("System.Boolean"))
		dt.Columns.Add("Array", System.Type.GetType("System.Boolean"))
		dt.Columns.Add("Type", System.Type.GetType("System.String"))

		Dim WMIProperty As PropertyData
		Dim DataRow As String() = Nothing

		' ''System Properties
		''For Each WMIProperty In WMIInstance.SystemProperties
		''	If WMIProperty.Value IsNot Nothing Then
		''		DataRow = New String() {Nothing, WMIProperty.Name, WMIProperty.Value.ToString(), Nothing, Nothing, Nothing}
		''		dt.Rows.Add(DataRow)
		''	End If
		''Next

		'Properties (Data)
		Dim Value As String
		Dim IsKey As Boolean
		For Each WMIProperty In WMIInstance.Properties
			Application.DoEvents()
			If mIsCancel Then Exit For
			If WMIProperty.Value Is Nothing Then
				Value = Nothing
			Else
				Value = WMIProperty.Value.ToString()
			End If

			Try
				IsKey = WMIProperty.Qualifiers("key").Value.ToString.Length > 0
			Catch ex As Exception
				IsKey = False
			End Try

			Dim WMIType As String = String.Format("{0}  ({1})", ConvertCIMType(WMIProperty.Type).ToString(), WMIProperty.Type.ToString())

			DataRow = New String() {CStr(IsKey), WMIProperty.Name, Value, CStr(WMIProperty.IsLocal), CStr(WMIProperty.IsArray), WMIType}
			dt.Rows.Add(DataRow)
		Next

		Dim dv As DataView = dt.DefaultView()
		dv.Sort = "Key desc, Local desc, Property asc"
		dgvProperties.DataSource = dv
		dgvProperties.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
		If mIsCancel Then StatusText("Cancelled.", False) Else StatusText("Ready.", False)
	End Sub

	Private Function GetKeyValue(ByVal WMIObj As ManagementObject) As String
		Dim WMIProperty As PropertyData
		Dim IsKey As Boolean
		Dim KeyValue As String = Nothing

		For Each WMIProperty In WMIObj.Properties
			Try
				IsKey = WMIProperty.Qualifiers("key").Value.ToString.Length > 0
				If IsKey Then
					KeyValue = WMIProperty.Value.ToString()
					Exit For
				End If
			Catch ex As Exception
				KeyValue = Nothing
			End Try
		Next
		Return KeyValue
	End Function

	Private Sub GetKeyPair(ByVal WMIObj As ManagementObject, ByRef KeyName As String, ByRef KeyValue As String)
		Dim WMIProperty As PropertyData
		Dim IsKey As Boolean

		For Each WMIProperty In WMIObj.Properties
			Try
				IsKey = WMIProperty.Qualifiers("key").Value.ToString.Length > 0
				If IsKey Then
					KeyName = WMIProperty.Name
					KeyValue = WMIProperty.Value.ToString()
					Exit For
				End If
			Catch ex As Exception
				KeyName = Nothing
				KeyValue = Nothing
			End Try
		Next
	End Sub

#End Region

	Private Sub InitForm()
		lstClasses.DisplayMember = "Name"
		lstInstances.DisplayMember = "Name"
	End Sub
	Private Sub SetupGrid()
		With dgvProperties
			.DataSource = Nothing
			.Rows.Clear()
			.Columns.Clear()

			.AutoGenerateColumns = False
			.SelectionMode = DataGridViewSelectionMode.FullRowSelect
			.MultiSelect = True
			.ReadOnly = True
			.RowHeadersVisible = False
			.AllowUserToOrderColumns = True
			.AllowUserToAddRows = False

			.Columns.Add(New DataGridViewCheckBoxColumn())
			.Columns(0).Name = "Key"
			.Columns(0).DataPropertyName = "Key"
			.Columns(0).SortMode = DataGridViewColumnSortMode.Automatic

			.Columns.Add(New DataGridViewTextBoxColumn)
			.Columns(1).Name = "Property"
			.Columns(1).DataPropertyName = "Property"
			.Columns(1).SortMode = DataGridViewColumnSortMode.Automatic

			.Columns.Add(New DataGridViewTextBoxColumn)
			.Columns(2).Name = "Value"
			.Columns(2).DataPropertyName = "Value"
			.Columns(2).SortMode = DataGridViewColumnSortMode.Automatic

			.Columns.Add(New DataGridViewCheckBoxColumn())
			.Columns(3).Name = "Local"
			.Columns(3).DataPropertyName = "Local"
			.Columns(3).SortMode = DataGridViewColumnSortMode.Automatic

			.Columns.Add(New DataGridViewCheckBoxColumn())
			.Columns(4).Name = "Array"
			.Columns(4).DataPropertyName = "Array"
			.Columns(4).SortMode = DataGridViewColumnSortMode.Automatic

			.Columns.Add(New DataGridViewTextBoxColumn)
			.Columns(5).Name = "Type (CIM Type)"
			.Columns(5).DataPropertyName = "Type"
			.Columns(5).SortMode = DataGridViewColumnSortMode.Automatic
			.Columns(5).MinimumWidth = 50
		End With
	End Sub

	Private Sub StatusText(ByVal Text As String, Optional ByVal DisplayCancel As Boolean = False)
		Me.tlblStatus.Text = Text
		Me.tlblCancel.Visible = DisplayCancel
		Me.StatusStrip1.Focus()
		Me.StatusStrip1.Refresh()
	End Sub
	Private Sub StatusCount(ByVal Text As String)
		Me.tlblCount.Text = Text
		Me.StatusStrip1.Focus()
		Me.StatusStrip1.Refresh()
	End Sub
	Private Sub StatusHost(ByVal Text As String)
		Me.tlblHost.Text = Text
		Me.StatusStrip1.Focus()
		Me.StatusStrip1.Refresh()
	End Sub

	Private Sub ClearPropertiesGrid()
		Me.dgvProperties.DataSource = Nothing
	End Sub
	Private Sub tlblCancel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tlblCancel.MouseDown
		StatusText("Cancelling...")
		mIsCancel = True
	End Sub

	Private Sub btnGenerateQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateQuery.Click
		Dim Query As String = Nothing

		'Recover Query from where user was...
		Dim IsClassQuery As Boolean = False
		Dim IsInstanceQuery As Boolean = False
		Dim IsPropertyQuery As Boolean = False

		If mLastFocus = WindowControl.Properties Then
			'Grid has focus, was anything selected?
			If dgvProperties.SelectedRows.Count > 0 Then
				IsPropertyQuery = True
			ElseIf lstInstances.SelectedItems.Count > 0 Then
				IsInstanceQuery = True
			ElseIf lstClasses.SelectedItems.Count > 0 Then
				IsClassQuery = True
			End If
		ElseIf mLastFocus = WindowControl.Instances Then
			If lstInstances.SelectedItems.Count > 0 Then
				IsInstanceQuery = True
			ElseIf lstClasses.SelectedItems.Count > 0 Then
				IsClassQuery = True
			End If
		ElseIf mLastFocus = WindowControl.Classes Then
			If lstClasses.SelectedItems.Count > 0 Then
				IsClassQuery = True
			End If
		End If

		Dim WMIObj As ManagementObject = Nothing

		If IsPropertyQuery Then
			Dim PropertyNames As String = Nothing
			Dim sb As New System.Text.StringBuilder
			For Each dr As DataGridViewRow In dgvProperties.SelectedRows
				If (dr.Cells("Property").Value IsNot Nothing) AndAlso Not (String.IsNullOrEmpty(dr.Cells("Property").Value.ToString)) Then
					sb.AppendFormat("{0}, ", dr.Cells("Property").Value.ToString())
				End If
			Next
			PropertyNames = sb.ToString().Trim()
			If PropertyNames.EndsWith(",") Then PropertyNames = PropertyNames.Substring(0, PropertyNames.Length - 1) & " "

			WMIObj = CType(lstInstances.SelectedItem, WMIH).WMIObj
			Dim KeyName As String = Nothing
			Dim KeyValue As String = Nothing
			GetKeyPair(WMIObj, KeyName, KeyValue)
			If String.IsNullOrEmpty(KeyName) OrElse String.IsNullOrEmpty(KeyValue) Then
				Query = Nothing
			Else
				Query = String.Format("SELECT {3} FROM {0} WHERE {1} = ""{2}""", WMIObj.ClassPath.RelativePath, KeyName, KeyValue, PropertyNames)

			End If
		ElseIf IsInstanceQuery Then
			WMIObj = CType(lstInstances.SelectedItem, WMIH).WMIObj
			Dim KeyName As String = Nothing
			Dim KeyValue As String = Nothing
			GetKeyPair(WMIObj, KeyName, KeyValue)
			If String.IsNullOrEmpty(KeyName) OrElse String.IsNullOrEmpty(KeyValue) Then
				Query = Nothing
			Else
				Query = String.Format("SELECT * FROM {0} WHERE {1} = ""{2}""", WMIObj.ClassPath.RelativePath, KeyName, KeyValue)
			End If
		ElseIf IsClassQuery Then
			WMIObj = CType(lstClasses.SelectedItem, WMIH).WMIObj
			Query = String.Format("SELECT * FROM {0}", WMIObj.Path.RelativePath)
		Else
			Query = Nothing
		End If

		'Dim NewQuery As New frmWMIQuery(txtHost.Text, Query)
		'NewQuery.Show()
		Me.txtQueryHost.Text = txtHost.Text
		Me.txtQuery.Text = Query
		Me.TabControl1.SelectedTab = tpWMIQuery
	End Sub

	Private Function ConvertCIMType(ByVal Type As System.Management.CimType) As System.TypeCode
		Select Case Type
			Case CimType.Boolean : Return TypeCode.Boolean
			Case CimType.Char16 : Return TypeCode.Char
			Case CimType.DateTime : Return TypeCode.DateTime
			Case CimType.None : Return TypeCode.Empty
			Case CimType.Object : Return TypeCode.Object
			Case CimType.Real32 : Return TypeCode.Single
			Case CimType.Real64 : Return TypeCode.Double
			Case CimType.Reference : Return TypeCode.Int16
			Case CimType.SInt16 : Return TypeCode.Int16
			Case CimType.SInt32 : Return TypeCode.Int32
			Case CimType.SInt64 : Return TypeCode.Int64
			Case CimType.SInt8 : Return TypeCode.SByte
			Case CimType.String : Return TypeCode.String
			Case CimType.UInt16 : Return TypeCode.UInt16
			Case CimType.UInt32 : Return TypeCode.UInt32
			Case CimType.UInt64 : Return TypeCode.UInt64
			Case CimType.UInt8 : Return TypeCode.Byte
			Case Else : Return TypeCode.Empty
		End Select
	End Function

	Private Sub frmWMIBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		mLastFocus = WindowControl.Other
		InitForm()
		SetupGrid()
	End Sub

	Private Sub dgvProperties_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvProperties.GotFocus
		mLastFocus = WindowControl.Properties
	End Sub

	Private Function ClassNameContains(ByVal WMIClass As WMIH) As Boolean
		If WMIClass.Name.ToLower.Contains(mFilterText.ToLower) Then Return True Else Return False
	End Function

	Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
		mIsFiltering = True
		lstClasses.DataSource = Nothing
		If String.IsNullOrEmpty(txtFilter.Text) Then
			lstClasses.DataSource = mClassList
		Else
			mFilterText = txtFilter.Text.Trim()
			lstClasses.DataSource = mClassList.FindAll(AddressOf ClassNameContains)
			lstClasses.DisplayMember = "Name"
		End If
		mIsFiltering = False
	End Sub

	Private Sub btnClearFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearFilter.Click
		mIsFiltering = True
		lstClasses.DataSource = mClassList
		lstClasses.DisplayMember = "Name"
		mIsFiltering = False
	End Sub

	Private Sub txtFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFilter.KeyDown
		If e.KeyCode = Keys.Enter Then
			mIsFiltering = True
			If String.IsNullOrEmpty(txtFilter.Text) Then
				lstClasses.DataSource = mClassList
			Else
				mFilterText = txtFilter.Text.Trim()
				lstClasses.DataSource = mClassList.FindAll(AddressOf ClassNameContains)
				lstClasses.DisplayMember = "Name"
			End If
			mIsFiltering = False
		End If
	End Sub


	Private Sub btnSendQueryBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendQueryBack.Click
		Me.mQuery = txtQuery.Text
		Me.DialogResult = Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub btnRunQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunQuery.Click
		Me.Cursor = Cursors.WaitCursor
		ExecuteQuery()
		Me.Cursor = Cursors.Default
	End Sub

	Private Sub ExecuteQuery()
		Me.lstProperties.Items.Clear()
		Me.txtResults.Text = Nothing

		Dim Server As String
		If String.IsNullOrEmpty(txtHost.Text) Then
			Server = "localhost"
		Else
			Server = txtHost.Text.Trim()
		End If
		Dim sb As New StringBuilder
		Try
			Dim Query As SelectQuery
			Query = New SelectQuery(txtQuery.Text)

			'Make Sure Name property is returned so we can figure out instance names
			If Query.SelectedProperties.Count > 0 AndAlso Not (Query.SelectedProperties.Contains("Name")) Then Query.SelectedProperties.Add("Name")

			Dim Scope As New ManagementScope(String.Format("\\{0}\root\cimv2", Server))
			Scope.Connect()

			Dim Options As New EnumerationOptions
			Options.ReturnImmediately = False
			Options.UseAmendedQualifiers = True
			Options.EnumerateDeep = True
			Options.DirectRead = False
			Dim Searcher As New ManagementObjectSearcher(Scope, Query, Options)

			Dim WMIChild As ManagementObject
			Dim DisplayName As String
			Dim Cnt As Integer = 0

			Dim Results As ManagementObjectCollection = Searcher.Get()

			For Each WMIChild In Results
				Cnt += 1

				Try	'Error is thrown if Name property does not exist...
					DisplayName = WMIChild.Item("Name").ToString
				Catch
					Try
						DisplayName = WMIChild("__RELPATH").ToString()
					Catch
						DisplayName = "No Display Name"
					End Try
				End Try
				sb.Append(DisplayName & vbCrLf)

				For Each pd As PropertyData In WMIChild.Properties
					'Add Property Name/Data to results
					If pd.Value Is Nothing Then
						If pd.IsLocal Then
							sb.AppendFormat(vbTab & "{0} = NULL" & vbCrLf, pd.Name)
						Else
							sb.AppendFormat(vbTab & "{0} = Not Local" & vbCrLf, pd.Name)
						End If
					Else
						sb.AppendFormat(vbTab & "{0} = {1}" & vbCrLf, pd.Name, pd.Value.ToString())
					End If

					'Add Instance Name/Property Name/Property Data to Monitor Counters if appropriate numeric type
					Select Case ConvertCIMType(pd.Type)
						Case TypeCode.Boolean, TypeCode.Decimal, TypeCode.Double, TypeCode.Int16, TypeCode.Int32, TypeCode.Int64, TypeCode.SByte, TypeCode.Byte, TypeCode.Single, TypeCode.UInt16, TypeCode.UInt32, TypeCode.UInt64
							'Record value
							If pd.Value IsNot Nothing Then
								Me.lstProperties.Items.Add(String.Format("{0}.{1} = {2}", DisplayName, pd.Name, CDbl(pd.Value)))
							End If
					End Select
				Next
				sb.Append(vbCrLf)
			Next
		Catch ex As Exception
			sb.Append(vbCrLf & vbCrLf & ex.ToString() & vbCrLf)
		End Try
		txtResults.Text = sb.ToString()
	End Sub
End Class
