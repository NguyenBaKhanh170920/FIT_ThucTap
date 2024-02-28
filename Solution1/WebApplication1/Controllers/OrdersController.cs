using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Services.OrderServices;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> AddOrders(OrderAddDTO orderAddDTO)
        {
            var rs = await _orderService.AddOrders(orderAddDTO);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderByCustomerId(int id)
        {
            var rs = await _orderService.GetOrdersByCustomerId(id);
            return Ok(rs);
        }
    }
}
