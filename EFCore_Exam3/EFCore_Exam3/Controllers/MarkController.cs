using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.Applications.Services.MarkServices;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_Exa2.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class MarkController : ControllerBase
    {
        private readonly IMarkService _markService;
        public MarkController(IMarkService markService)
        {
            _markService = markService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMark()
        {
            var rs = await _markService.GetAllMark();
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> AddMark(int id, int StudentId, int SubjectId, string Scores, DateTime time)
        {
            Mark mark = new Mark(id, StudentId, SubjectId, Scores, time);
            var rs = await _markService.AddMark(mark);
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMark(int id)
        {
            var rs = await _markService.DeleteMark(id);
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMark(int id, int StudentId, int SubjectId, string Scores, DateTime time)
        {
            Mark mark = new Mark(id, StudentId, SubjectId, Scores, time);
            var rs = await _markService.UpdateMark(mark);
            return Ok(rs);
        }
    }
}
