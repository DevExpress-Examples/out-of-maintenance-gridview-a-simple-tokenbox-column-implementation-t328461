using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace t328461.Models
{
    public class Person
    {
        public Person()
        {
            PersonID = 0;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Roles = string.Empty;
        }

        public Person(int id, String firstName, string middleName, String lastName, string roles)
        {
            this.PersonID = id;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Roles = roles;
        }

        [Key]
        public int PersonID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        public object Roles { get; set; }
    }
}