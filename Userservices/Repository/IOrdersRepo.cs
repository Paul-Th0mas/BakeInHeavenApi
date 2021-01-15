using Dataservices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Userservices.Repository
{
    public interface IOrdersRepo
    {
        bool SaveChanges();
        IEnumerable<Orders> GetAllOrders();
        Orders GetOrdersById(int id);
        void CreateOrder(Orders Order);
        void UpdateOrder(Orders Order);
        void DeleteOrder(Orders Order);
    }
}
