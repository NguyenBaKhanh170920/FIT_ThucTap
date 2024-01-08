using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories.SupplierRepo;

namespace WebApplication1.Applications.Services.SupplierServ
{
    public class SupplierServices : ISupplierServices
    {
        private readonly ISuppierRepository _repository;
        private readonly ILogger<SupplierServices> _logger;
        public SupplierServices(ISuppierRepository repository, ILogger<SupplierServices> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            try
            {
                return await _repository.AddSupplier(supplier);
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
                return await _repository.DeleteSupplier(id);
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
                return await _repository.GetSupplier();
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
                return await _repository.UpdateSupplier(supplier);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
