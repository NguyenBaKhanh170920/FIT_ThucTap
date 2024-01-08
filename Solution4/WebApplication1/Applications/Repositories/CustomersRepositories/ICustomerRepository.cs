using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.CustomersRepositories
{
    public interface ICustomerRepository
    {
        Task<Customers> AddCustomer(Customers customer);
        Task<List<Customers>> GetAllCustomer();
    }
}
