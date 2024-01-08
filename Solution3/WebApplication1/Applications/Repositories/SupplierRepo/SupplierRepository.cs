using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.SupplierRepo
{
    public class SupplierRepository : ISuppierRepository
    {
        private readonly Bai1DbContext _dbContext;
        private readonly ILogger<SupplierRepository> _logger;
        public SupplierRepository(Bai1DbContext dbContext, ILogger<SupplierRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            try
            {
                var rs = _dbContext.Add(supplier);
                _dbContext.SaveChanges();
                return supplier;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Supplier> DeleteSupplier(int id)
        {
            try
            {
                Supplier sup = _dbContext.Suppliers.FirstOrDefault(x => x.SupplierCode == id);
                if (sup != null)
                {
                    var rs = _dbContext.Remove(_dbContext.Suppliers.FirstOrDefault(x => x.SupplierCode == id));
                    _dbContext.SaveChanges();
                    return sup;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Supplier>> GetSupplier()
        {
            try
            {
                var rs = _dbContext.Suppliers.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            try
            {
                var rs = _dbContext.Update(supplier);
                await _dbContext.SaveChangesAsync();
                return supplier;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
