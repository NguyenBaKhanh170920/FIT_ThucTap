using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.OrderRepositories
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetAllOrder();
        Task<Orders> AddOrder(Orders order);
        Task<List<OrderItems>> GetOrderItems();
    }
}
