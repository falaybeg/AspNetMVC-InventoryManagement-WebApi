using AutoMapper;
using NTier.Domain;
using NTierApp.Business.Interface;
using NTierApp.WebApp.Models;
using System.Linq;
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
            var result = _product.GetAll().Select(x => new ProductViewModel
            {

                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                PurchasingPrice = x.PurchasingPrice,
                SellingPrice = x.SellingPrice,
                Category = x.Category,
                Supplier = x.Supplier,
                Quantity = x.Quantity
            });

            return View(result);
        }

        public ActionResult AddProduct()
        {

            var category = _category.GetAll().ToList();
            ViewBag.Category = new SelectList(category, "Id", "Name");

            var supplier = _supplier.GetAll().ToList();
            ViewBag.Supplier = new SelectList(supplier, "Id", "Name");

            return View();
        }

        public ActionResult EditProduct(int id)
        {
            if (id > 0)
            {
                var product = _product.GetById(id);
                if (product != null)
                {
                    var vm = new ProductViewModel
                    {
                        Id = product.Id,
                        Code = product.Code,
                        Name = product.Name,
                        CategoryId = product.CategoryId,
                        SupplierId = product.SupplierId,
                        PurchasingPrice = product.PurchasingPrice,
                        SellingPrice = product.SellingPrice,
                        Quantity = product.Quantity

                    };

                    var category = _category.GetAll().ToList();
                    ViewBag.Category = new SelectList(category, "Id", "Name");

                    var supplier = _supplier.GetAll().ToList();
                    ViewBag.Supplier = new SelectList(supplier, "Id", "Name");
                    return View("AddProduct", vm);

                }

            }

            return View("AddProduct");
        }


        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model)
        {
            var result = Mapper.Map<ProductViewModel, Product>(model);
            _product.Insert(result);
            return View();
        }

        public ActionResult CategoryList()
        {
            var result = _category.GetAll()
                 .Select(m => new CategoryViewModel
                 {
                     Id = m.Id,
                     Name = m.Name
                 });

            return View(result);
        }

        public ActionResult EditCategory(int id)
        {
            var result = _category.GetById(id);

            CategoryViewModel model = new CategoryViewModel
            {
                Id = result.Id,
                Name = result.Name
            };
            return View("EditCategory", model);
        }

    }
}