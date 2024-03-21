using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTOs;
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
        [Route("{id}")]
        public async Task<IActionResult> UpdateProductQuantity(int id, ProductAvailableQuantityDTO quantity)
        {
            var rs = await _productService.UpdateProductQuantity(id, quantity.AvailableQuantity);
            return Ok(rs);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var rs = await _productService.GetProductById(id);
            return Ok(rs);
        }
        [HttpPatch]
        [Route("{productId}")]
        public async Task<IActionResult> UpdateProductAfterOrder(int productId, ProductAvailableQuantityDTO quantity)
        {
            var rs = await _productService.UpdateProductQuantityAfterOrder(productId, quantity.AvailableQuantity);
            if (rs)
            {
                return Ok(rs);
            }
            return BadRequest("Fail");
        }
    }
}
