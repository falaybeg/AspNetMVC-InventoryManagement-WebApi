using AutoMapper;
using NTier.Domain;
using NTierApp.Business.Interface;
using NTierApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private ICategoryBusiness _category;
        private ISupplierBusiness _supplier;
        private IProductBusiness _product;

        public ProductController(ICategoryBusiness category, ISupplierBusiness supplier, IProductBusiness product)
        {
            this._category = category;
            this._supplier = supplier;
            this._product = product;
        }
        
        // GET: Product
        public ActionResult ListProduct()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            var category = _category.GetAll().ToList();
            ViewBag.Category = new SelectList(category, "Id", "Name");

            var supplier = _supplier.GetAll().ToList();
            ViewBag.Supplier = new SelectList(supplier, "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model)
        {
           var result = Mapper.Map<ProductViewModel, Product>(model);
            _product.Insert(result);
            return View(); 
        }

        public ActionResult AddCategory()
        {
            var result = _category.GetAll()
                 .Select(m => new CategoryViewModel
                 {
                     Id = m.Id,
                     Name = m.Name
                 });

            return View(result);
        }
    }
}