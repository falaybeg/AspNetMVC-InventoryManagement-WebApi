using NTier.Domain;
using NtierApp.Repository;
using NtierApp.Repository.Infrastucture.Contract;
using NtierApp.Repository.Repositories;
using NTierApp.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Business
{
    class OrdersBusiness : IOrdersBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly OrderRepository _orderRepository;

        public OrdersBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
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
                order.Product.StockAmount--;
                _orderRepository.Insert(order);
            }
        }

        public void Update(Orders order)
        {
            if (order != null)
                _orderRepository.Update(order);
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
                _orderRepository.Update(result);
            }
        }


    }
}
