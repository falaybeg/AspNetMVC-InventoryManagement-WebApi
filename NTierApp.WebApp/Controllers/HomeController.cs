using NTierApp.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        ICategoryBusiness _category;
        public HomeController(ICategoryBusiness category)
        {
            this._category = category;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult GetAll()
        {
            var result = _category.GetAll();
            return View(result);
        }
    }
}
