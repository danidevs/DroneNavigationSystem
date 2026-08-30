namespace DroneNavigationSystem.Domain.Results;

public class DroneCommandResult
{
    public bool Success { get; }

    public string Message { get; }

    public DroneCommandResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}