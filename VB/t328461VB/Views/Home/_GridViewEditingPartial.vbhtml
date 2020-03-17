@ModelType List(Of t328461VB.Person)
    @Html.DevExpress().GridView(Sub(settings)

                                     settings.Name = "grid"
                                     settings.KeyFieldName = "PersonID"
                                     settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewEditingPartial"}

                                     settings.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow
                                     settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Home", .Action = "EditingAddNew"}
                                     settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "EditingUpdate"}
                                     settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Home", .Action = "EditingDelete"}

                                     settings.CommandColumn.Visible = True
                                     settings.CommandColumn.ShowNewButton = True
                                     settings.CommandColumn.ShowDeleteButton = True
                                     settings.CommandColumn.ShowEditButton = True

                                     settings.Columns.Add("FirstName")
                                     settings.Columns.Add("MiddleName")
                                     settings.Columns.Add("LastName")
                                     settings.Columns.Add(Sub(column)

                                                              column.FieldName = "Roles"
                                                              column.ColumnType = MVCxGridViewColumnType.TokenBox

                                                              Dim TokenBoxSettings = DirectCast(column.PropertiesEdit, TokenBoxProperties)
                                                              TokenBoxSettings.TextField = "RoleName"
                                                              TokenBoxSettings.ValueField = "RoleID"
                                                              TokenBoxSettings.ShowDropDownOnFocus = ShowDropDownOnFocusMode.Always
                                                              TokenBoxSettings.AllowCustomTokens = False
                                                              TokenBoxSettings.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                              TokenBoxSettings.DataSource = ViewBag.Roles
                                                              TokenBoxSettings.ItemValueType = GetType(Int32)
                                                              TokenBoxSettings.Width = 300
                                                          End Sub)

                                 End Sub).Bind(Model).GetHtml()
