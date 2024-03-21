using BasketAPI.Applications.Entities;
using BasketAPI.DTOs;

namespace BasketAPI.Applications.Services
{
    public interface IBasketService
    {
        Task<Baskets> GetBasketsByCustomerId(int customerId);
        Task<UpsertBasket> AddBaskets(int customerId, int ProductID, int Quantity);
        Task<bool> DeleteBasket(int customerId);
    }
}
