using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task<List<Customers>> GetAllCustomers();
        Task<Customers> AddCustomers(Customers customers);
        Task<Customers> DeleteCustomer(int id);
    }
}
