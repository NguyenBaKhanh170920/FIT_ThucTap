using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.OrderDetailServ;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailServices _services;
        public OrderDetailController(IOrderDetailServices services)
        {
            _services = services;
        }
        [HttpPost]
        public async Task<IActionResult> AddOrderDetail(OrderDetail orderDetail)
        {
            var rs = await _services.AddOrderDetail(orderDetail);
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> GetOrderDetailByOrderId(int OrderId)
        {
            var rs = await _services.GetOrderDeatilByOrderId(OrderId);
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var rs = await _services.DeleteOrderDetail(id);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderDetailDate(int Id, DateTime date)
        {
            var rs = await _services.UpdateOrderDetailDate(Id, date);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderDetailNumberProduct(int Id, int NumberProduct)
        {
            var rs = await _services.UpdateOrderDetailNumberProduct(Id, NumberProduct);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderDetailTotalPrice(int Id, int price)
        {
            var rs = await _services.UpdateOrderDetailTotalPrice(Id, price);
            return Ok(rs);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderDetailSale(int Id, int sale)
        {
            var rs = await _services.UpdateOrderDetailSale(Id, sale);
            return Ok(rs);
        }
    }
}
