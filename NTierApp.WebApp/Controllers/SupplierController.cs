using NTierApp.Business.Interface;
using NTierApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class SupplierController : Controller
    {
        ISupplierBusiness _supplier;
        IOrdersBusiness _order;
        IProductBusiness _product;


        public SupplierController(ISupplierBusiness supplier)
        {
            this._supplier = supplier;
        }
        // GET: Supplier
        public ActionResult ListSupplier()
        {
            var result = _supplier.GetAll()
                .Select(s=> new SupplierViewModel {
                    Id  = s.Id,
                    Name = s.Name,
                    PhoneNumber = s.PhoneNumber,
                    Adress = s.Adress,
                    Email = s.Email
                }); 

            return View(result);
        }

        public ActionResult AddSupplier()
        {
            return View();
        }
    }
}