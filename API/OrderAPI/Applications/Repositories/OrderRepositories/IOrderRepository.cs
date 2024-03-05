using OrderAPI.Applications.Entities;
using OrderAPI.DTOs;

namespace OrderAPI.Applications.Repositories.OrderRepositories
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetOrdersByCustomerId(int customerId);
        Task<Orders> AddOrders(OrderAddDTO orderAddDTO, BasketDTO baskets);
    }
}
