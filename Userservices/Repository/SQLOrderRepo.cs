using Dataservices;
using Dataservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Userservices.Repository
{
    public class SQLOrderRepo : IOrdersRepo
    {
        private readonly Bakers_DBcontext _context;
        public SQLOrderRepo(Bakers_DBcontext context)
        {
            _context = context;
        }
        public void CreateOrder(Orders Order)
        {
            if (Order == null)
            {
                throw new ArgumentNullException(nameof(Order));
            }
            _context.orders.Add(Order);
        }

        public void DeleteOrder(Orders Order)
        {
            if (Order == null)
            {
                throw new ArgumentNullException(nameof(Order));
            }
            _context.orders.Remove(Order);
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            return _context.orders.ToList();
        }

        public Orders GetOrdersById(int id)
        {
            return _context.orders.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateOrder(Orders Order)
        {
            
        }
    }
}
