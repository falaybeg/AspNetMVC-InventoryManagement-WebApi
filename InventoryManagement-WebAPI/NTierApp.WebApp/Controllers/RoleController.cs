using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NtierApp.Repository.Context;
using NTierApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class RoleController : Controller
    {
        RoleStore<IdentityRole> roleStore = null;
        RoleManager<IdentityRole> roleManager;

        public RoleController()
        {
            roleStore = new RoleStore<IdentityRole>(new InventoryDbContext()); ;
            roleManager = new RoleManager<IdentityRole>(roleStore);
        }

        public ActionResult RoleList()
        {
            var result = roleManager.Roles.ToList();
            List<RoleViewModel> model = new List<RoleViewModel>();

            foreach (var item in result)
            {
                model.Add(new RoleViewModel { Id = item.Id, RoleName = item.Name });
            }

            return View(model);
        }

        public ActionResult EditRole(string id)
        {
            var result = roleManager.FindById(id);

            RoleViewModel model = new RoleViewModel
            {
                Id = result.Id,
                RoleName = result.Name
            };

            return View(model);
        }
    }
}