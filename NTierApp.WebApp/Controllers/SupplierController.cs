using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult ListSupplier()
        {
            return View();
        }

        public ActionResult AddSupplier()
        {
            return View();
        }
    }
}