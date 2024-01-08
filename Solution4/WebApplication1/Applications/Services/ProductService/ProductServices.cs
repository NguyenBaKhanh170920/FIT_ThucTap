using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories.ProductsRepositories;

namespace WebApplication1.Applications.Services.ProductService
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productsRepository;
        private readonly ILogger<ProductServices> _logger;
        public ProductServices(IProductRepository productsRepository, ILogger<ProductServices> logger)
        {
            _productsRepository = productsRepository;
            this._logger = logger;
        }
        public async Task<Products> AddProduct(Products product)
        {
            return await _productsRepository.AddProduct(product);
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await _productsRepository.GetAllProducts();
        }

        public async Task<Products> GetProductsByProductId(int id)
        {
            return await _productsRepository.GetProductsByProductId(id);
        }

        public async Task<Products> UpdateProductImage(int id, IFormFile file)
        {
            return await _productsRepository.UpdateProductImage(id, file);
        }

        public async Task<Products> UpdateProductQuantity(int id, int quantity)
        {
            return await (_productsRepository.UpdateProductQuantity(id, quantity));
        }
    }
}
