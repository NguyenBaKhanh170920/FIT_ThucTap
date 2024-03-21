using Confluent.Kafka;
using Manonero.MessageBus.Kafka.Abstractions;
using OrderAPI.Applications.Entities;
using OrderAPI.Applications.Repositories.OrderRepositories;
using OrderAPI.Applications.Services.CustomerServices;
using OrderAPI.DTOs;
using System.Text.Json;

namespace OrderAPI.Applications.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ICustomerService customerService;
        public readonly IKafkaProducerManager _producerManager;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository, IConfiguration configuration
            , HttpClient httpClient, ICustomerService customerService, IKafkaProducerManager kafkaProducerManager,
            ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _configuration = configuration;
            _httpClient = httpClient;
            this.customerService = customerService;
            _producerManager = kafkaProducerManager;
            _logger = logger;
        }
        public async Task<Orders> AddOrders(OrderAddDTO orderAddDTO)
        {
            string apiGetBasket = _configuration["HttpGetBasket"] + "/" + orderAddDTO.CustomerId;
            string apiDeleteBasket = _configuration["HttpDeleteBasket"] + "/" + orderAddDTO.CustomerId;
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            responseMessage = await _httpClient.GetAsync(apiGetBasket);
            var baskets = await responseMessage.Content.ReadFromJsonAsync<BasketDTO>();
            if (await CheckProductQuantity(baskets))
            {
                var rs = await _orderRepository.AddOrders(orderAddDTO, baskets);
                ProduceOrderEvent(rs);
                if (rs != null)
                {
                    //for (int i = 0; i < baskets.BasketItems.Count(); i++)
                    //{
                    //    string apiUpdateQuantity = _configuration["HttpProduct"] + "/UpdateProductAfterOrder/" +
                    //        baskets.BasketItems[i].ProductId;
                    //    var data = new ProductAvailableQuantityDTO
                    //    {
                    //        ProductId = baskets.BasketItems[i].ProductId,
                    //        AvailableQuantity = baskets.BasketItems[i].Quantity,
                    //    };
                    //    string jsonData = JsonSerializer.Serialize(data);
                    //    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    //    _httpClient.PatchAsync(apiUpdateQuantity, content);
                    //}
                    await _httpClient.DeleteAsync(apiDeleteBasket);
                }
                return rs;
            }
            return null;
        }

        public async Task<List<Orders>> GetOrdersByCustomerId(int customerId)
        {
            return await _orderRepository.GetOrdersByCustomerId(customerId);
        }

        public async Task<bool> UpdateProductName(int id, string productName)
        {
            return await _orderRepository.UpdateProductName(id, productName);
        }
        private void ProduceOrderEvent(Orders orderResult)
        {
            var json = JsonSerializer.Serialize(orderResult);
            var message = new Message<string, string>
            {
                Key = orderResult.Id.ToString(),
                Value = json
            };
            var kafkaProducer = _producerManager.GetProducer<string, string>("Order");
            kafkaProducer.Produce(message);
            _logger.LogInformation($"Received message: {message}");
        }
        private async Task<bool> CheckProductQuantity(BasketDTO basket)
        {
            for (int i = 0; i < basket.BasketItems.Count(); i++)
            {
                string apiProduct = _configuration["HttpProduct"] + "/GetProductById/" + basket.BasketItems[i].ProductId;
                HttpResponseMessage responseMessage = new HttpResponseMessage();
                responseMessage = await _httpClient.GetAsync(apiProduct);
                var product = await responseMessage.Content.ReadFromJsonAsync<ProductDTO>();
                if (product != null)
                {
                    if (product.AvailableQuantity < basket.BasketItems[i].Quantity)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public async Task<bool> UpdateOrderStreet(string street, int id)
        {
            var orders = await GetOrdersById(id);
            orders.Street = street;
            var rs = await _orderRepository.UpdateOrder(orders);
            if (rs != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Orders> GetOrdersById(int id)
        {
            return await _orderRepository.GetOrderById(id);
        }
    }
}
