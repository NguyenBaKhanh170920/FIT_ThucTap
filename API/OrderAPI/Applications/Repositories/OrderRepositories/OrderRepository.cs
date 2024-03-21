using Microsoft.EntityFrameworkCore;
using OrderAPI.Applications.Database;
using OrderAPI.Applications.Entities;
using OrderAPI.DTOs;

namespace OrderAPI.Applications.Repositories.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderAPIDbContext _context;
        private readonly ILogger<OrderRepository> _logger;
        public OrderRepository(OrderAPIDbContext context, ILogger<OrderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Orders> AddOrders(OrderAddDTO orderAddDTO, BasketDTO baskets)
        {
            try
            {
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
                var rs = await _context.Orders.AddAsync(orders);
                if (rs != null)
                {
                    await _context.SaveChangesAsync();
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

        public async Task<Orders> GetOrderById(int id)
        {
            try
            {
                var rs = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
                return rs;
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
                var rs = await _context.Orders.Where(x => x.CustomerId == customerId).ToListAsync();
                if (rs != null)
                {
                    foreach (var item in rs)
                    {
                        await _context.Entry(item).Collection(i => i.OrderItems).LoadAsync();
                    }
                    return rs;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
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

        public async Task<bool> UpdateProductName(int id, string productName)
        {
            try
            {
                var orderItems = await _context.OrderItems.ToListAsync();
                if (orderItems != null)
                {
                    foreach (var item in orderItems)
                    {
                        if (item.ProductId == id)
                        {
                            item.ProductName = productName;
                            _context.OrderItems.Update(item);
                        }
                    }
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
