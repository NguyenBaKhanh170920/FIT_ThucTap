using BasketAPI.Applications.Database;
using BasketAPI.Applications.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasketAPI.Applications.Repositories
{
    public class BasketRepository : IBasketRepositories
    {
        private readonly BasketAPIDbContext _context;
        private readonly ILogger<BasketRepository> _logger;
        public BasketRepository(BasketAPIDbContext context, ILogger<BasketRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddNewBasket(Baskets basket)
        {
            try
            {
                var rs = await _context.AddAsync(basket);
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

        public async Task<Baskets> GetBasketByCustomerId(int customerId)
        {
            try
            {
                var rs = await _context.Baskets.FirstOrDefaultAsync(x => x.CustomerId == customerId);
                if (rs != null)
                {
                    await _context.Entry(rs).Collection(i => i.BasketItems).LoadAsync();
                }
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null; ;
            }
        }

        public async Task<bool> UpdateBasket(Baskets basket)
        {
            try
            {
                var rs = _context.Update(basket);
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
