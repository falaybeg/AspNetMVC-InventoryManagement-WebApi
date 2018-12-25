using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NtierApp.Repository.Context;
using NTierApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NTierApp.WebApp.Controllers.Api
{
    public class RolesController : ApiController
    {
        RoleStore<IdentityRole> roleStore = null;
        RoleManager<IdentityRole> roleManager;

        public RolesController()
        {
            roleStore = new RoleStore<IdentityRole>(new InventoryDbContext()); ;
            roleManager = new RoleManager<IdentityRole>(roleStore);
        }



        [HttpGet]
        public IHttpActionResult GetById(string Id)
        {
            var result = roleManager.FindById(Id);
            return Ok(result);
        }


        [HttpPost]
        public IHttpActionResult CreateRole(RoleViewModel role)
        {
            bool result = roleManager.RoleExists(role.RoleName);

            if (result != true)
            {
                IdentityRole x = new IdentityRole
                {
                    Name = role.RoleName
                };
                roleManager.CreateAsync(x);
                return Ok("Role was created successfuly");
            }

            return BadRequest("This role is exist");
        }

        [HttpPut]
        public IHttpActionResult UpdateRole(RoleViewModel role)
        {
            IdentityRole model = new IdentityRole
            {
                Id = role.Id,
                Name = role.RoleName
            };
            roleManager.UpdateAsync(model);
            return Ok("Role was updated successfuly");
        }

        [HttpDelete]
        public IHttpActionResult DeleteRole(string id)
        {
            var result = roleManager.FindById(id);
            roleManager.Delete(result);
            return Ok("Role was deleted successfuly");
        }

    }
}