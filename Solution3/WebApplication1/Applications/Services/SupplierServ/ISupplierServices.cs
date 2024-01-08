using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Services.SupplierServ
{
    public interface ISupplierServices
    {
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(Supplier supplier);
        Task<Supplier> DeleteSupplier(int id);
        Task<List<Supplier>> GetSupplier();
    }
}
