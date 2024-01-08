using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var rs = await _services.AddProduct(product);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var rs = await _services.GetAllProducts();
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var rs = await _services.DeleteProduct(id);
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> GetProductById(int id)
        {
            var rs = await _services.GetProductById(id);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateCost(int id, int cost)
        {
            var rs = await _services.UpdateCost(id, cost);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateInventory(int id, int inventory)
        {
            var rs = await _services.UpdateInventory(id, inventory);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateRentailPrice(int id, int RentailPrice)
        {
            var rs = await _services.UpdateRentailPrice(id, RentailPrice);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateStatus(int id, int status)
        {
            var rs = await _services.UpdateStatus(id, status);
            return Ok(rs);
        }
    }
}
