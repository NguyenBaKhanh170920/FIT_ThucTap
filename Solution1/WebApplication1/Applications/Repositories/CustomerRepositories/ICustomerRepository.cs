using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.CustomerRepositories
{
    public interface ICustomerRepository
    {
        Task<List<Customers>> GetAllCustomers();
        Task<Customers> AddCustomers(Customers customers);
        Task<Customers> DeleteCustomer(int id);

    }
}
