using Microsoft.EntityFrameworkCore;
using OrderAPI.Applications.Database;
using OrderAPI.Applications.Entities;
using OrderAPI.Applications.Repositories.Interface;

namespace OrderAPI.Applications.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ExamDbContext _context;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(ExamDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Products> AddProduct(Products products)
        {
            try
            {
                products.Id = Guid.NewGuid().ToString();
                var rs = await _context.AddAsync(products);
                if (rs != null)
                {
                    await _context.SaveChangesAsync();
                    return products;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Products>> GetAllProducts()
        {
            try
            {
                var rs = await _context.Products.ToListAsync();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Products> GetProductById(string productId)
        {
            try
            {
                var rs = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
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

        public async Task<bool> UpdateProductAmount(string productId, int amount)
        {
            try
            {
                var products = await GetProductById(productId);
                if (products != null)
                {
                    if (products.RemainingAmount > amount)
                    {
                        products.RemainingAmount = products.RemainingAmount - amount;
                        var rs = _context.Update(products);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }
    }
}
