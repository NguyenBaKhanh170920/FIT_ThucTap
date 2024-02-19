using EFCore_Exa2.Applications.Database;
using EFCore_Exa2.Applications.Repositories.MarkRepositories;
using EFCore_Exa2.Applications.Repositories.StudentRepositories;
using EFCore_Exa2.Applications.Repositories.SubjectRepositories;
using EFCore_Exa2.Applications.Services.MarkServices;
using EFCore_Exa2.Applications.Services.StudentServices;
using EFCore_Exa2.Applications.Services.SubjectServices;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOracle<StudentDbContext>(configuration.GetConnectionString("OracleConnection"));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IMarkRepository, MarkRepository>();
builder.Services.AddScoped<IMarkService, MarkService>();
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
