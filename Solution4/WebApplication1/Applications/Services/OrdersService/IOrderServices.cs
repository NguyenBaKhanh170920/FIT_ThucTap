using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Services.OrdersService
{
    public interface IOrderServices
    {
        Task<List<Orders>> GetAllOrder();
        Task<Orders> AddOrder(Orders order);
        Task<List<OrderItems>> GetOrderItems();

    }
}
