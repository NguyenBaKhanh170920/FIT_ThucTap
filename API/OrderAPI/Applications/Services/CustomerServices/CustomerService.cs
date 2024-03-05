using OrderAPI.Applications.Entities;
using OrderAPI.Applications.Repositories.CustomerRepositories;

namespace OrderAPI.Applications.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Customers> AddCustomer(Customers customer)
        {
            return await _repository.AddCustomer(customer);
        }

        public async Task<Customers> GetCustomerById(int id)
        {
            return await _repository.GetCustomerById(id);
        }

        public async Task<List<Customers>> GetCustomersAsync()
        {
            return await _repository.GetCustomersAsync();
        }
    }
}
