using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.BasketIteRepositories
{
    public interface IBasketItemRepositories
    {
        Task<List<BasketItems>> GetBasketItems();
        Task<BasketItems> UpdateBasket(int BasketId, int ProductId, int Quantity);
        Task<BasketItems> AddBasket(BasketItems item);
    }
}
