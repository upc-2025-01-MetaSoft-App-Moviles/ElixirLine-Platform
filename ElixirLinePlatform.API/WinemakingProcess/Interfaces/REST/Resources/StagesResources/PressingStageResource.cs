namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record PressingStageResource(
    string stageType,
    string startedAt, 
    string pressType, 
    double pressPressureBars, 
    int durationMinutes, 
    double pomaceKg, 
    double yieldLiters, 
    string mustUsage, 
    string? observations
    );