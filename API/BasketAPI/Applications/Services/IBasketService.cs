using BasketAPI.Applications.Entities;

namespace BasketAPI.Applications.Services
{
    public interface IBasketService
    {
        Task<Baskets> GetBasketsByCustomerId(int customerId);
        Task<Baskets> AddBaskets(int customerId, int ProductID, int Quantity);
    }
}
