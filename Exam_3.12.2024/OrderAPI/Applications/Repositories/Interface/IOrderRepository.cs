using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<Orders> AddOrder(Orders orders);
        Task<List<Orders>> GetAllOrder();
        Task<Orders> GetOrdersById(string id);
        Task<bool> UpdateOrder(Orders orders);
        Task<bool> RemoveAllOrder();
    }
}
