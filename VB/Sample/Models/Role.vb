Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.ComponentModel.DataAnnotations

Namespace Sample.Models
    Public Class Role

         Public Sub New()
            RoleID = 0
            RoleName = String.Empty
         End Sub

        Public Sub New(ByVal id As Integer, ByVal name As String)
            Me.RoleID = id
            Me.RoleName = name
        End Sub

        <Key> _
        Public Property RoleID() As Integer

        <Required(ErrorMessage := "Role Name is required")> _
        Public Property RoleName() As String
    End Class
End Namespace