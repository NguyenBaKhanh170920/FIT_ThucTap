using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories.BasketRepositories;

namespace WebApplication1.Applications.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository repository;
        public BasketService(IBasketRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Baskets> AddBasket(int CustomerId, int ProductID, int Quantity)
        {
            return await repository.AddBasket(CustomerId, ProductID, Quantity);
        }

        public async Task<Baskets> GetBasketByCustomerId(int customerId)
        {
            return await repository.GetBasketByCustomerId(customerId);
        }

        public async Task<BasketItems> UpdateBasketItemQuantity(int id, int productId, int quantity)
        {
            return await repository.UpdateBasketItemQuantity(id, productId, quantity);
        }
    }
}
