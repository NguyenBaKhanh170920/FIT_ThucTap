using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.SupplierServ;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierServices _services;
        public SupplierController(ISupplierServices services)
        {
            _services = services;
        }
        [HttpPost]
        public async Task<IActionResult> AddSupllier(Supplier supplier)
        {
            var rs = await _services.AddSupplier(supplier);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
        {
            var rs = await _services.GetSupplier();
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSupplier(Supplier supplier)
        {
            var rs = await _services.UpdateSupplier(supplier);
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var rs = await _services.DeleteSupplier(id);
            return Ok(rs);
        }
        [HttpPost]
        public IEnumerable Test()
        {
            return new string[] { "value1", "2" };
        }
    }
}
