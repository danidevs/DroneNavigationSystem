using DroneNavigationSystem.Domain.Entities;
using DroneNavigationSystem.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var drone = new Drone(
    "Fênix X1",
    "OpenAI Aerospace");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapDroneEndpoints(drone);




app.Run();