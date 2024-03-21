using Confluent.Kafka;
using Manonero.MessageBus.Kafka.Abstractions;
using ProductAPI.DTOs;
using System.Text.Json;
using WebApplication1.Applications.Services.ProductServices;

namespace ProductAPI
{
    public class KafkaConsumerTask : IConsumingTask<string, string>
    {
        private readonly ILogger<KafkaConsumerTask> _logger;
        private readonly IServiceProvider _serviceProvider;
        //private readonly IProductService _productService;
        public KafkaConsumerTask(ILogger<KafkaConsumerTask> logger/*, IProductService productService*/, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            // _productService = productService;
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
                var messageValue = JsonSerializer.Deserialize<OrderDTO>(message);
                bool check = true;
                if (messageValue != null)
                {
                    foreach (var value in messageValue.OrderItems)
                    {
                        //lay product ve so sanh
                        var product = await productService.GetProductById(value.ProductId);
                        if (value.Quantity > product.AvailableQuantity)
                        {
                            //kiem tra so luong
                            check = false;
                            break;
                        }
                    }
                    if (check)
                    {
                        foreach (var value in messageValue.OrderItems)
                        {
                            var product = await productService.GetProductById(value.ProductId);
                            //tru so luong
                            productService.UpdateProductQuantityAfterOrder(value.ProductId, value.Quantity);
                        }
                        //gui kafka thanh cong
                        productService.KafkaCheckProductQuantity(messageValue.Id, "ok");
                    }
                    else
                    {
                        //gui kafka tru that bai
                        productService.KafkaCheckProductQuantity(messageValue.Id, "no");
                    }
                }

            }
        }
    }
}
