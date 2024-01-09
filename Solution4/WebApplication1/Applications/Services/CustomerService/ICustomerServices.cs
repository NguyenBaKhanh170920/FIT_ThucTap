using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Services.CustomerService
{
    public interface ICustomerServices
    {
        Task<Customers> AddCustomer(Customers customer);
        Task<List<Customers>> GetAllCustomer();
    }
}
