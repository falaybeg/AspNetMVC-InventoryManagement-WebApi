using System;
using System.Linq;
using System.Web.Http;
using NTier.Domain;
using NTierApp.Business.Interface;
using NTierApp.WebApp.Models;

namespace NTierApp.WebApp.Controllers.Api
{
    [Authorize]
    public class SuppliersController : ApiController
    {
        private ISupplierBusiness _supplier;

        public SuppliersController(ISupplierBusiness supplier)
        {
            this._supplier = supplier;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _supplier.GetAll().Select(c => new SupplierViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Adress = c.Adress,
                PhoneNumber = c.PhoneNumber

            });
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var result = _supplier.GetById(id);

            if (result != null)
            {
                SupplierViewModel vm = new SupplierViewModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    Adress = result.Adress,
                    PhoneNumber = result.PhoneNumber
                };
                return Ok(vm);
            }
            return Ok("Item Not Found!");
        }

        [HttpPost]
        public IHttpActionResult Insert(SupplierViewModel model)
        {
            Supplier supplier = new Supplier
            {
                Id = model.Id,
                Name = model.Name,
                Adress = model.Adress,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };

            _supplier.Insert(supplier);
            return Ok(supplier);
        }
        [HttpPut]
        public IHttpActionResult Update(SupplierViewModel model)
        {
            Supplier supplier = new Supplier
            {
                Id = model.Id,
                Name = model.Name,
                Adress = model.Adress,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };

            _supplier.Update(supplier);
            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _supplier.Delete(id);
            return Ok("Deleted Successfully !");
        }
    }
}
