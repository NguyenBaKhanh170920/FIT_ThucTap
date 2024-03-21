using Confluent.Kafka;
using Manonero.MessageBus.Kafka.Abstractions;
using OrderAPI.Applications.Services.OrderServices;

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
                var key = int.Parse(result.Message.Key);
                Check(message, key);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Task.CompletedTask;
            }
        }
        public void Check(string message, int key)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
                if (message == "ok")
                {
                    //luu vao order.street
                    orderService.UpdateOrderStreet("Thành công", key);
                }
                else
                {
                    //luu that bai
                    orderService.UpdateOrderStreet("Thất bại", key);
                }
            }
        }
    }
}
