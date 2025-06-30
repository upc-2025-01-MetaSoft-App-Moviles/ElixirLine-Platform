namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

public record UpdatePressingStageResource(
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