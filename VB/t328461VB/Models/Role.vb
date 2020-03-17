Imports System.ComponentModel.DataAnnotations

Public Class Role

    Public Sub New()
        RoleID = 0
        RoleName = String.Empty
    End Sub

    Public Sub New(ByVal id As Integer, ByVal name As String)
        Me.RoleID = id
        Me.RoleName = name
    End Sub

    <Key>
    Public Property RoleID() As Integer

    <Required(ErrorMessage:="Role Name is required")>
    Public Property RoleName() As String
End Class