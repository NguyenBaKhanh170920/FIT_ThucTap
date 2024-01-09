using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.CustomerService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _services;
        public CustomerController(ICustomerServices services)
        {
            _services = services;
        }
        [HttpPut]
        public async Task<IActionResult> AddCustomer(Customers customers)
        {
            var rs = await _services.AddCustomer(customers);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var rs = await _services.GetAllCustomer();
            return Ok(rs);
        }
    }
}
