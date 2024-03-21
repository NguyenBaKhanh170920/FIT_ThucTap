using BasketAPI.Applications.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int CustomerId, int ProductID, int Quantity)
        {
            var rs = await _basketService.AddBaskets(CustomerId, ProductID, Quantity);
            return Ok(rs);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBasketByCustomerId(int id)
        {
            var rs = await _basketService.GetBasketsByCustomerId(id);
            return Ok(rs);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBaskets(int id)
        {
            var rs = await _basketService.DeleteBasket(id);
            return Ok(rs);
        }
    }
}
