using DroneNavigationSystem.Domain.Entities;

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

app.MapGet("/api/drone/telemetry", () =>
{
    return drone.GetTelemetry();
})
.WithName("GetDroneTelemetry")

.WithOpenApi();
app.MapPost("/api/drone/takeoff", () =>
{
    drone.TakeOff();

    return Results.Ok(drone.GetTelemetry());
})
.WithName("TakeOffDrone")
.WithOpenApi();

app.MapPost("/api/drone/land", () =>
{
    drone.Land();

    return Results.Ok(drone.GetTelemetry());
})
.WithName("LandDrone")
.WithOpenApi();

app.MapPost("/api/drone/move/north", () =>
{
    drone.MoveNorth();

    return Results.Ok(drone.GetTelemetry());
})
.WithName("MoveDroneNorth")
.WithOpenApi();

app.Run();