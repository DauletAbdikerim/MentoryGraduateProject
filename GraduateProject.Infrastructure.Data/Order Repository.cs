using GraduateProject.Domain.Core;
using GraduateProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Infrastructure.Data
{
    public class Order_Repository : IOrderRepository
    {
        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
