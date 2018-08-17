using NTier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Business.Interface
{
    public interface IOrdersBusiness
    {
        Orders GetById(int orderId);
        IEnumerable<Orders> GetAll();
        void Insert(Orders order);
        void Update(Orders order);
        void Delete(int orderId);
        void ConfirmOrder(int orderId);
        IEnumerable<Orders> GetAllConfirmedOrders();
        IEnumerable<Orders> GetAllUnConfirmedOrders();
        IEnumerable<Orders> GetMyOrders(string userId);


    }
}
