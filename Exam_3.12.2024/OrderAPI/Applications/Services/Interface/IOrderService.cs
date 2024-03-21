using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Services.Interface
{
    public interface IOrderService
    {
        Task<Orders> AddOrders(string productId, int amount);
        Task<List<Orders>> GetAllOrders();
        Task<Orders> GetOrderById(string id);
        Task<bool> OrderAccepted(Orders order);
        Task<bool> OrderRejected(Orders order, int errorCode, string errorMessage);
        Task<bool> RemoveAllOrder();
    }
}
