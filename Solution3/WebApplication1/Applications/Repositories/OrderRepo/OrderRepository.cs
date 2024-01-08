using WebApplication1.Applications.Database;

namespace WebApplication1.Applications.Repositories.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Bai1DbContext _dbContext;
        private readonly ILogger<OrderRepository> _logger;
        public OrderRepository(Bai1DbContext dbContext, ILogger<OrderRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Entities.Order> AddOrders(Entities.Order orde)
        {
            var ord = _dbContext.Add(orde);
            await _dbContext.SaveChangesAsync();
            return orde;

        }

        public async Task<Entities.Order> DeleteOrders(int id)
        {
            Entities.Order ord = _dbContext.Orders.FirstOrDefault(x => x.OrderCode == id);
            if (ord != null)
            {
                var rs = _dbContext.Remove(ord);
                await _dbContext.SaveChangesAsync();
                return ord;
            }
            return null;
        }

        public async Task<List<Entities.Order>> GetAllOrders()
        {
            try
            {
                var rs = _dbContext.Orders.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderDate(int OrderCode, DateTime date)
        {
            try
            {
                Entities.Order ord = _dbContext.Orders.FirstOrDefault(x => x.OrderCode == OrderCode);
                if (ord != null && DateTime.Compare(date, DateTime.Now) <= 1)
                {
                    ord.OrderDate = date;
                    await _dbContext.SaveChangesAsync();
                    return ord;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderDeliveryDate(int OrderCode, DateTime date)
        {
            try
            {
                Entities.Order ord = _dbContext.Orders.FirstOrDefault(x => x.OrderCode == OrderCode);
                if (ord != null)
                {
                    ord.DeliveryDate = date;
                    await _dbContext.SaveChangesAsync();
                    return ord;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderPaid(int OrderCode, int paid)
        {
            try
            {
                Entities.Order ord = _dbContext.Orders.FirstOrDefault(x => x.OrderCode == OrderCode);
                if (ord != null)
                {
                    ord.Paid = paid;
                    await _dbContext.SaveChangesAsync();
                    return ord;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderSale(int OrderCode, int sale)
        {
            try
            {
                Entities.Order ord = _dbContext.Orders.FirstOrDefault(x => x.OrderCode == OrderCode);
                if (ord != null)
                {
                    ord.Sale = sale;
                    await _dbContext.SaveChangesAsync();
                    return ord;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderStatus(int OrderCode, int status)
        {
            try
            {
                Entities.Order ord = _dbContext.Orders.FirstOrDefault(x => x.OrderCode == OrderCode);
                if (ord != null)
                {
                    ord.Status = status;
                    await _dbContext.SaveChangesAsync();
                    return ord;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderTotalPrice(int OrderCode, int price)
        {
            try
            {
                Entities.Order ord = _dbContext.Orders.FirstOrDefault(x => x.OrderCode == OrderCode);
                if (ord != null)
                {
                    ord.TotalPrice = price;
                    await _dbContext.SaveChangesAsync();
                    return ord;
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
