using GraduateProject.Domain.Core;
using GraduateProject.Domain.Interfaces;
using GraduateProject.Services.Interfaces;

namespace GraduateProject.Infrastructure.Business
{
    public class OrderService : IOrder
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void TakeBook(Guid bookId, Guid userId)
        {
            var order = new Order
            {
                Book = new Book { Id = bookId },
                User = new User { Id = userId }
            };
            _orderRepository.CreateOrder(order);
        }

    }
}
