using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly IStudentService _service;
        public TestController(IStudentService service)
        {
            _service = service;
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
    }
}
