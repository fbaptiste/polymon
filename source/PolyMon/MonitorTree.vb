Imports System.Data
Imports System.Data.SqlClient

Namespace Monitors
    Public Class MonitorTree  'May implement later if need for a Tree view is desired

#Region "Private Properties"
        Private mSQLConn As String


#End Region

#Region "Public Interface"
        Public Enum TreeNodeType As Integer
            'Corresponds to database NodeType table entries
            Folder = 1
            Monitor = 2
        End Enum





#End Region

#Region "Private Methods"

#End Region
    End Class

    Public Class TreeNode
        Private mSQLConn As String
        Private mNodeID As Integer
        Private mParentNodeID As Integer = -1 'default to Root node
        Private mNodeType As PolyMon.Monitors.MonitorTree.TreeNodeType
        Private mMonitorID As Integer = -1
        Private mFolderName As String = Nothing
        Private mDisplayOrder As Integer

        Public Sub New(ByVal NodeID As Integer)
            mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

            'Read Node data from database
            mNodeID = NodeID
            ReadNodeData(mNodeID)
        End Sub

        Public ReadOnly Property NodeID() As Integer
            Get
                Return mNodeID
            End Get
        End Property

        Public ReadOnly Property ParentNodeID() As Integer
            Get
                Return mParentNodeID
            End Get
        End Property

        Public ReadOnly Property NodeType() As PolyMon.Monitors.MonitorTree.TreeNodeType
            Get
                Return mNodeType
            End Get
        End Property

        Public ReadOnly Property MonitorID() As Integer
            Get
                Return mMonitorID
            End Get
        End Property

        Public ReadOnly Property FolderName() As String
            Get
                Return mFolderName
            End Get
        End Property

        Public ReadOnly Property DisplayOrder() As Integer
            Get
                Return mDisplayOrder
            End Get
        End Property

        Private Sub ReadNodeData(ByVal NodeID As Integer)
            Dim SQLConn As New SqlConnection(mSQLConn)
            Dim sp As String = "polymon_sel_ReadNode"

            Dim prmNodeID As New SqlParameter
            With prmNodeID
                .ParameterName = "@NodeID"
                .SqlDbType = SqlDbType.Int
                .Direction = ParameterDirection.Input
                .Value = NodeID
            End With

            Dim sqlCmd As New SqlCommand
            sqlCmd.Connection = SQLConn
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.CommandText = sp
            sqlCmd.Parameters.Add(prmNodeID)

            Try
                SQLConn.Open()
                Dim drNode As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                While drNode.Read()
                    If Not IsDBNull(drNode.Item("ParentNodeID")) Then mParentNodeID = CInt(drNode.Item("ParentNodeID"))
                    mNodeType = CType(drNode.Item("NodeTypeID"), PolyMon.Monitors.MonitorTree.TreeNodeType)
                    If mNodeType = PolyMon.Monitors.MonitorTree.TreeNodeType.Folder Then
                        mFolderName = CStr(drNode.Item("FolderName"))
                    Else
                        mMonitorID = CInt(drNode.Item("MonitorID"))
                    End If
                    mDisplayOrder = CInt(drNode.Item("DisplayOrder"))
                End While
            Catch ex As Exception
                Throw New System.Exception(ex.Message, ex)
            Finally
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                SQLConn.Dispose()
            End Try
        End Sub
    End Class

    Public Class TreeNodes
        Implements IEnumerable

        Friend mTreeNodes As Collection

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return New TreeNodeEnumerator(Me)
        End Function
        Default Public ReadOnly Property TreeNode(ByVal index As Integer) As TreeNode
            'For some reason, .NET defines Collection base as one, inconsistent with rest of framework
            'Need to code around this to make our collections zero based.
            Get
                Return CType(mTreeNodes.Item(index + 1), TreeNode)
            End Get
        End Property

        Public Class TreeNodeEnumerator
            Implements IEnumerator

            Private mIndex As Integer = -1
            Private mTreeNodes As TreeNodes

            Public Sub New(ByVal TreeNodes As TreeNodes)
                mTreeNodes = TreeNodes
            End Sub


            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    If mIndex > -1 Then
                        Return mTreeNodes.TreeNode(mIndex)
                    Else
                        Return Nothing
                    End If
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                mIndex += 1

                If mIndex < mTreeNodes.mTreeNodes.Count Then
                    Return True
                Else
                    Return False
                End If

            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                mIndex = -1
            End Sub
        End Class
    End Class
End Namespace