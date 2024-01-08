using WebApplication1.Applications.Repositories.OrderDetailRepo;

namespace WebApplication1.Applications.Services.OrderDetailServ
{
    public class OrderDetailServices : IOrderDetailServices
    {
        private readonly IOrderDetailRespository _repository;
        private readonly ILogger<OrderDetailServices> _logger;
        public OrderDetailServices(IOrderDetailRespository repository, ILogger<OrderDetailServices> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Entities.OrderDetail> AddOrderDetail(Entities.OrderDetail orderDetail)
        {
            try
            {
                return await _repository.AddOrderDetail(orderDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.OrderDetail> DeleteOrderDetail(int id)
        {
            try
            {
                return await _repository.DeleteOrderDetail(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Entities.OrderDetail>> GetOrderDeatilByOrderId(int id)
        {
            try
            {
                return await _repository.GetOrderDeatilByOrderId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.OrderDetail> UpdateOrderDetailDate(int id, DateTime date)
        {
            try
            {
                return await _repository.UpdateOrderDetailDate(id, date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.OrderDetail> UpdateOrderDetailNumberProduct(int id, int NumberProduct)
        {
            try
            {
                return await _repository.UpdateOrderDetailNumberProduct(id, NumberProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.OrderDetail> UpdateOrderDetailSale(int id, int sale)
        {
            try
            {
                return await _repository.UpdateOrderDetailSale(id, sale);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.OrderDetail> UpdateOrderDetailTotalPrice(int id, int price)
        {
            try
            {
                return await _repository.UpdateOrderDetailTotalPrice(id, price);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
