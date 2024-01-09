using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.BasketItemService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class BasketItemsController : ControllerBase
    {
        private readonly IBasketItemServices _services;
        public BasketItemsController(IBasketItemServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var rs = await _services.GetBasketItems();
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> AddBasket(BasketItems items)
        {
            var rs = await _services.AddBasket(items);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateBasket(int id, int ProductId, int Quantity)
        {
            var rs = await _services.UpdateBasket(id, ProductId, Quantity);
            if (rs != null)
            {
                return Ok(rs);
            }
            return BadRequest("No basket or products");
        }

    }
}

