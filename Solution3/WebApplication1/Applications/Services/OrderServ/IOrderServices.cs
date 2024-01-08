using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Services.OrderServ
{
    public interface IOrderServices
    {
        Task<Order> UpdateOrderDate(int OrderCode, DateTime date);
        Task<Order> UpdateOrderDeliveryDate(int OrderCode, DateTime date);
        Task<Entities.Order> UpdateOrderPaid(int OrderCode, int id);
        Task<Entities.Order> UpdateOrderStatus(int OrderCode, int status);
        Task<Entities.Order> UpdateOrderTotalPrice(int OrderCode, int price);
        Task<Entities.Order> UpdateOrderSale(int OrderCode, int sale);
        Task<Entities.Order> AddOrders(Entities.Order orders);
        Task<Entities.Order> DeleteOrders(int id);
        Task<List<Entities.Order>> GetAllOrders();
    }
}
