namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;

public record UpdatePressingStageCommand( 
    string startedAt, 
    string completedBy,
    bool isCompleted,  
    string pressType, 
    double pressPressureBars, 
    int durationMinutes, 
    double pomaceKg, 
    double yieldLiters, 
    string mustUsage, 
    string? observations);
    