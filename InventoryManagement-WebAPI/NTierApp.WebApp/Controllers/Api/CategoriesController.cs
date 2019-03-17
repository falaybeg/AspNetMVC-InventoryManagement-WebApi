using NTier.Domain;
using NTierApp.Business.Interface;
using NTierApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NTierApp.WebApp.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        ICategoryBusiness _category;
        public CategoriesController(ICategoryBusiness category)
        {
            this._category = category;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _category.GetAll().Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            });
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var result = _category.GetById(id);

            if(result != null)
            {
                CategoryViewModel vm = new CategoryViewModel
                {
                    Id = result.Id,
                    Name = result.Name
                };
                return Ok(vm);
            }
            return Ok(HttpStatusCode.NotFound);
        }

        [HttpPost]
        public IHttpActionResult Insert(CategoryViewModel model)
        {
            Category category = new Category
            {
                Name = model.Name
            };

            _category.Insert(category);
            return Ok(category);
        }

        [HttpPut]
        public IHttpActionResult Update(CategoryViewModel model)
        {
            Category category = new Category
            {
                Id = model.Id,
                Name = model.Name
            };

            _category.Update(category);
            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _category.Delete(id);
            return Ok("Deleted Successfully !");
        }

    }
}
