using NtierApp.Repository.Context;
using NTierApp.WebApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        InventoryDbContext db;

        public CustomerController()
        {
            db = new InventoryDbContext();
        }

        // GET: Customer
        public ActionResult ListCustomer()
        {
            var result = (from user in db.Users
                          from userRole in user.Roles
                          join role in db.Roles on userRole.RoleId equals
                          role.Id
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

        public ActionResult EditRole(string id)
        {



            return View();
        }

        public ActionResult Deneme()
        {

            var usersWithRoles = (from user in db.Users
                                  from userRole in user.Roles
                                  join role in db.Roles on userRole.RoleId equals
                                  role.Id
                                  select new UserManagementViewModel()
                                  {
                                      Id = user.Id,
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                      Email = user.Email,
                                      RoleName = role.Name
                                  }).ToList();



            return View(usersWithRoles);
        }
    }
}