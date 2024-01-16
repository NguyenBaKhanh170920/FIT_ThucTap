using WebApplication1.Applications.Database;
using WebApplication1.Applications.Repositories;
using WebApplication1.Applications.Services;
using WebApplication1.StudentMemories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var studentMemory = new StudentMemory();
builder.Services.AddSingleton(studentMemory);
builder.Services.AddOracle<StudentDbContext>(configuration.GetConnectionString("OracleConnection"));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

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
