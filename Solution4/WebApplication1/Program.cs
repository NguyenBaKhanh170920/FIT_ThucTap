using WebApplication1.Applications.Database;
using WebApplication1.Applications.Repositories.BasketIteRepositories;
using WebApplication1.Applications.Repositories.CustomersRepositories;
using WebApplication1.Applications.Repositories.OrderRepositories;
using WebApplication1.Applications.Repositories.ProductsRepositories;
using WebApplication1.Applications.Services.BasketItemService;
using WebApplication1.Applications.Services.CustomerService;
using WebApplication1.Applications.Services.OrdersService;
using WebApplication1.Applications.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOracle<Bai2DbContext>(configuration.GetConnectionString("OracleConnection"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IBasketItemRepositories, BasketItemRepositories>();
builder.Services.AddScoped<IBasketItemServices, BasketItemServices>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
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
