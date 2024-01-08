using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories.BasketIteRepositories;

namespace WebApplication1.Applications.Services.BasketItemService
{
    public class BasketItemServices : IBasketItemServices
    {
        private readonly IBasketItemRepositories _repository;
        public BasketItemServices(IBasketItemRepositories repository)
        {
            _repository = repository;
        }

        public async Task<BasketItems> AddBasket(BasketItems item)
        {
            return await _repository.AddBasket(item);
        }

        public async Task<List<BasketItems>> GetBasketItems()
        {
            return await _repository.GetBasketItems();
        }

        public async Task<BasketItems> UpdateBasket(int BasketId, int ProductId, int Quantity)
        {
            return await _repository.UpdateBasket(BasketId, ProductId, Quantity);
        }
    }
}
