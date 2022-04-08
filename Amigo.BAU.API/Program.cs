using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Application.Services;
using Amigo.BAU.Repository.EmployeeRepository;
using Amigo.BAU.Repository.EngineerRepository;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Amigo.BAU.Repository.Interfaces;
using Amigo.BAU.Repository.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("LaptopConnection");
builder.Services.AddTransient<DbConnection>(p => new SqlConnection(connectionString));
//builder.Services.AddTransient<IDbConnection>(p => new SqlConnection(connectionString));

builder.Services.AddSingleton(typeof(IDateTimeProvider), typeof(DateTimeProvider));
builder.Services.AddSingleton(typeof(ISupportTeam), typeof(SupportTeamService));
builder.Services.AddScoped(typeof(IEngineerRepository), typeof(EngineerRepository));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(ISupportWheelOfFate), typeof(SupportWheelOfFateService));

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
