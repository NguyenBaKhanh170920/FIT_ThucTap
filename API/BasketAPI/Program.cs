using BasketAPI.Applications.Database;
using BasketAPI.Applications.Repositories;
using BasketAPI.Applications.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddOracle<BasketAPIDbContext>(configuration.GetConnectionString("OracleConnection"));
builder.Services.AddScoped<IBasketRepositories, BasketRepository>();
builder.Services.AddScoped<IBasketService, BasketService>();
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
