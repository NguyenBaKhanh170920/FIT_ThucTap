using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.OrderRepositories
{
    public class OrderRepository : IOrderRepository

    {
        private readonly Bai2DbContext _dbContext;
        private readonly ILogger<OrderRepository> _logger;
        public OrderRepository(Bai2DbContext dbContext, ILogger<OrderRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Orders> AddOrder(Orders order)
        {
            var rs = _dbContext.Add(order);
            List<BasketItems> list = _dbContext.BasketItems.ToList();
            foreach (var item in list)
            {
                OrderItems orderItems = new OrderItems();
                orderItems.ProductId = item.ProductId;
                orderItems.Quantity = item.Quantity;
                orderItems.ProductName = item.ProductName;
                _dbContext.Add(orderItems);
                _dbContext.Remove(item);
            }
            if (rs != null)
            {
                await _dbContext.SaveChangesAsync();
                return order;
            }
            return null;
        }

        public async Task<List<Orders>> GetAllOrder()
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

        public async Task<List<OrderItems>> GetOrderItems()
        {
            try
            {
                var rs = _dbContext.OrderItems.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
