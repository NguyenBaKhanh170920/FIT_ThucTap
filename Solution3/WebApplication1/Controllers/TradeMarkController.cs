using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.TradeMarkServ;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class TradeMarkController : ControllerBase
    {
        private readonly ITradeMarkServices _service;
        public TradeMarkController(ITradeMarkServices service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddTradeMark(TradeMark tradeMark)
        {
            var rs = await _service.AddTradeMark(tradeMark);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTradeMark()
        {
            var rs = await _service.GetAllTradeMark();
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTradeMark(int id)
        {
            var rs = await _service.DeleteTradeMark(id);
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTradeMark(TradeMark tradeMark)
        {
            var rs = await _service.UpdateTradeMark(tradeMark);
            return Ok(rs);
        }
    }
}
