using Microsoft.AspNetCore.Mvc;
using OrderAPI.Applications.Services.Interface;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(string productId, int amount)
        {
            var rs = await _orderService.AddOrders(productId, amount);
            if (rs != null)
            {
                return Ok(rs);

            }
            return NotFound("Sản phẩm không tồn tại");
        }
        [HttpGet]
        public async Task<IActionResult> GettAllOrder()
        {
            return Ok(await _orderService.GetAllOrders());
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAll()
        {
            return Ok(await _orderService.RemoveAllOrder());
        }
    }
}
