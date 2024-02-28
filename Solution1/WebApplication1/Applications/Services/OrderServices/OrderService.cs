using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories.OrderRepositories;
using WebApplication1.DTO;

namespace WebApplication1.Applications.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Orders> AddOrders(OrderAddDTO orderAddDTO)
        {
            return await _orderRepository.AddOrders(orderAddDTO);
        }
        public async Task<List<Orders>> GetOrdersByCustomerId(int customerId)
        {
            return await _orderRepository.GetOrdersByCustomerId(customerId);
        }
    }
}
