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

var droneApi = app.MapGroup("/api/drone");

droneApi.MapGet("/telemetry", () =>
{
    return drone.GetTelemetry();
})
.WithName("GetDroneTelemetry")

.WithOpenApi();
droneApi.MapPost("/takeoff", () =>
{
    drone.TakeOff();

    return Results.Ok(drone.GetTelemetry());
})
.WithName("TakeOffDrone")
.WithOpenApi();

droneApi.MapPost("/land", () =>
{
    drone.Land();

    return Results.Ok(drone.GetTelemetry());
})
.WithName("LandDrone")
.WithOpenApi();

droneApi.MapPost("/move/north", () =>
{
    drone.MoveNorth();

    return Results.Ok(drone.GetTelemetry());
})
.WithName("MoveDroneNorth")
.WithOpenApi();
droneApi.MapPost("/move/south", () =>
{
    drone.MoveSouth();

    return Results.Ok(drone.GetTelemetry());
})
.WithName("MoveDroneSouth")
.WithOpenApi();
droneApi.MapPost("/move/east", () =>
{
    drone.MoveEast();

    return Results.Ok(drone.GetTelemetry());
})
.WithName("MoveDroneEast")
.WithOpenApi();
droneApi.MapPost("/move/west", () =>
{
    drone.MoveWest();

    return Results.Ok(drone.GetTelemetry());
})
.WithName("MoveDroneWest")
.WithOpenApi();
droneApi.MapPost("/ascend", () =>
{
    drone.Ascend();

    return Results.Ok(drone.GetTelemetry());
})
.WithName("AscendDrone")
.WithOpenApi();

droneApi.MapPost("/descend", () =>
{
    drone.Descend();

    return Results.Ok(drone.GetTelemetry());
})
.WithName("DescendDrone")
.WithOpenApi();


app.Run();