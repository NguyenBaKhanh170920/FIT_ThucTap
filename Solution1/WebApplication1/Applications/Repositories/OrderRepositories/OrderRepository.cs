using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;
using WebApplication1.DTO;

namespace WebApplication1.Applications.Repositories.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Bai4DbContext _dbContext;
        private readonly ILogger<OrderRepository> _logger;
        public OrderRepository(Bai4DbContext dbContext, ILogger<OrderRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Orders> AddOrders(OrderAddDTO orderAddDTO)
        {
            try
            {
                Customers customers = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == orderAddDTO.CustomerId);
                var baskets = await _dbContext.Baskets.FirstOrDefaultAsync(x => x.CustomerId == orderAddDTO.CustomerId);
                List<int> list = new List<int>();
                if (baskets != null)
                {
                    await _dbContext.Entry(baskets).Collection(i => i.BasketItems).LoadAsync();
                }
                Orders orders = new Orders();
                orders.OrderDate = DateTime.Now;
                orders.CustomerId = orderAddDTO.CustomerId;
                orders.Street = orderAddDTO.Street;
                orders.City = orderAddDTO.City;
                orders.District = orderAddDTO.District;
                orders.AdditionalAddress = orderAddDTO.AdditionalAddress;
                foreach (var items in baskets.BasketItems)
                {
                    orders.OrderItems.Add(new OrderItems()
                    {
                        ProductName = items.ProductName,
                        ProductId = items.ProductId,
                        Quantity = items.Quantity,
                    });
                }
                var rs = await _dbContext.Orders.AddAsync(orders);
                if (rs != null)
                {
                    await _dbContext.SaveChangesAsync();
                    return orders;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Orders>> GetOrdersByCustomerId(int customerId)
        {
            try
            {
                var rs = await _dbContext.Orders.Where(x => x.CustomerId == customerId).ToListAsync();
                if (rs != null)
                {
                    foreach (var item in rs)
                    {
                        await _dbContext.Entry(item).Collection(i => i.OrderItems).LoadAsync();
                    }
                }
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
