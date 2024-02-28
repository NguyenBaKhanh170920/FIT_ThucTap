using WebApplication1.Applications.Entities;
using WebApplication1.DTO;

namespace WebApplication1.Applications.Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<Orders>> GetOrdersByCustomerId(int customerId);
        Task<Orders> AddOrders(OrderAddDTO orderAddDTO);
    }
}
