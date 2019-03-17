using NTier.Domain;
using NTierApp.Business.Interface;
using NTierApp.WebApp.Models;
using System.Linq;
using System.Web.Http;

namespace NTierApp.WebApp.Controllers.Api
{
    [Authorize]
    public class ProductsController : ApiController
    {
        private IProductBusiness _product;
        public ProductsController(IProductBusiness product)
        {
            this._product = product;
        }


        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _product.GetAll().Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                PurchasingPrice = x.PurchasingPrice,
                SellingPrice = x.SellingPrice,
                Quantity = x.Quantity,
                CategoryId = x.CategoryId,
                SupplierId = x.SupplierId,
                CategoryName = x.Category.Name
            });

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var result = _product.GetById(id);
            if (result != null)
            {
                ProductViewModel vm = new ProductViewModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    Code = result.Code,
                    PurchasingPrice = result.PurchasingPrice,
                    SellingPrice = result.SellingPrice,
                    Quantity = result.Quantity,
                    CategoryId = result.CategoryId,
                    SupplierId = result.SupplierId
                };
                return Ok(vm);
            }
            return Ok("Item Not Found !");
        }

        [HttpPost]
        public IHttpActionResult Insert(ProductViewModel model)
        {
            Product product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
                PurchasingPrice = model.PurchasingPrice,
                SellingPrice = model.SellingPrice,
                Quantity = model.Quantity,
                CategoryId = model.CategoryId,
                SupplierId = model.SupplierId
            };
            _product.Insert(product);
            return Ok(product);
        }

        [HttpPut]
        public IHttpActionResult Update(ProductViewModel model)
        {
            Product product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
                PurchasingPrice = model.PurchasingPrice,
                SellingPrice = model.SellingPrice,
                Quantity = model.Quantity,
                CategoryId = model.CategoryId,
                SupplierId = model.SupplierId
            };
            _product.Update(product);
            return Ok(product);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _product.Delete(id);
            return Ok("Deleted Successfully !");
        }
    }
}
