using GraduateProject.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void DeleteOrder(Guid id);
        Order GetOrder(Guid id);
        IEnumerable<Order> GetOrders();
        void UpdateOrder(Order order);
    }
}
