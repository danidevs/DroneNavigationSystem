

using DroneNavigationSystem.Domain.Entities;

namespace DroneNavigationSystem.Api.Endpoints;

public static class DroneEndpoints
{
    public static void MapDroneEndpoints(
        this WebApplication app,
        Drone drone)
    {
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
            var result = drone.MoveNorth();

            if (!result.Success)
            {
                return Results.BadRequest(new
                {
                    message = result.Message,
                    telemetry = drone.GetTelemetry()
                });
            }

            return Results.Ok(new
            {
                message = result.Message,
                telemetry = drone.GetTelemetry()
            });
        })
        .WithName("MoveDroneNorth")
        .WithOpenApi();

        droneApi.MapPost("/move/south", () =>
        {
            var result = drone.MoveSouth();

            if (!result.Success)
            {
                return Results.BadRequest(new
                {
                    message = result.Message,
                    telemetry = drone.GetTelemetry()
                });
            }

            return Results.Ok(new
            {
                message = result.Message,
                telemetry = drone.GetTelemetry()
            });
        })
        .WithName("MoveDroneSouth")
        .WithOpenApi();

        droneApi.MapPost("/move/east", () =>
        {
            var result = drone.MoveEast();

            if (!result.Success)
            {
                return Results.BadRequest(new
                {
                    message = result.Message,
                    telemetry = drone.GetTelemetry()
                });
            }

            return Results.Ok(new
            {
                message = result.Message,
                telemetry = drone.GetTelemetry()
            });
        })
        .WithName("MoveDroneEast")
        .WithOpenApi();

        droneApi.MapPost("/move/west", () =>
        {
            var result = drone.MoveWest();

            if (!result.Success)
            {
                return Results.BadRequest(new
                {
                    message = result.Message,
                    telemetry = drone.GetTelemetry()
                });
            }

            return Results.Ok(new
            {
                message = result.Message,
                telemetry = drone.GetTelemetry()
            });
        })
        .WithName("MoveDroneWest")
        .WithOpenApi();

        droneApi.MapPost("/ascend", () =>
{
    var result = drone.Ascend();

    if (!result.Success)
    {
        return Results.BadRequest(new
        {
            message = result.Message,
            telemetry = drone.GetTelemetry()
        });
    }

    return Results.Ok(new
    {
        message = result.Message,
        telemetry = drone.GetTelemetry()
    });
})
.WithName("AscendDrone")
.WithOpenApi();
droneApi.MapPost("/descend", () =>
{
    var result = drone.Descend();

    if (!result.Success)
    {
        return Results.BadRequest(new
        {
            message = result.Message,
            telemetry = drone.GetTelemetry()
        });
    }

    return Results.Ok(new
    {
        message = result.Message,
        telemetry = drone.GetTelemetry()
    });
})
.WithName("DescendDrone")
.WithOpenApi();
    }
}
