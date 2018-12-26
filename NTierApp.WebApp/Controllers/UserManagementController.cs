using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using NtierApp.Repository.Context;
using NTierApp.WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class UserManagementController : Controller
    {
        InventoryDbContext db;
        private ApplicationUserManager _userManager;
        RoleStore<IdentityRole> roleStore = null;
        RoleManager<IdentityRole> roleManager;



        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public UserManagementController()
        {
            db = new InventoryDbContext();

        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [Authorize]
        public ActionResult MyAccount()
        {
            return View();
        }

        [Authorize]
        public ActionResult UserList()
        {
            var result = (from user in db.Users
                          from userRole in user.Roles
                          join role in db.Roles on userRole.RoleId equals role.Id
                          select new UserManagementViewModel()
                          {
                              Id = user.Id,
                              FirstName = user.FirstName,
                              LastName = user.LastName,
                              PhoneNumber = user.PhoneNumber,
                              Email = user.Email,
                              CardNumber = user.CardNumber,
                              RegisteredDate = user.RegisteredDate,
                              RoleName = role.Name
                          }).ToList();

            return View(result);
        }


        public ActionResult EditUser()
        {
            roleStore = new RoleStore<IdentityRole>(new InventoryDbContext()); ;
            roleManager = new RoleManager<IdentityRole>(roleStore);

            var roles = roleManager.Roles.ToList();
            ViewBag.Roles = new SelectList(roles, "Name", "Name");

            //List<SelectListItem> items = new List<SelectListItem>();
            //foreach(var item in roles)
            //{
            //    items.Add(new SelectListItem { Text = item.Name, Value = item.Name });
            //}


            return View("EditUser");
        }

        [Authorize]
        public ActionResult UpdateUser(string id)
        {
            roleStore = new RoleStore<IdentityRole>(new InventoryDbContext()); ;
            roleManager = new RoleManager<IdentityRole>(roleStore);
            //var resul = await UserManager.AddToRoleAsync("88b3e953-471f-43e0-89d1-23fde676b466","DepoMuduru");
            if (id != null)
            {
                var result = UserManager.FindByIdAsync(id);
                var user = result.Result;
                if (user != null)
                {
                    var roleName = UserManager.GetRoles(id);
                    var vm = new UserManagementViewModel
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email,
                        RegisteredDate = user.RegisteredDate,
                        RoleName = roleName[0]
                    };

                    var roles = roleManager.Roles.ToList();
                    //ViewData["Roles"] = new SelectList(roles, null, "Name");
                    ViewBag.Roles = new SelectList(roles, "Name", "Name");

                    return View("EditUser",vm);
                }
            }
            return View("EditUser");

        }

       
  
    }
}