using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }
        List<int> ListStu = new List<int>() { 1, 2, 3, 4 };

        //[HttpPost]
        //public async Task<IActionResult> Student(Student student, string? act)
        //{
        //    switch (act)
        //    {
        //        case "add":
        //            return Ok((Student?)await _service.Add(student));
        //        case "delete":
        //            return Ok((Student?)await _service.Delete(student));
        //        case "update":
        //            return Ok((Student?)await _service.Update(student));
        //        case "search":
        //            return Ok((Student?)await _service.GetStudentById(student.Id));
        //        default:
        //            var result = await _service.GetAllStudent();
        //            return Ok(result);
        //    }
        //}


        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            var result = await _service.Add(student);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            var result = await _service.Update(student);
            return Ok(result);
        }

        [HttpPost]
        //[Route("/Student2")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _service.GetAllStudent();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _service.Delete(id);
            return Ok(result);
        }

        [HttpPost]
        //[Route("/Student2")]
        public async Task<IActionResult> GetById(int id)
        {

            var result = await _service.GetStudentById(id);
            return Ok(result);
        }
        [HttpPost]
        //[Route("/Student2")]
        public async Task<IActionResult> GetByName(string name)
        {

            var result = await _service.GetStudentsByName(name);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateName(int id, string name)
        {
            var result = await _service.UpdateName(id, name);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Today(bool tf, DateTime dt)
        {
            DateTime thisDate = DateTime.Now;
            if (!tf)
            {
                return Ok("Not OK");
            }
            return Ok(dt);
        }
        [HttpPost("AddMany")]
        public async Task<IActionResult> AddManyStudent(List<Student> student)
        {
            int count = 0;
            foreach (Student stu in student)
            {
                await _service.Add(stu);
                count++;
            }
            return Ok(count);
        }
        [HttpPost("{From?}/{To}/{bet}")]
        public async Task<IActionResult> Test(string From, string? To)
        {
            if (From == "a")
            {
                return BadRequest("Ko hop le");
            }
            List<String> list = new List<String>();
            list.Add(From);
            list.Add(To);
            return Ok(list);
        }

    }
}
