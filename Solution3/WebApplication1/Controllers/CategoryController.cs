using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.CategoryServ;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;
        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }
        [HttpPost]
        public async Task<IActionResult> Addcategory(Category category)
        {
            var rs = await _services.AddCategory(category);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var rs = await _services.GetAllCategory();
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var rs = await _services.DeleteCategory(id);
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var rs = await _services.UpdateCategory(category);
            return Ok(rs);
        }
    }
}
