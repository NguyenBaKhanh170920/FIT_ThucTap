using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories;

namespace WebApplication1.Applications.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductServices> _logger;
        public ProductServices(IProductRepository repository, ILogger<ProductServices> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                return await _repository.AddProduct(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Product> DeleteProduct(int id)
        {
            try
            {
                return await _repository.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                return await _repository.GetAllProducts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _repository.GetProductById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Product> UpdateCost(int id, int cost)
        {
            try
            {
                return await _repository.UpdateCost(id, cost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Product> UpdateInventory(int id, int inventory)
        {
            try
            {
                return await _repository.UpdateInventory(id, inventory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {

            throw new NotImplementedException();
        }

        public async Task<Product> UpdateRentailPrice(int id, int RentaiPrice)
        {
            try
            {
                return await _repository.UpdateRentailPrice(id, RentaiPrice);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Product> UpdateStatus(int id, int status)
        {
            try
            {
                return await _repository.UpdateStatus(id, status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
