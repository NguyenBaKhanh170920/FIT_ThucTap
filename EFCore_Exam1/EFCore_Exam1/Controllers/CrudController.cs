using EFCore_Exam1.Models;
using EFCore_Exam1.Repositories.ProductRepository;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_Exam1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CrudController : ControllerBase
    {
        private IProductRepository _productRepository;
        public CrudController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEfCore(int? CategoryId)
        {
            var rs = await _productRepository.GetAllEfCore(CategoryId);
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEfCore(int? Id)
        {
            var rs = await _productRepository.DeleteProductEfCore(Id);
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> AddEfCore(Product product)
        {
            var rs = await _productRepository.CreateProductEfCore(product);
            return Ok(rs);
        }
    }
}
