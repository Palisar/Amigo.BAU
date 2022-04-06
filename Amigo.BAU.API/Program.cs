using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Application.Services;
using Amigo.BAU.Repository.EmployeeRepository;
using Amigo.BAU.Repository.EngineerRepository;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(typeof(IDateTimeProvider), typeof(DateTimeProvider));

var connectionString = builder.Configuration.GetConnectionString("LaptopConnection");

builder.Services.AddTransient<IDbConnection>(p => new SqlConnection(connectionString));
builder.Services.AddScoped(typeof(IEngineerRepository), typeof(EngineerRepository));
builder.Services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
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
