namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;

public record UpdatePressingStageCommand( 
    string StartedAt, 
    string CompletedBy,
    bool IsCompleted,  
    string PressType, 
    double PressPressureBars, 
    int DurationMinutes, 
    double PomaceKg, 
    double YieldLiters, 
    string MustUsage, 
    string? Observations);
    