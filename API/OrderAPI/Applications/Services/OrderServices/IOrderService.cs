using OrderAPI.Applications.Entities;
using OrderAPI.DTOs;

namespace OrderAPI.Applications.Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<Orders>> GetOrdersByCustomerId(int customerId);
        Task<Orders> AddOrders(OrderAddDTO orderAddDTO);
    }
}
