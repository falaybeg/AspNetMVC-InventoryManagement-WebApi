using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ListProduct()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            return View();
        }
    }
}