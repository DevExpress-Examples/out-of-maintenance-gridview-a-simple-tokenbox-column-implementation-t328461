Imports System.ComponentModel.DataAnnotations

Public Class Person
    Public Sub New()
        PersonID = 0
        FirstName = String.Empty
        MiddleName = String.Empty
        LastName = String.Empty
        Roles = String.Empty
    End Sub

    Public Sub New(ByVal id As Integer, ByVal firstName As String, ByVal middleName As String, ByVal lastName As String, ByVal roles As String)
        Me.PersonID = id
        Me.FirstName = firstName
        Me.MiddleName = middleName
        Me.LastName = lastName
        Me.Roles = roles
    End Sub

    <Key>
    Public Property PersonID() As Integer

    <Required(ErrorMessage:="First Name is required")>
    Public Property FirstName() As String

    Public Property MiddleName() As String

    <Required(ErrorMessage:="Last Name is required")>
    Public Property LastName() As String
    Public Property Roles() As Object
End Class