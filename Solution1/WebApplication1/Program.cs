using WebApplication1.Applications.Database;
using WebApplication1.Applications.Repositories.BasketRepositories;
using WebApplication1.Applications.Repositories.CustomerRepositories;
using WebApplication1.Applications.Repositories.OrderRepositories;
using WebApplication1.Applications.Repositories.ProductRepositories;
using WebApplication1.Applications.Services.BasketServices;
using WebApplication1.Applications.Services.CustomerServices;
using WebApplication1.Applications.Services.OrderServices;
using WebApplication1.Applications.Services.ProductServices;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOracle<Bai4DbContext>(configuration.GetConnectionString("OracleConnection"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
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

app.Run();
