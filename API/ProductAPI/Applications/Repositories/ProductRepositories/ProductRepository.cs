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
                Product pro1 = new Product(1, "San Pham", 100, 100);
                Product pro2 = new Product(2, "San Pham", 100, 100);
                Product pro3 = new Product(3, "San Pham", 100, 100);
                Product pro4 = new Product(4, "San Pham", 100, 100);
                Product pro5 = new Product(5, "San Pham", 100, 100);
                List<Product> products = new List<Product>();
                products.Add(pro1);
                products.Add(pro2);
                products.Add(pro3);
                products.Add(pro4);
                products.Add(pro5);
                _context.Products.AddRangeAsync(products);
                _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateProductQuantityAfterOrder(int productId, int quantity)
        {
            try
            {
                Product product = await GetProductById(productId);
                product.AvailableQuantity -= quantity;
                if (product.AvailableQuantity < 0)
                {
                    return false;
                }
                var rs = _context.Products.Update(product);
                if (rs != null)
                {
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
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
