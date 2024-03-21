using OrderAPI.Applications.Entities;
using OrderAPI.Applications.Repositories.Interface;
using OrderAPI.Applications.Services.Interface;

namespace OrderAPI.Applications.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Products> AddProduct(Products products)
        {
            return await _repository.AddProduct(products);
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await _repository.GetAllProducts();
        }

        public async Task<Products> GetProductById(string productId)
        {
            return await _repository.GetProductById(productId);
        }

        public async Task<bool> UpdateProductAmount(string productId, int amount)
        {
            return await (_repository.UpdateProductAmount(productId, amount));
        }
    }
}
