using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Bai1DbContext _dbContext;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(Bai1DbContext dbContext, ILogger<ProductRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                var rs = _dbContext.Products.Add(product);
                if (rs != null)
                {
                    _dbContext.SaveChanges();
                    return product;
                }
                return null;
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
                var product = _dbContext.Products.FirstOrDefault(x => x.ProductCode == id);
                if (product != null)
                {
                    var rs = _dbContext.Remove(product);
                    if (rs != null)
                    {
                        _dbContext.SaveChanges();
                        return product;
                    }

                }
                return null;
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
                var rs = _dbContext.Products.ToList();
                return rs;
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
                var product = _dbContext.Products.FirstOrDefault(x => x.ProductCode == id);
                if (product != null)
                {
                    return product;
                }
                return null;
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
                Product product = _dbContext.Products.FirstOrDefault(x => x.ProductCode == id);
                if (product != null)
                {
                    product.Cost = cost;
                    _dbContext.SaveChanges();
                    return product;
                }
                return null;
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
                Product product = _dbContext.Products.FirstOrDefault(x => x.ProductCode == id);
                if (product != null)
                {
                    product.Inventory = inventory;
                    _dbContext.SaveChanges();
                    return product;
                }
                return null;
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
                Product product = _dbContext.Products.FirstOrDefault(x => x.ProductCode == id);
                if (product != null)
                {
                    product.RentailPrice = RentaiPrice;
                    _dbContext.SaveChanges();
                    return product;
                }
                return null;
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
                Product product = _dbContext.Products.FirstOrDefault(x => x.ProductCode == id);
                if (product != null)
                {
                    product.Status = status;
                    _dbContext.SaveChanges();
                    return product;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
