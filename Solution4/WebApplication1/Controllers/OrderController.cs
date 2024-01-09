using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.OrdersService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var rs = await _orderServices.GetAllOrder();
            return Ok(rs);
        }
        [HttpPut]
        public async Task<IActionResult> AddOrder(Orders orders)
        {
            var rs = await _orderServices.AddOrder(orders);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderItem()
        {
            var rs = await _orderServices.GetOrderItems();
            return Ok(rs);
        }
    }
}
