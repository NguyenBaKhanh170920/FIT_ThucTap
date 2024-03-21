using Confluent.Kafka;
using Manonero.MessageBus.Kafka.Abstractions;
using OrderAPI.Applications.Entities;
using OrderAPI.Applications.Repositories.Interface;
using OrderAPI.Applications.Services.Interface;
using OrderAPI.DTOs;
using System.Text.Json;

namespace OrderAPI.Applications.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        public readonly IKafkaProducerManager _producerManager;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository, IProductService productService, ILogger<OrderService> logger,
            IKafkaProducerManager producerManager)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _logger = logger;
            _producerManager = producerManager;
        }
        public async Task<Orders> AddOrders(string productId, int amount)
        {
            Products products = await _productService.GetProductById(productId);
            if (products == null)
            {
                return null;
            }
            Orders orders = new Orders(productId, amount);
            orders.ErrorCode = 0;
            orders.ErrorMessage = "ok";
            //Gửi một message CheckProductAmount vào topic 'input-topic' để kiểm tra có đủ số lượng sản phẩm hay không
            FCheckProductAmount(orders);
            var rs = await _orderRepository.AddOrder(orders);
            return rs;
        }

        public async Task<List<Orders>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrder();
        }
        public void FCheckProductAmount(Orders orders)
        {
            CheckProductAmount check = new CheckProductAmount()
            {
                RefId = orders.Id,
                BusinessType = 1,
                ProductId = orders.ProductId,
                Amount = orders.Amount,
            };
            var json = JsonSerializer.Serialize(check);
            var message = new Message<string, string>
            {
                Key = orders.Id,
                Value = json
            };
            var kafkaProducer = _producerManager.GetProducer<string, string>("OrderIn");
            kafkaProducer.Produce(message);
            _logger.LogInformation($"Received message: {message}");
        }
        public void FReleaseHoldAmount(Orders orders)
        {
            ReleaseHoldAmount release = new ReleaseHoldAmount()
            {
                RefId = orders.Id,
                BusinessType = 2,
                ProductId = orders.Id,
            };
            var json = JsonSerializer.Serialize(release);
            var message = new Message<string, string>
            {
                Key = orders.Id,
                Value = json
            };
            var kafkaProducer = _producerManager.GetProducer<string, string>("OrderIn");
            kafkaProducer.Produce(message);
            _logger.LogInformation($"Received message: {message}");
        }

        public async Task<Orders> GetOrderById(string id)
        {
            return await _orderRepository.GetOrdersById(id);
        }

        public async Task<bool> OrderAccepted(Orders order)
        {
            order.Status = "Accepted";
            //tru so luong san pham
            var upDate = await _orderRepository.UpdateOrder(order);
            if (upDate)
            {
                var rs = await _productService.UpdateProductAmount(order.ProductId, order.Amount);
                if (rs)
                {
                    FReleaseHoldAmount(order);
                    return true;
                }
            }
            OrderRejected(order, 2, "Lỗi: Không thể thêm order");
            return false;
        }

        public async Task<bool> OrderRejected(Orders order, int errorCode, string errorMessage)
        {
            order.Status = "Rejected";
            order.ErrorMessage = errorMessage;
            order.ErrorCode = errorCode;
            var upDate = await _orderRepository.UpdateOrder(order);
            return true;
        }

        public async Task<bool> RemoveAllOrder()
        {
            return await _orderRepository.RemoveAllOrder();
        }
    }
}
