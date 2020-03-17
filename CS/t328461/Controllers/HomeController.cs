using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using t328461.Models;

namespace t328461.Controllers
{
    public class HomeController : Controller
    {
        PersonList list = new PersonList();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridViewEditingPartial()
        {
            FillViewBag();
            return PartialView("_GridViewEditingPartial", list.GetPersons());
        }

        private void FillViewBag()
        {
            ViewBag.Roles = new List<Role>()
            {
                new Role(){ RoleID = 1, RoleName = "Role 1"},
                new Role(){ RoleID = 2, RoleName = "Role 2"},
                new Role(){ RoleID = 3, RoleName = "Role 3"},
                new Role(){ RoleID = 4, RoleName = "Role 4"},
                new Role(){ RoleID = 5, RoleName = "Role 5"}
            };
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew(Person person)
        {
            if (ModelState.IsValid)
                list.AddPerson(person);
            FillViewBag();
            return PartialView("_GridViewEditingPartial", list.GetPersons());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate(Person personInfo)
        {
            string[] tokens = TokenBoxExtension.GetSelectedValues<string>("Roles");
            personInfo.Roles = string.Join(",", tokens);
            if (ModelState.IsValid)
                list.UpdatePerson(personInfo);
            FillViewBag();
            return PartialView("_GridViewEditingPartial", list.GetPersons());
        }

        public ActionResult EditingDelete(int personId)
        {
            list.DeletePerson(personId);
            FillViewBag();
            return PartialView("_GridViewEditingPartial", list.GetPersons());
        }
    }
}