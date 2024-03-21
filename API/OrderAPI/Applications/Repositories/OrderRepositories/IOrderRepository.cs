using OrderAPI.Applications.Entities;
using OrderAPI.DTOs;

namespace OrderAPI.Applications.Repositories.OrderRepositories
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetOrdersByCustomerId(int customerId);
        Task<Orders> GetOrderById(int id);
        Task<Orders> AddOrders(OrderAddDTO orderAddDTO, BasketDTO baskets);
        Task<bool> UpdateProductName(int id, string productName);
        Task<bool> UpdateOrder(Orders orders);
    }
}
