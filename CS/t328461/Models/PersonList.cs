using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace t328461.Models
{
    public class PersonList
    {
        public List<Person> GetPersons()
        {
            if (HttpContext.Current.Session["Persons"] == null)
            {
                List<Person> list = new List<Person>();

                list.Add(new Person(1, "David", "Jordan", "Adler", "1,3"));
                list.Add(new Person(2, "Michael", "Christopher", "Alcamo", "1"));
                list.Add(new Person(3, "Amy", "Gabrielle", "Altmann", "4,3"));
                list.Add(new Person(4, "Meredith", "", "Berman", "2"));
                list.Add(new Person(5, "Margot", "Sydney", "Atlas", "1,5"));
                list.Add(new Person(6, "Eric", "Zachary", "Berkowitz", "1"));
                list.Add(new Person(7, "Kyle", "", "Bernardo", "5"));
                list.Add(new Person(8, "Liz", "", "Bice", "3"));

                HttpContext.Current.Session["Persons"] = list;
            }
            return (List<Person>)HttpContext.Current.Session["Persons"];
        }

        public void AddPerson(Person person)
        {
            List<Person> list = GetPersons();
            person.PersonID = list.Count + 1;

            list.Add(person);
        }

        public void UpdatePerson(Person personInfo)
        {
            Person editedPerson = GetPersons().Where(m => m.PersonID == personInfo.PersonID).First();
            editedPerson.FirstName = personInfo.FirstName;
            editedPerson.MiddleName = personInfo.MiddleName;
            editedPerson.LastName = personInfo.LastName;
            editedPerson.Roles = personInfo.Roles;
        }

        public void DeletePerson(int personId)
        {
            List<Person> persons = GetPersons();
            persons.Remove(persons.Where(m => m.PersonID == personId).First());
        }
    }
}