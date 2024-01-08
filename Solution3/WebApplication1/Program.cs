using WebApplication1.Applications.Database;
using WebApplication1.Applications.Repositories;
using WebApplication1.Applications.Repositories.CategoryRepo;
using WebApplication1.Applications.Repositories.OrderDetailRepo;
using WebApplication1.Applications.Repositories.OrderRepo;
using WebApplication1.Applications.Repositories.StatusRepo;
using WebApplication1.Applications.Repositories.SupplierRepo;
using WebApplication1.Applications.Repositories.TradeMarkRepo;
using WebApplication1.Applications.Services;
using WebApplication1.Applications.Services.CategoryServ;
using WebApplication1.Applications.Services.OrderDetailServ;
using WebApplication1.Applications.Services.OrderServ;
using WebApplication1.Applications.Services.StatusServ;
using WebApplication1.Applications.Services.SupplierServ;
using WebApplication1.Applications.Services.TradeMarkServ;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOracle<Bai1DbContext>(configuration.GetConnectionString("OracleConnection"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderDetailRespository, OrderDetailRespository>();
builder.Services.AddScoped<IOrderDetailServices, OrderDetailServices>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ITradeMarkRepository, TradeMarkRepository>();
builder.Services.AddScoped<ITradeMarkServices, TradeMarkServices>();
builder.Services.AddScoped<ISuppierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierServices, SupplierServices>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusServices, StatusServices>();
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
