using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Services.ProductServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var rs = await _productService.GetAllProductsAsync();
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateProductName(int id, string name)
        {
            var rs = await _productService.UpdateProductName(id, name);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateProductPrice(int id, int price)
        {
            var rs = await _productService.UpdateProductPrice(id, price);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateProductQuantity(int id, int quantity)
        {
            var rs = await _productService.UpdateProductQuantity(id, quantity);
            return Ok(rs);
        }
    }
}
