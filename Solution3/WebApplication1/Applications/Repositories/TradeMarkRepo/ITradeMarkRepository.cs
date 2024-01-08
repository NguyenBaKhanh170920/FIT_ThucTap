using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.TradeMarkRepo
{
    public interface ITradeMarkRepository
    {
        Task<List<TradeMark>> GetAllTradeMark();
        Task<TradeMark> AddTradeMark(TradeMark tradeMark);
        Task<TradeMark> DeleteTradeMark(int id);
        Task<TradeMark> UpdateTradeMark(TradeMark tradeMark);

    }
}
