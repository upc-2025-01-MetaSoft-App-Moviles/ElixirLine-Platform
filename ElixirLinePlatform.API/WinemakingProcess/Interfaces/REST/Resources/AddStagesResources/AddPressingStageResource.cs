namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddPressingStageResource(
    string pressType, 
    double pressPressureBars, 
    int durationMinutes, 
    double pomaceKg, 
    double yieldLiters, 
    string mustUsage, 
    string startedAt, 
    string? completedBy, 
    string? observations);