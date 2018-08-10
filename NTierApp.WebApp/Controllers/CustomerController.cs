
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult ListCustomer()
        {
            return View();
        }
    }
}