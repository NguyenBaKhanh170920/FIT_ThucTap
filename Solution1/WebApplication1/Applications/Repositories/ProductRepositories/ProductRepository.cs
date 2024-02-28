using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Bai4DbContext _context;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(Bai4DbContext context, ILogger<ProductRepository> logger)
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
