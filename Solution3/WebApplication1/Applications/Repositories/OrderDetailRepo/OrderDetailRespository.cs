using WebApplication1.Applications.Database;

namespace WebApplication1.Applications.Repositories.OrderDetailRepo
{
    public class OrderDetailRespository : IOrderDetailRespository
    {
        private readonly Bai1DbContext _db;
        private readonly ILogger<OrderDetailRespository> _logger;
        public OrderDetailRespository(Bai1DbContext db, ILogger<OrderDetailRespository> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<Entities.OrderDetail> AddOrderDetail(Entities.OrderDetail orderDetail)
        {
            var ord = _db.Add(orderDetail);
            await _db.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<Entities.OrderDetail> DeleteOrderDetail(int id)
        {
            try
            {
                Entities.OrderDetail orderDetail = _db.OrderDetails.FirstOrDefault(x => x.OrderDetailId == id);
                if (orderDetail != null)
                {
                    _db.Remove(orderDetail);
                    await _db.SaveChangesAsync();
                    return orderDetail;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Entities.OrderDetail>> GetOrderDeatilByOrderId(int id)
        {
            try
            {
                var orderDetail = _db.OrderDetails.Where(x => x.OrderCode == id).ToList();
                return orderDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }

        }

        public async Task<Entities.OrderDetail> UpdateOrderDetailDate(int id, DateTime date)
        {
            try
            {
                Entities.OrderDetail orderDetail = _db.OrderDetails.FirstOrDefault(x => x.OrderDetailId == id);
                if (orderDetail != null)
                {
                    orderDetail.OrderDate = date;
                    await _db.SaveChangesAsync();
                    return orderDetail;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }

        }

        public async Task<Entities.OrderDetail> UpdateOrderDetailNumberProduct(int id, int NumberProduct)
        {
            try
            {
                Entities.OrderDetail orderDetail = _db.OrderDetails.FirstOrDefault(x => x.OrderDetailId == id);
                if (orderDetail != null)
                {
                    orderDetail.NumberProduct = NumberProduct;
                    await _db.SaveChangesAsync();
                    return orderDetail;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }

        }

        public async Task<Entities.OrderDetail> UpdateOrderDetailSale(int id, int sale)
        {
            try
            {
                Entities.OrderDetail orderDetail = _db.OrderDetails.FirstOrDefault(x => x.OrderDetailId == id);
                if (orderDetail != null)
                {
                    orderDetail.Sale = sale;
                    await _db.SaveChangesAsync();
                    return orderDetail;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.OrderDetail> UpdateOrderDetailTotalPrice(int id, int price)
        {
            try
            {
                Entities.OrderDetail orderDetail = _db.OrderDetails.FirstOrDefault(x => x.OrderDetailId == id);
                if (orderDetail != null)
                {
                    orderDetail.TotalPrice = price;
                    await _db.SaveChangesAsync();
                    return orderDetail;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
