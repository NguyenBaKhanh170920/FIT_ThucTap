using Microsoft.EntityFrameworkCore;
using ProductAPI.Applications.Database;
using ProductAPI.Applications.Entities;

namespace WebApplication1.Applications.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductApiDbContext _context;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(ProductApiDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
            if (!_context.Products.Any())
            {
                Product pro = new Product(10, "San Pham", 100, 100);
                _context.Products.AddAsync(pro);
                _context.SaveChangesAsync();
            }
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                var products = _context.Products.ToList();
                return products;
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
                var rs = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (rs != null)
                {
                    return rs;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Product> UpdateProductName(int id, string name)
        {
            try
            {
                Product products = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (products != null)
                {
                    products.Name = name;
                    var rs = _context.Products.Update(products);
                    if (rs != null)
                    {
                        await _context.SaveChangesAsync();
                        return products;
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

        public async Task<Product> UpdateProductPrice(int id, int price)
        {
            try
            {
                Product products = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (products != null)
                {
                    products.Price = price;
                    var rs = _context.Products.Update(products);
                    if (rs != null)
                    {
                        await _context.SaveChangesAsync();
                        return products;
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

        public async Task<Product> UpdateProductQuantity(int id, int quantity)
        {
            try
            {
                Product products = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (products != null)
                {
                    products.AvailableQuantity = quantity;
                    var rs = _context.Products.Update(products);
                    if (rs != null)
                    {
                        await _context.SaveChangesAsync();
                        return products;
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
    }
}
