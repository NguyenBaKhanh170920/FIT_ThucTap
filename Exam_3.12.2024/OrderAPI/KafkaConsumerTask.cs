using Confluent.Kafka;
using Manonero.MessageBus.Kafka.Abstractions;
using OrderAPI.Applications.Services.Interface;
using OrderAPI.DTOs;
using System.Text.Json;

namespace OrderAPI
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
                //Console.WriteLine(message);
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
                var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
                var messageValue = JsonSerializer.Deserialize<OutputMessageValue>(message);
                var orders = await orderService.GetOrderById(messageValue.RefId);
                if (orders != null)
                {
                    //order ton tai
                    if (messageValue.ErrorCode == 0)
                    {
                        orderService.OrderAccepted(orders);
                    }
                    else
                    {
                        orderService.OrderRejected(orders, messageValue.ErrorCode, messageValue.ErrorMessage);
                    }
                }
            }
        }
    }
}
