using Confluent.Kafka;
using Manonero.MessageBus.Kafka.Abstractions;
using ProductAPI.Applications.Entities;
using ProductAPI.DTOs;
using System.Text;
using System.Text.Json;
using WebApplication1.Applications.Repositories.ProductRepositories;

namespace WebApplication1.Applications.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public readonly IKafkaProducerManager _producerManager;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository productRepository, IConfiguration configuration, HttpClient httpClient, IKafkaProducerManager
            producerManager, ILogger<ProductService> logger)
        {
            this.productRepository = productRepository;
            _configuration = configuration;
            _httpClient = httpClient;
            _producerManager = producerManager;
            _logger = logger;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            //ProduceBasketEvent(await productRepository.GetProductById(id));
            return await productRepository.GetProductById(id);
        }

        public async Task<UpsertProduct> UpdateProductName(int id, string name)
        {
            UpsertProduct upsertProduct = new UpsertProduct();
            HttpResponseMessage response = new HttpResponseMessage();
            string apiUpdateName = _configuration["HttpUpdateProductName"] + "/" + id;
            var data = new OrderProductName
            {
                Id = id,
                ProductName = name,
            };
            string jsonData = JsonSerializer.Serialize(data);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            _httpClient.PatchAsync(apiUpdateName, content);
            upsertProduct.Message = "Doi ten thanh cong";
            upsertProduct.Data = await productRepository.UpdateProductName(id, name);
            return upsertProduct;
        }

        public async Task<Product> UpdateProductPrice(int id, int price)
        {
            return await productRepository.UpdateProductPrice(id, price);
        }

        public async Task<Product> UpdateProductQuantity(int id, int quantity)
        {
            return await productRepository.UpdateProductQuantity(id, quantity);
        }

        public async Task<bool> UpdateProductQuantityAfterOrder(int productId, int quantity)
        {
            return await productRepository.UpdateProductQuantityAfterOrder(productId, quantity);
        }
        private void ProduceBasketEvent(Product orderResult)
        {
            var json = JsonSerializer.Serialize(orderResult);
            var message = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = json
            };

            var kafkaProducer = _producerManager.GetProducer<string, string>("Product");
            kafkaProducer.Produce(message);
            _logger.LogInformation($"Received message: {message}");
        }

        public Task<bool> KafkaCheckProductQuantity(int OrderId, string value)
        {
            var message = new Message<string, string>
            {
                Key = OrderId.ToString(),
                Value = value
            };
            var kafkaProducer = _producerManager.GetProducer<string, string>("Product");
            kafkaProducer.Produce(message);
            _logger.LogInformation($"Received message: {message}");
            return Task.FromResult(true);
        }
    }
}
