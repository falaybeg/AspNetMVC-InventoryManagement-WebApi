using NTier.Domain;
using NtierApp.Repository.Infrastucture.Contract;
using NtierApp.Repository.Repositories;
using NTierApp.Business.Interface;
using System;
using System.Collections.Generic;

namespace NTierApp.Business
{
    public class OrdersBusiness : IOrdersBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly OrderRepository _orderRepository;
        private readonly IProductBusiness _productBusiness;

        public OrdersBusiness(IUnitOfWork _unitOfWork, IProductBusiness productBusiness)
        {
            this.unitOfWork = _unitOfWork;
            this._productBusiness = productBusiness;
            this._orderRepository = new OrderRepository(unitOfWork);
        }
        public IEnumerable<Orders> GetAll()
        {
            var result = _orderRepository.GetAll();
            return result;
        }
        public IEnumerable<Orders> GetAllConfirmedOrders()
        {
            var result = _orderRepository.GetAll(x => x.ConfirmStatus == true);
            return result;
        }

        public IEnumerable<Orders> GetMyOrders(string userId)
        {
            var result = _orderRepository.GetAll(x => x.UserId == userId);
            return result;
        }

        public IEnumerable<Orders> GetAllUnConfirmedOrders()
        {
            var result = _orderRepository.GetAll(x => x.ConfirmStatus == false);
            return result;
        }

        public Orders GetById(int orderId)
        {
            Orders result = null;
            if (orderId != null)
                result = _orderRepository.GetById(x => x.Id == orderId);

            return result;
        }

        public void Insert(Orders order)
        {

            if (order != null)
            {

                order.OrderDate = DateTime.Now;
                order.ConfirmStatus = false;
                order.ConfirmDate = DateTime.Now;
                var product = _productBusiness.GetById(order.ProductId);
                product.Quantity--;
                _orderRepository.Insert(order);
                _productBusiness.Update(product);
            }
        }

        public void Update(Orders order)
        {
            if (order != null)
            {
                order.OrderDate = DateTime.Now;
                order.ConfirmDate = DateTime.Now;
                order.ConfirmStatus = false;
                _orderRepository.Update(order);
            }
        }

        public void Delete(int orderId)
        {
            if (orderId != null)
                _orderRepository.Delete(x => x.Id == orderId);
        }

        public void ConfirmOrder(int orderId)
        {
            if (orderId != null)
            {
                var result = _orderRepository.GetById(x => x.Id == orderId);
                result.ConfirmStatus = true;
                result.ConfirmDate = DateTime.Now;
                _orderRepository.Update(result);
            }
        }

       
    }
}
