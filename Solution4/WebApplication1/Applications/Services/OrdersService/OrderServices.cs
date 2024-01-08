using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories.OrderRepositories;

namespace WebApplication1.Applications.Services.OrdersService
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Orders> AddOrder(Orders order)
        {
            return await _orderRepository.AddOrder(order);
        }

        public async Task<List<Orders>> GetAllOrder()
        {
            return await _orderRepository.GetAllOrder();
        }

        public async Task<List<OrderItems>> GetOrderItems()
        {
            return await _orderRepository.GetOrderItems();
        }
    }
}
