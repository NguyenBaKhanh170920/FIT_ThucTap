using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories.TradeMarkRepo;

namespace WebApplication1.Applications.Services.TradeMarkServ
{
    public class TradeMarkServices : ITradeMarkServices
    {
        private readonly ITradeMarkRepository _tradeMarkRepository;
        private readonly ILogger<TradeMarkServices> _logger;
        public TradeMarkServices(ITradeMarkRepository tradeMarkRepository, ILogger<TradeMarkServices> logger)
        {
            _tradeMarkRepository = tradeMarkRepository;
            _logger = logger;
        }

        public async Task<TradeMark> AddTradeMark(TradeMark tradeMark)
        {
            try
            {
                return await _tradeMarkRepository.AddTradeMark(tradeMark);
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
                return await _tradeMarkRepository.DeleteTradeMark(id);
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
                return await _tradeMarkRepository.GetAllTradeMark();
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
                return await _tradeMarkRepository.UpdateTradeMark(tradeMark);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
