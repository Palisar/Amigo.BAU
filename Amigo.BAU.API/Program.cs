using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Application.Services;
using Amigo.BAU.Repository.EngineerRepository;
using System.Data.Common;
using System.Data.SqlClient;
using Amigo.BAU.API.Extensions;
using Amigo.BAU.Repository.Interfaces;
using Amigo.BAU.Repository.UnitOfWork;

string _CORS_DEV = "cors_dev";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(_CORS_DEV, policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
    
});
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("LaptopConnection");
builder.Services.AddTransient<DbConnection>(p => new SqlConnection(connectionString));

builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(_CORS_DEV);
app.UseAuthorization();

app.MapControllers();

app.Run();
