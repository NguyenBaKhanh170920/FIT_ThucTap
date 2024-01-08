using WebApplication1.Applications.Repositories.OrderRepo;

namespace WebApplication1.Applications.Services.OrderServ
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<OrderServices> _logger;
        public OrderServices(IOrderRepository repository, ILogger<OrderServices> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Entities.Order> AddOrders(Entities.Order orders)
        {
            try
            {
                return await _repository.AddOrders(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> DeleteOrders(int id)
        {
            try
            {
                return await _repository.DeleteOrders(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Entities.Order>> GetAllOrders()
        {
            try
            {
                return await _repository.GetAllOrders();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderDate(int OrderCode, DateTime date)
        {
            try
            {
                return await _repository.UpdateOrderDate(OrderCode, date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderDeliveryDate(int OrderCode, DateTime date)
        {
            try
            {
                return await _repository.UpdateOrderDeliveryDate(OrderCode, date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderPaid(int OrderCode, int id)
        {
            try
            {
                return await _repository.UpdateOrderPaid(OrderCode, id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderSale(int OrderCode, int sale)
        {
            try
            {
                return await _repository.UpdateOrderSale(OrderCode, sale);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderStatus(int OrderCode, int status)
        {
            try
            {
                return await _repository.UpdateOrderStatus(OrderCode, status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Entities.Order> UpdateOrderTotalPrice(int OrderCode, int price)
        {
            try
            {
                return await _repository.UpdateOrderTotalPrice(OrderCode, price);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
