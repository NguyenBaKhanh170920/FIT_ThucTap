using ProductAPI;
using ProductAPI.Applications.Repositories;
using ProductAPI.Applications.Repositories.Interface;
using ProductAPI.Applications.Services;
using ProductAPI.Applications.Services.Interfaces;
using ProductAPI.Models;

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
builder.Services.AddOracle<ModelContext>(configuration.GetConnectionString("OracleConnection"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddKafkaProducers(producerBuilder =>
{
    producerBuilder.AddProducer(appSetting.GetProducerSetting(ProduceId1));
});
builder.Services.AddKafkaConsumers(ConsumerBuilder =>
{
    ConsumerBuilder.AddConsumer<KafkaConsumerTask>(appSetting.GetConsumerSetting(CosumerId));
    //ConsumerBuilder.AddConsumer<KafkaConsumerTask>(appSetting.GetConsumerSetting(CosumerId));

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
