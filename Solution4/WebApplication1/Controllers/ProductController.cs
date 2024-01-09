using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.ProductService;

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
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var rs = await _services.GetAllProducts();
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> AddProduct(Products products)
        {
            var rs = await _services.AddProduct(products);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateProductQuantity(int id, int quantity)
        {
            var rs = await _services.UpdateProductQuantity(id, quantity);
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> GetProductById(int id)
        {
            var rs = await _services.GetProductsByProductId(id);
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(int id, IFormFile file)
        {
            var rs = await _services.UpdateProductImage(id, file);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> DisplayProductImage(int id)
        {
            var rs = await _services.GetProductsByProductId(id);
            if (rs != null)
            {
                Byte[] b = System.IO.File.ReadAllBytes(rs.Image);
                return File(b, "Image/png");
            }
            return BadRequest("no");
        }
    }
}
