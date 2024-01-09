using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories.CustomersRepositories;

namespace WebApplication1.Applications.Services.CustomerService
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customers> AddCustomer(Customers customer)
        {
            return await _customerRepository.AddCustomer(customer);
        }

        public async Task<List<Customers>> GetAllCustomer()
        {
            return await _customerRepository.GetAllCustomer();
        }
    }
}
