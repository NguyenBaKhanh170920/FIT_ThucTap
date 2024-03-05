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
    }
}
