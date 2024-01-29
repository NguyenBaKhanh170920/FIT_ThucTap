using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.Applications.Services.StudentServices;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_Exa2.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(int id, string name, DateTime bthday, int gender, bool status)

        {
            Student student = new Student(id, name, bthday, gender, status);
            var rs = await _studentService.AddStudent(student);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var rs = await _studentService.GetAllStudent();
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var rs = await _studentService.DeleteStudent(id);
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(int id, string name, DateTime bthday, int gender, bool status)

        {
            Student student = new Student(id, name, bthday, gender, status);
            var rs = await _studentService.UpdateStudent(student);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var rs = await _studentService.GetStudentById(id);
            return Ok(rs);
        }
    }
}
