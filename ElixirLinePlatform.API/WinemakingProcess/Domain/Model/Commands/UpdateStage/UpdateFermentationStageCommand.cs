namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;

public record UpdateFermentationStageCommand(
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