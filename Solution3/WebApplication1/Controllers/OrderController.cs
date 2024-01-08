using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.OrderServ;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _services;
        public OrderController(IOrderServices services)
        {
            _services = services;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateOrderDate(int id, DateTime date)
        {
            var rs = await _services.UpdateOrderDate(id, date);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderDeliveryDate(int id, DateTime date)
        {
            var rs = await _services.UpdateOrderDeliveryDate(id, date);
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(Order orde)
        {
            var rs = await _services.AddOrders(orde);
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var rs = await _services.DeleteOrders(id);
            return Ok(rs);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var rs = await _services.GetAllOrders();
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderStatus(int id, int status)
        {
            var rs = await _services.UpdateOrderStatus(id, status);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderTotalPrice(int id, int price)
        {
            var rs = await _services.UpdateOrderTotalPrice(id, price);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderSale(int id, int sale)
        {
            var rs = await _services.UpdateOrderSale(id, sale);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderPaid(int id, int paid)
        {
            var rs = await _services.UpdateOrderPaid(id, paid);
            return Ok(rs);
        }
    }
}
