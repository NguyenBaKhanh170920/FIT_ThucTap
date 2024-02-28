using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories.CustomerRepositories;

namespace WebApplication1.Applications.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;
        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Customers> AddCustomers(Customers customers)
        {
            return await repository.AddCustomers(customers);
        }

        public async Task<Customers> DeleteCustomer(int id)
        {
            return await repository.DeleteCustomer(id);
        }

        public async Task<List<Customers>> GetAllCustomers()
        {
            return await repository.GetAllCustomers();
        }
    }
}
