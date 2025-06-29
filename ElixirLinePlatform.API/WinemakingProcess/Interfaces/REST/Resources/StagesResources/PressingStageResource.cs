namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

public record PressingStageResource(
    string batchId,
    string stageType,
    string startedAt, 
    string completedAt,
    string completedBy,
    bool isCompleted,  
    string pressType, 
    double pressPressureBars, 
    int durationMinutes, 
    double pomaceKg, 
    double yieldLiters, 
    string mustUsage, 
    string? observations
    );