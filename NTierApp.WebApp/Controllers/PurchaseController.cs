using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult ListPurchase()
        {
            return View();
        }

        public ActionResult AddPurchase()
        {
            return View();
        }
    }
}