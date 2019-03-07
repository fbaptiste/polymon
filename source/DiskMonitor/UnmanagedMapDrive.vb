Imports System.Runtime
Imports System.Runtime.InteropServices

Class UnmanagedMapDrive
  <StructLayout(LayoutKind.Sequential)> _
  Class NETRESOURCE
    Public dwScope As Integer
    Public dwType As Integer
    Public dwDisplayType As Integer
    Public dwUsage As Integer
    Public LocalName As String
    Public RemoteName As String
    Public Comment As String
    Public Provider As String
  End Class 'NETRESOURCE

  Private Declare Function WNetAddConnection2 Lib "mpr.dll" Alias "WNetAddConnection2A" (ByVal netResource As NETRESOURCE, ByVal password As String, ByVal Username As String, ByVal Flag As Int32) As Int32
  Private Declare Function WNetCancelConnection2 Lib "mpr.dll" Alias "WNetCancelConnection2A" (ByVal lpName As String, ByVal dwFlags As Int32, ByVal fForce As Int32) As Int32

  Public Shared Function MapDrive(ByVal sharePath As String, ByVal driveLetter As Char) As Integer
    Dim myNetResource As New NETRESOURCE
    myNetResource.dwScope = 2 'RESOURCE_GLOBALNET
    myNetResource.dwType = 1 'RESOURCETYPE_DISK
    myNetResource.dwDisplayType = 3 'RESOURCEDISPLAYTYPE_SHARE
    myNetResource.dwUsage = 1 'RESOURCEUSAGE_CONNECTABLE
    myNetResource.LocalName = driveLetter.ToString & ":"
    myNetResource.RemoteName = sharePath
    myNetResource.Provider = Nothing
    Return WNetAddConnection2(myNetResource, Nothing, Nothing, 0)
  End Function

  Public Shared Function UnmapDrive(ByVal driveletter As Char) As Integer
    Return WNetCancelConnection2(driveletter.ToString & ":", 1, 1)
  End Function

End Class
