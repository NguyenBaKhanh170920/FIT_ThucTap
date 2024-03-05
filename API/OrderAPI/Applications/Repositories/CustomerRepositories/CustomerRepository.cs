using Microsoft.EntityFrameworkCore;
using OrderAPI.Applications.Database;
using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Repositories.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrderAPIDbContext _context;
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(OrderAPIDbContext context, ILogger<CustomerRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Customers> AddCustomer(Customers customer)
        {
            try
            {
                var rs = await _context.AddAsync(customer);
                if (rs != null)
                {
                    await _context.SaveChangesAsync();
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

        public async Task<Customers> GetCustomerById(int id)
        {
            try
            {
                var rs = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Customers>> GetCustomersAsync()
        {
            try
            {
                var rs = await _context.Customers.ToListAsync();
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
