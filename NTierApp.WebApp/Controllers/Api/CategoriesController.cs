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
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        ICategoryBusiness _category;
        public CategoriesController(ICategoryBusiness category)
        {
            this._category = category;
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var result = _category.GetAll().Select(c=> new CategoryViewModel {
                Id = c.Id,
                Name = c.Name
            });
            return result;
        }

    }
}
