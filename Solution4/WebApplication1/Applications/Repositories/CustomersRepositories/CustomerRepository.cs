using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.CustomersRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Bai2DbContext _dbContext;
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(Bai2DbContext dbContext, ILogger<CustomerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Customers> AddCustomer(Customers customer)
        {
            try
            {
                var rs = _dbContext.Add(customer);
                if (rs != null)
                {
                    await _dbContext.SaveChangesAsync();
                    return customer;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Customers>> GetAllCustomer()
        {
            try
            {
                var rs = _dbContext.Customers.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
