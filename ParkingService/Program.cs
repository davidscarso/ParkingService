using Microsoft.EntityFrameworkCore;
using ParkingService;
using ParkingService.Infrastructure;
using ParkingService.Infrastructure.Interfaces;
using ParkingService.Models;
using ParkingService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection of DbContext Class
builder.Services.AddDbContext<APIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddTransient<IParkingService, ParkingService.Services.ParkingService>();

builder.Services.AddTransient<ICheckInRepository, CheckInRepository>();
builder.Services.AddTransient<IParkingFeeRepository, ParkingFeeRepository>();
builder.Services.AddTransient<IStayRepository, StayRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();


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
