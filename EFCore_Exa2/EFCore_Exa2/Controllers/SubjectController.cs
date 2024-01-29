using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.Applications.Services.SubjectServices;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_Exa2.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSubject()
        {
            var rs = await _subjectService.GetAllSubject();
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> AddSubject(int id, string name, bool status)
        {
            Subject subject = new Subject(id, name, status);
            var rs = await _subjectService.AddSubject(subject);
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var rs = await _subjectService.DeleteSubject(id);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateSubject(int id, string name, bool status)
        {
            Subject subject = new Subject(id, name, status);
            var rs = await _subjectService.UpdateSubject(subject);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var rs = await _subjectService.GetSubjectById(id);
            return Ok(rs);
        }
    }
}
