using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Services.TradeMarkServ
{
    public interface ITradeMarkServices
    {
        Task<List<TradeMark>> GetAllTradeMark();
        Task<TradeMark> AddTradeMark(TradeMark tradeMark);
        Task<TradeMark> DeleteTradeMark(int id);
        Task<TradeMark> UpdateTradeMark(TradeMark tradeMark);
    }
}
