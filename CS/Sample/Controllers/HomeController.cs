using System.Web.Mvc;
using DevExpress.Web.Mvc;
using Sample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Controllers {
    public class HomeController : Controller {
        PersonsList list = new PersonsList();

        public ActionResult Index() {
            FillViewBag();
            return View(list.GetPersons());
        }

        public ActionResult GridViewEditingPartial() {
            FillViewBag();
            return PartialView(list.GetPersons());        
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
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Person person) {
            if (ModelState.IsValid)
                list.AddPerson(person);
            FillViewBag();
            return PartialView("GridViewEditingPartial", list.GetPersons());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate(Person personInfo) {
            string[] tokens = TokenBoxExtension.GetSelectedValues<string>("Roles");
            personInfo.Roles = string.Join(",", tokens);
            if (ModelState.IsValid)
                list.UpdatePerson(personInfo);
            FillViewBag();
            return PartialView("GridViewEditingPartial", list.GetPersons());
        }

        public ActionResult EditingDelete(int personId) {
            list.DeletePerson(personId);
            FillViewBag();
            return PartialView("GridViewEditingPartial", list.GetPersons());
        }
    }
}