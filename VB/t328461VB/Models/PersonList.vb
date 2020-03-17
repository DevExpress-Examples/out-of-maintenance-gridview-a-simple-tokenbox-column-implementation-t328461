Public Class PersonList
    Public Function GetPersons() As List(Of Person)
        If HttpContext.Current.Session("Persons") Is Nothing Then
            Dim list As New List(Of Person)()

            list.Add(New Person(1, "David", "Jordan", "Adler", "1,3"))
            list.Add(New Person(2, "Michael", "Christopher", "Alcamo", "1"))
            list.Add(New Person(3, "Amy", "Gabrielle", "Altmann", "4,3"))
            list.Add(New Person(4, "Meredith", "", "Berman", "2"))
            list.Add(New Person(5, "Margot", "Sydney", "Atlas", "1,5"))
            list.Add(New Person(6, "Eric", "Zachary", "Berkowitz", "1"))
            list.Add(New Person(7, "Kyle", "", "Bernardo", "5"))
            list.Add(New Person(8, "Liz", "", "Bice", "3"))

            HttpContext.Current.Session("Persons") = list
        End If
        Return DirectCast(HttpContext.Current.Session("Persons"), List(Of Person))
    End Function

    Public Sub AddPerson(ByVal person As Person)
        Dim list As List(Of Person) = GetPersons()
        person.PersonID = list.Count + 1

        list.Add(person)
    End Sub

    Public Sub UpdatePerson(ByVal personInfo As Person)
        Dim editedPerson As Person = GetPersons().Where(Function(m) m.PersonID = personInfo.PersonID).First()
        editedPerson.FirstName = personInfo.FirstName
        editedPerson.MiddleName = personInfo.MiddleName
        editedPerson.LastName = personInfo.LastName
        editedPerson.Roles = personInfo.Roles
    End Sub

    Public Sub DeletePerson(ByVal personId As Integer)
        Dim persons As List(Of Person) = GetPersons()
        persons.Remove(persons.Where(Function(m) m.PersonID = personId).First())
    End Sub
End Class
