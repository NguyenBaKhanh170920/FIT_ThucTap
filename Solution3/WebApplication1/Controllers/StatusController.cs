using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.StatusServ;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusServices _statusService;
        public StatusController(IStatusServices statusService)
        {
            _statusService = statusService;
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var rs = await _statusService.DeleteStatus(id);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStatus()
        {
            var rs = await _statusService.GetAllStatus();
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> AddStatus(Status status)
        {
            var rs = await _statusService.AddStatus(status);
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStatus(Status status)
        {
            var rs = await _statusService.UpdateStatus(status);
            return Ok(rs);
        }
    }
}
