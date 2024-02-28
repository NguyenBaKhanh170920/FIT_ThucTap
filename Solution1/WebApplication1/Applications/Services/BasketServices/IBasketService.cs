using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Services.BasketServices
{
    public interface IBasketService
    {
        Task<Baskets> GetBasketByCustomerId(int customerId);
        Task<BasketItems> UpdateBasketItemQuantity(int id, int productId, int quantity);
        Task<Baskets> AddBasket(int CustomerId, int ProductID, int Quantity);
    }
}
