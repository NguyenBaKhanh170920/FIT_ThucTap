using ProductAPI.Applications.Entities;
using WebApplication1.Applications.Repositories.ProductRepositories;

namespace WebApplication1.Applications.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await productRepository.GetProductById(id);
        }

        public async Task<Product> UpdateProductName(int id, string name)
        {
            return await productRepository.UpdateProductName(id, name);
        }

        public async Task<Product> UpdateProductPrice(int id, int price)
        {
            return await productRepository.UpdateProductPrice(id, price);
        }

        public async Task<Product> UpdateProductQuantity(int id, int quantity)
        {
            return await productRepository.UpdateProductQuantity(id, quantity);
        }
    }
}
