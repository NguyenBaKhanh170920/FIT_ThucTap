using Microsoft.EntityFrameworkCore;
using OrderAPI.Applications.Database;
using OrderAPI.Applications.Entities;
using OrderAPI.Applications.Repositories.Interface;
using OrderAPI.Applications.Services.Interface;

namespace OrderAPI.Applications.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ExamDbContext _context;
        private readonly ILogger<OrderRepository> _logger;
        private readonly IProductService _productService;
        public OrderRepository(ExamDbContext context, ILogger<OrderRepository> logger, IProductService productService)
        {
            _context = context;
            _logger = logger;
            _productService = productService;
        }

        public async Task<Orders> AddOrder(Orders orders)
        {
            try
            {
                var rs = await _context.AddAsync(orders);
                await _context.SaveChangesAsync();
                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Orders>> GetAllOrder()
        {
            try
            {
                var rs = await _context.Orders.ToListAsync();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Orders> GetOrdersById(string id)
        {
            try
            {
                var rs = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
                if (rs == null)
                {
                    return null;
                }
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<bool> RemoveAllOrder()
        {
            try
            {
                var list = await GetAllOrder();
                foreach (var item in list)
                {
                    _context.Remove(item);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }

        public async Task<bool> UpdateOrder(Orders orders)
        {
            try
            {
                var rs = _context.Update(orders);
                if (rs != null)
                {
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }
    }
}
