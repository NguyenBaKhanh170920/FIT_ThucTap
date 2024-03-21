using Microsoft.AspNetCore.Mvc;
using OrderAPI.Applications.Entities;
using OrderAPI.Applications.Services.Interface;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var rs = await _service.GetAllProducts();
            if (rs != null)
            {
                return Ok(rs);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var rs = await _service.GetProductById(id);
            if (rs != null)
            {
                return Ok(rs);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Products products)
        {
            var rs = await _service.AddProduct(products);
            if (rs != null)
            {
                return Ok(rs);
            }
            return BadRequest("Fail");
        }
    }
}
