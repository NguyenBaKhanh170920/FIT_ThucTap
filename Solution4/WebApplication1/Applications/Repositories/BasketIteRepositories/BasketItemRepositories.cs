using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.BasketIteRepositories
{
    public class BasketItemRepositories : IBasketItemRepositories
    {
        private readonly Bai2DbContext _dbContext;
        private readonly ILogger<BasketItemRepositories> _logger;
        public BasketItemRepositories(Bai2DbContext dbContext, ILogger<BasketItemRepositories> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<BasketItems> AddBasket(BasketItems item)
        {
            try
            {
                var rs = _dbContext.Add(item);
                if (rs != null)
                {
                    await _dbContext.SaveChangesAsync();
                    return item;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<BasketItems>> GetBasketItems()
        {
            try
            {
                var rs = _dbContext.BasketItems.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<BasketItems> UpdateBasket(int BasketId, int ProductId, int Quantity)
        {
            try
            {
                BasketItems bs = _dbContext.BasketItems.FirstOrDefault(x => x.Id == BasketId && x.ProductId == ProductId);
                if (bs != null)
                {
                    bs.Quantity = Quantity;
                    await _dbContext.SaveChangesAsync();
                    return bs;
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
