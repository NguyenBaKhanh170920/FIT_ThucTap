using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Bai4DbContext _dbContext;
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(Bai4DbContext dbContext, ILogger<CustomerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Customers> AddCustomers(Customers customers)
        {
            try
            {
                var rs = await _dbContext.Customers.AddAsync(customers);
                if (rs != null)
                {
                    await _dbContext.SaveChangesAsync();
                    return customers;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Customers> DeleteCustomer(int id)
        {
            try
            {
                Customers customers = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
                if (customers != null)
                {
                    var rs = _dbContext.Remove(customers);
                    if (rs != null)
                    {
                        await _dbContext.SaveChangesAsync();
                        return customers;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Customers>> GetAllCustomers()
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
