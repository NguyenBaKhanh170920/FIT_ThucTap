using Confluent.Kafka;
using Manonero.MessageBus.Kafka.Abstractions;
using ProductAPI.Applications.Repositories.Interface;
using ProductAPI.Applications.Services.Interfaces;
using ProductAPI.DTOs;
using ProductAPI.Models;
using System.Text.Json;

namespace ProductAPI.Applications.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public readonly IKafkaProducerManager _producerManager;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository repository, IKafkaProducerManager producerManager,
            ILogger<ProductService> logger)
        {
            _repository = repository;
            _producerManager = producerManager;
            _logger = logger;
        }
        public async Task<Products> AddProduct(Products products)
        {
            return await _repository.AddProduct(products);
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await _repository.GetAllProducts();
        }

        public async Task<Products> GetProductById(string productId)
        {
            return await _repository.GetProductById(productId);
        }

        public async Task<bool> UpdateProductAmount(string productId, int amount)
        {
            return await (_repository.UpdateProductAmount(productId, amount));
        }
        public async Task<bool> FOutPutMessageValue(CheckProductAmount amount, string status)
        {
            OutPutMessageValue output = new OutPutMessageValue()
            {
                RefId = amount.RefId,
                BusinessType = amount.BusinessType,
                ErrorCode = 0,
                ErrorMessage = "",
                ProductId = amount.ProductId
            };
            if (status == "error")
            {
                output.ErrorCode = 1;
                output.ErrorMessage = "Không đủ sản phẩm";
            }
            var json = JsonSerializer.Serialize(output);
            var message = new Message<string, string>
            {
                Key = amount.RefId,
                Value = json
            };
            var kafkaProducer = _producerManager.GetProducer<string, string>("OrderOut");
            kafkaProducer.Produce(message);
            _logger.LogInformation($"Received message: {message}");
            return true;
        }
    }
}
