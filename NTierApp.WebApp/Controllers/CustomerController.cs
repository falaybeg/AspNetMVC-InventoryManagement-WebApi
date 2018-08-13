
using AutoMapper;
using NTierApp.Business.Interface;
using NTierApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierApp.WebApp.Controllers
{
    public class CustomerController : Controller
    {

        IUserBusiness _user;
        public CustomerController(IUserBusiness user)
        {
            this._user = user;
        }

        // GET: Customer
        public ActionResult ListCustomer()
        {
            var result = _user.GetAll().Select(x=> new CustomerViewModel {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                CardNumber = x.CardNumber,
                RegisteredDate = x.RegisteredDate
            });
            return View(result);
        }
    }
}