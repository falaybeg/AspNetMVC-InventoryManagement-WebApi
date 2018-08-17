using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NTier.Domain;
using NTierApp.Business.Interface;
using NTierApp.WebApp.Models;

namespace NTierApp.WebApp.Controllers.Api
{
    [Authorize]
    public class OrdersController : ApiController
    {
        private IOrdersBusiness _order;

        public OrdersController(IOrdersBusiness order)
        {
            this._order = order;
        }


        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _order.GetAll().Select(x=> new OrderViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UserId = x.UserId,
                OrderDate = x.OrderDate,
                ConfirmDate = x.ConfirmDate,
                ConfirmStatus = x.ConfirmStatus
            });
            return Ok(result);
        }

        [Route("api/Orders/ConfirmedOrders")]
        [HttpGet]
        public IHttpActionResult GetAllConfirmedOrders()
        {
            var result = _order.GetAllConfirmedOrders().Select(x => new OrderViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UserId = x.UserId,
                OrderDate = x.OrderDate,
                ConfirmDate = x.ConfirmDate,
                ConfirmStatus = x.ConfirmStatus
            });
            return Ok(result);
        }
        [Route("api/Orders/GetMyOrders")]
        [HttpGet]
        public IHttpActionResult GetMyOrders()
        {
            var UserId = User.Identity.GetUserId();
            var result = _order.GetMyOrders(UserId)
                .Select(x => new OrderViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                ProductCategory = x.Product.Category.Name,
                UserId = x.UserId,
                OrderDate = x.OrderDate,
                ConfirmDate = x.ConfirmDate,
                ConfirmStatus = x.ConfirmStatus,
                ShippingAddress = x.ShippingAddress

            }).OrderByDescending(x=>x.OrderDate);

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var result = _order.GetById(id);
            if (result != null)
            {
                OrderViewModel vm = new OrderViewModel
                {
                    Id = result.Id,
                    OrderDate = result.OrderDate,
                    ProductId = result.ProductId,
                    ConfirmDate = result.ConfirmDate,
                    ConfirmStatus = result.ConfirmStatus,
                    UserId = result.UserId
                };
                return Ok(vm);
            }
            return Ok("Item Not Found!");
        }
        [HttpPost]
        public IHttpActionResult Insert(OrderViewModel model)
        {
            Orders order = new Orders
            {
                ProductId = model.ProductId,
                UserId = User.Identity.GetUserId(),
                ShippingAddress = model.ShippingAddress
            };
            _order.Insert(order);
            return Ok(order);
        }

        [HttpPut]
        public IHttpActionResult Update(OrderViewModel model)
        {
            Orders order = new Orders
            {
                Id = model.Id,
                ProductId = model.ProductId,
                UserId = model.UserId,
                ShippingAddress = model.ShippingAddress
            };
            _order.Update(order);
            return Ok(order);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _order.Delete(id);
            return Ok("Deleted Successfully !");
        }

        [Route("api/Orders/ConfirmOrder")]
        public IHttpActionResult ConfirmOrder(int id)
        {
            _order.ConfirmOrder(id);
            return Ok("Order Confirmend !");
        }
    }
}
