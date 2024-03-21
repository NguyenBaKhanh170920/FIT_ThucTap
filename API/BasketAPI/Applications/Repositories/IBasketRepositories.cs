using BasketAPI.Applications.Entities;

namespace BasketAPI.Applications.Repositories
{
    public interface IBasketRepositories
    {
        Task<Baskets> GetBasketByCustomerId(int customerId);
        Task<bool> AddNewBasket(Baskets basket);
        Task<bool> UpdateBasket(Baskets basket);
        Task<bool> DeleteBasket(int customerId);
        Task<bool> DeleteProductFromBasket(int productId, int customerId);

    }
}
