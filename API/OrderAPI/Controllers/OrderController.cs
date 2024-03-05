using Microsoft.AspNetCore.Mvc;
using OrderAPI.Applications.Services.OrderServices;
using OrderAPI.DTOs;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService service)
        {
            _orderService = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderByCustomerId(int CustomerId)
        {
            var rs = await _orderService.GetOrdersByCustomerId(CustomerId);
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderAddDTO order)
        {
            var rs = await _orderService.AddOrders(order);
            return Ok(rs);
        }
    }
}
