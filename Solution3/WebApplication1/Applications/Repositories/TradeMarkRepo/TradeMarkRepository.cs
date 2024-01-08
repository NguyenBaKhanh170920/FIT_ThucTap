using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.TradeMarkRepo
{
    public class TradeMarkRepository : ITradeMarkRepository
    {
        private readonly Bai1DbContext _dbContext;
        private readonly ILogger<TradeMarkRepository> _logger;

        public TradeMarkRepository(Bai1DbContext dbContext, ILogger<TradeMarkRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<TradeMark> AddTradeMark(TradeMark tradeMark)
        {
            try
            {
                var rs = _dbContext.Add(tradeMark);
                _dbContext.SaveChanges();
                return tradeMark;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<TradeMark> DeleteTradeMark(int id)
        {
            try
            {
                TradeMark tm = _dbContext.TradeMarks.FirstOrDefault(x => x.TradeMarkId == id);
                if (tm != null)
                {
                    var rs = _dbContext.Remove(tm);
                    _dbContext.SaveChanges();
                    return tm;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<TradeMark>> GetAllTradeMark()
        {
            try
            {
                var rs = _dbContext.TradeMarks.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<TradeMark> UpdateTradeMark(TradeMark tradeMark)
        {
            try
            {
                var rs = _dbContext.Update(tradeMark);
                _dbContext.SaveChanges();
                return tradeMark;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
