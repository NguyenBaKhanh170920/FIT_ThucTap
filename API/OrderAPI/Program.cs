using OrderAPI;
using OrderAPI.Applications.Database;
using OrderAPI.Applications.Repositories.CustomerRepositories;
using OrderAPI.Applications.Repositories.OrderRepositories;
using OrderAPI.Applications.Services.CustomerServices;
using OrderAPI.Applications.Services.OrderServices;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var appSetting = AppSetting.MapValue(builder.Configuration);
var ProduceId1 = builder.Configuration.GetSection("ProducerSettings:0:Id").Value;
var CosumerId = builder.Configuration.GetSection("ConsumerSettings:0:Id").Value;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddOracle<OrderAPIDbContext>(configuration.GetConnectionString("OracleConnection"));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddKafkaProducers(producerBuilder =>
{
    producerBuilder.AddProducer(appSetting.GetProducerSetting(ProduceId1));
});
builder.Services.AddKafkaConsumers(ConsumerBuilder =>
{
    ConsumerBuilder.AddConsumer<KafkaConsumerTask>(appSetting.GetConsumerSetting(CosumerId));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseKafkaMessageBus(messageBus =>
{
    messageBus.RunConsumerAsync(CosumerId);
});

app.Run();
