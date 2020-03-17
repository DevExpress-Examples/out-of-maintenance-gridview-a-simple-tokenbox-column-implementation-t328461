Imports DevExpress.Web.Mvc

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private list As New PersonList()

    Function Index() As ActionResult
        Return View()
    End Function

    Public Function GridViewEditingPartial() As ActionResult
        FillViewBag()
        Return PartialView("_GridViewEditingPartial", list.GetPersons())
    End Function

    Private Sub FillViewBag()
        ViewBag.Roles = New List(Of Role)() From {
            New Role() With {.RoleID = 1, .RoleName = "Role 1"},
            New Role() With {.RoleID = 2, .RoleName = "Role 2"},
            New Role() With {.RoleID = 3, .RoleName = "Role 3"},
            New Role() With {.RoleID = 4, .RoleName = "Role 4"},
            New Role() With {.RoleID = 5, .RoleName = "Role 5"}
        }
    End Sub


    <HttpPost, ValidateInput(False)>
    Public Function EditingAddNew(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal person As Person) As ActionResult
        If ModelState.IsValid Then
            list.AddPerson(person)
        End If
        FillViewBag()
        Return PartialView("_GridViewEditingPartial", list.GetPersons())
    End Function

    <HttpPost, ValidateInput(False)>
    Public Function EditingUpdate(ByVal personInfo As Person) As ActionResult
        Dim tokens() As String = TokenBoxExtension.GetSelectedValues(Of String)("Roles")
        personInfo.Roles = String.Join(",", tokens)
        If ModelState.IsValid Then
            list.UpdatePerson(personInfo)
        End If
        FillViewBag()
        Return PartialView("_GridViewEditingPartial", list.GetPersons())
    End Function

    Public Function EditingDelete(ByVal personId As Integer) As ActionResult
        list.DeletePerson(personId)
        FillViewBag()
        Return PartialView("_GridViewEditingPartial", list.GetPersons())
    End Function
End Class