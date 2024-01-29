using EFCore_Exam1.Models;
using EFCore_Exam1.Repositories.ProductRepository;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_Exam1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class StoredProcedureController : ControllerBase
    {
        private IProductRepository _productRepository;
        public StoredProcedureController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int? CategoryId)
        {
            var rs = await _productRepository.GetAll(CategoryId);
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int? Id)
        {
            var rs = await _productRepository.DeleteProduct(Id);
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> Add(Product product)
        {
            var rs = await _productRepository.CreateProduct(product);
            return Ok(rs);
        }
    }
}
