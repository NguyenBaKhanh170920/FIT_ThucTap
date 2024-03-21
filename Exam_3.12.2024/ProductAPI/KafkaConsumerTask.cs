using Confluent.Kafka;
using Manonero.MessageBus.Kafka.Abstractions;
using ProductAPI.Applications.Services.Interfaces;
using ProductAPI.DTOs;
using ProductAPI.Models;
using System.Text.Json;

namespace ProductAPI
{
    public class KafkaConsumerTask : IConsumingTask<string, string>
    {
        private readonly ILogger<KafkaConsumerTask> _logger;
        private readonly IServiceProvider _serviceProvider;
        public KafkaConsumerTask(ILogger<KafkaConsumerTask> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task ExecuteAsync(ConsumeResult<string, string> result)
        {
            try
            {
                var message = result.Message.Value;
                Check(message);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Task.CompletedTask;
            }
        }
        private async void Check(string message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
                var messageValue = JsonSerializer.Deserialize<CheckProductAmount>(message);
                Products products = await productService.GetProductById(messageValue.ProductId);
                if (products != null)
                {
                    string status = "error";
                    if (products.RemainingAmount > messageValue.Amount)
                    {
                        status = "ok";
                    }
                    productService.FOutPutMessageValue(messageValue, status);
                }
            }
        }
    }
}
