using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task<List<Customers>> GetCustomersAsync();
        Task<Customers> AddCustomer(Customers customer);
        Task<Customers> GetCustomerById(int id);
    }
}
