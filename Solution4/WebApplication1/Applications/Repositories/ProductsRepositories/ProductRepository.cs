using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.ProductsRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Bai2DbContext _dbContext;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(Bai2DbContext dbContext, ILogger<ProductRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Products> AddProduct(Products product)
        {
            try
            {
                var rs = _dbContext.Add(product);
                if (rs != null)
                {
                    await _dbContext.SaveChangesAsync();
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

        public async Task<List<Products>> GetAllProducts()
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

        public async Task<Products> GetProductsByProductId(int id)
        {
            try
            {
                var products = _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
                if (products != null)
                {
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

        public async Task<Products> UpdateProductImage(int id, IFormFile file)
        {
            string name = file.FileName;
            FileInfo fileInfo = new FileInfo(name);
            string ex = fileInfo.Extension;
            string folderPath = "./Image/" + name;
            using (FileStream filestream = System.IO.File.Create(folderPath))
            {
                file.CopyTo(filestream);
                filestream.Flush();
            }
            var products = _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
            if (products != null)
            {
                products.Image = folderPath;
                await _dbContext.SaveChangesAsync();
                return products;
            }
            return null;

        }

        public async Task<Products> UpdateProductQuantity(int id, int quantity)
        {
            try
            {
                Products products = _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
                if (products != null)
                {
                    products.AvailableQuantity = quantity;
                    await _dbContext.SaveChangesAsync();
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
    }
}
