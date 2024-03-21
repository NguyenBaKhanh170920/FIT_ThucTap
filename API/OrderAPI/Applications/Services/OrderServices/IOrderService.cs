using OrderAPI.Applications.Entities;
using OrderAPI.DTOs;

namespace OrderAPI.Applications.Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<Orders>> GetOrdersByCustomerId(int customerId);
        Task<Orders> GetOrdersById(int id);
        Task<Orders> AddOrders(OrderAddDTO orderAddDTO);
        Task<bool> UpdateProductName(int id, string productName);
        Task<bool> UpdateOrderStreet(string street, int id);
    }
}
