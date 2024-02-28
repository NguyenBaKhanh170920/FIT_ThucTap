using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.CustomerServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var rs = await _customerService.GetAllCustomers();
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customers customers)
        {
            var rs = await _customerService.AddCustomers(customers);
            return Ok(rs);
        }
    }
}
