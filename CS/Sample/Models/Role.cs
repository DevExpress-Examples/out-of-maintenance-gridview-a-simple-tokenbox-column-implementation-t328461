﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public class Role
    {

         public Role() {
            RoleID = 0;
            RoleName = string.Empty;
        }

        public Role(int id, String name) {
            this.RoleID = id;
            this.RoleName = name;
        }

        [Key]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }
    }
}