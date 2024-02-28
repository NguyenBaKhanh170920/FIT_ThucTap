using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Services.BasketServices;

namespace WebApplication1.Controllers
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
        [HttpGet]
        public async Task<IActionResult> GetBasketByCustomerId(int id)
        {
            var rs = await _basketService.GetBasketByCustomerId(id);
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int CustomerId, int ProductID, int Quantity)
        {
            var rs = await _basketService.AddBasket(CustomerId, ProductID, Quantity);
            return Ok(rs);
        }
    }
}
