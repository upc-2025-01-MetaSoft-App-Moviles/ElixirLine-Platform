namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

public record UpdateFermentationStageResource( 
    string StartedAt, 
    string CompletedAt,
    string CompletedBy,
    bool IsCompleted, 
    string YeastUsed,
    double InitialSugarLevel,
    double FinalSugarLevel,
    double InitialPh,
    double FinalPh,
    double TemperatureMin,
    double TemperatureMax,
    string FermentationType,
    string TankCode,
    string? Observations);