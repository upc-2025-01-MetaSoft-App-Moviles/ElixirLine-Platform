namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;
public record FermentationStageResource(
    string stageType,
    string startedAt,
    string completedBy,
    string yeastUsed,
    double initialSugarLevel,
    double finalSugarLevel,
    double initialPh,
    double finalPh,
    double temperatureMax,
    double temperatureMin,
    string fermentationType,
    string tankCode,
    string? observations);