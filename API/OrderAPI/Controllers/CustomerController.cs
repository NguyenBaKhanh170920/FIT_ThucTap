using Microsoft.AspNetCore.Mvc;
using OrderAPI.Applications.Entities;
using OrderAPI.Applications.Services.CustomerServices;

namespace OrderAPI.Controllers
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
        public async Task<IActionResult> GetCustomersAsync()
        {
            return Ok(await _customerService.GetCustomersAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customers customers)
        {
            return Ok(await _customerService.AddCustomer(customers));
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(await (_customerService.GetCustomerById(id)));
        }
    }
}
