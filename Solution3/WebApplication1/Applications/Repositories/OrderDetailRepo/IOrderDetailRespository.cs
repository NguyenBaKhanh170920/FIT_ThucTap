namespace WebApplication1.Applications.Repositories.OrderDetailRepo
{
    public interface IOrderDetailRespository
    {
        Task<List<Entities.OrderDetail>> GetOrderDeatilByOrderId(int id);
        Task<Entities.OrderDetail> AddOrderDetail(Entities.OrderDetail orderDetail);
        Task<Entities.OrderDetail> DeleteOrderDetail(int id);
        Task<Entities.OrderDetail> UpdateOrderDetailNumberProduct(int id, int NumberProduct);
        Task<Entities.OrderDetail> UpdateOrderDetailTotalPrice(int id, int price);
        Task<Entities.OrderDetail> UpdateOrderDetailSale(int id, int sale);
        Task<Entities.OrderDetail> UpdateOrderDetailDate(int id, DateTime date);

    }
}
