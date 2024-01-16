using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services;
using WebApplication1.StudentMemories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly StudentMemory _memory;
        private readonly StudentDbContext _context;

        public TestController(IStudentService service, StudentDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        //[Route("/Student2")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _service.GetAllStudent();
            return Ok(result);
        }
        [HttpPost]
        //[Route("/Student2")]
        public async Task<IActionResult> AddTest(int id, DateTime date, Boolean tf)
        {

            Test ts = new Test()
            {
                Id = id,
                date = date,
                tf = tf
            };
            StudentController stu = new StudentController(_service);
            var old = await _service.GetStudentById(id);

            return Ok(old);
        }
        [HttpGet]
        public async Task<IActionResult> GetTest()
        {

            return Ok("ok");

        }
    }
}
