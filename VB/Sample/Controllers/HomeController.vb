Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports Sample.Models
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Sample.Controllers
    Public Class HomeController
        Inherits Controller

        Private list As New PersonsList()

        Public Function Index() As ActionResult
            FillViewBag()
            Return View(list.GetPersons())
        End Function

        Public Function GridViewEditingPartial() As ActionResult
            FillViewBag()
            Return PartialView(list.GetPersons())
        End Function

        Private Sub FillViewBag()
            ViewBag.Roles = New List(Of Role)() From { _
                New Role() With {.RoleID = 1, .RoleName = "Role 1"}, _
                New Role() With {.RoleID = 2, .RoleName = "Role 2"}, _
                New Role() With {.RoleID = 3, .RoleName = "Role 3"}, _
                New Role() With {.RoleID = 4, .RoleName = "Role 4"}, _
                New Role() With {.RoleID = 5, .RoleName = "Role 5"} _
            }
        End Sub


        <HttpPost, ValidateInput(False)> _
        Public Function EditingAddNew(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal person As Person) As ActionResult
            If ModelState.IsValid Then
                list.AddPerson(person)
            End If
            FillViewBag()
            Return PartialView("GridViewEditingPartial", list.GetPersons())
        End Function

        <HttpPost, ValidateInput(False)> _
        Public Function EditingUpdate(ByVal personInfo As Person) As ActionResult
            Dim tokens() As String = TokenBoxExtension.GetSelectedValues(Of String)("Roles")
            personInfo.Roles = String.Join(",", tokens)
            If ModelState.IsValid Then
                list.UpdatePerson(personInfo)
            End If
            FillViewBag()
            Return PartialView("GridViewEditingPartial", list.GetPersons())
        End Function

        Public Function EditingDelete(ByVal personId As Integer) As ActionResult
            list.DeletePerson(personId)
            FillViewBag()
            Return PartialView("GridViewEditingPartial", list.GetPersons())
        End Function
    End Class
End Namespace