using Microsoft.AspNet.Identity;
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
    public class HomeController : Controller
    {
        ISupplierBusiness _supplier;
        IProductBusiness _product;
        IOrdersBusiness _order;
        IUserBusiness _user;

        public HomeController(ISupplierBusiness supplier, IProductBusiness product, IOrdersBusiness order, IUserBusiness user)
        {
            this._supplier = supplier;
            this._product = product;
            this._order = order;
            this._user = user;
        }

        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();

            vm.TotalSuppliers = _supplier.GetAll().Count<Supplier>();
            vm.TotalOrders = _order.GetAll().Count<Orders>();
            vm.TotalProducts = _product.GetAll().Count<Product>();
            var result = _product.GetAll();
            foreach (var item in result)
            {
                vm.TotalProductValues += (item.SellingPrice + item.StockAmount);
            }
            vm.Orders = _order.GetAll().OrderByDescending(x=>x.OrderDate).Take(5);
            vm.User = _user.GetAll().Take(5);
          
            return View(vm);
        }


    }
}
