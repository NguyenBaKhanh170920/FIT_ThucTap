using EFCore_Exam1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Exam1.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EFCore_Exam1Context _con;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(EFCore_Exam1Context con, ILogger<ProductRepository> logger)
        {
            _con = con;
            _logger = logger;
        }
        public object[] SetParameter(Product product)
        {
            object[] param =
            {
                new SqlParameter("@Id",product.Id),
                new SqlParameter("@Name",product.Name),
                new SqlParameter("@Price",product.Price),
                new SqlParameter("@Status",product.Status),
                new SqlParameter("@CategoryId",product.CategoryId),
                new SqlParameter("@CreateDate",product.CreateDate),
            };
            return param;

        }

        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                var rs = await _con.Database.ExecuteSqlRawAsync("Sp_insertProduct @Name,@Price,@Status,@CategoryId,@CreateDate", SetParameter(product));
                if (rs == 0)
                {
                    return null;
                }
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }

        }

        public async Task<Product> DeleteProduct(int? Id)
        {
            var product = _con.Products.FirstOrDefault(x => x.Id == Id);
            try
            {
                var param = new SqlParameter("@Id", DBNull.Value);
                if (product == null)
                {
                    int rs = await _con.Database.ExecuteSqlRawAsync("Sp_deleteProduct @Id", param);
                    return null;
                }
                else
                {
                    param = new SqlParameter("@Id", Id);
                    int rs = await _con.Database.ExecuteSqlRawAsync("Sp_deleteProduct @Id", param);
                    if (rs == 0)
                    {
                        return null;
                    }
                    return product;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Product>> GetAll(int? CategoryId)
        {
            var param = new SqlParameter("@CategoryId", DBNull.Value);
            if (CategoryId.HasValue)
            {
                param = new SqlParameter("@CategoryId", CategoryId);
            }
            return await _con.Set<Product>().FromSqlRaw("Sp_getallproduct @CategoryId", param).ToListAsync();

        }

        public async Task<List<Product>> GetAllEfCore(int? CategoryId)
        {
            try
            {
                if (CategoryId.HasValue)
                {
                    var rs = await _con.Products.Where(x => x.CategoryId == CategoryId).ToListAsync();
                    return rs;
                }
                else
                {
                    var rs = await _con.Products.ToListAsync();
                    return rs;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Product> DeleteProductEfCore(int? Id)
        {
            try
            {
                if (Id.HasValue)
                {
                    var product = await _con.Products.FirstOrDefaultAsync(x => x.Id == Id);
                    var rs = _con.Products.Remove(product);
                    _con.SaveChangesAsync();
                    return product;
                }
                else
                {
                    var row = from x in _con.Products select x;
                    foreach (var x in row)
                    {
                        _con.Products.Remove(x);
                    }
                    _con.SaveChangesAsync();
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Product> CreateProductEfCore(Product product)
        {
            try
            {
                var rs = await _con.AddAsync(product);
                _con.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
