namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddPressingStageCommand(
    string pressType, 
    double pressPressureBars, 
    int durationMinutes, 
    double pomaceKg, 
    double yieldLiters, 
    string mustUsage, 
    string startedAt, 
    string? completedBy,
    string? observations);