namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddFermentationStageResource(
    string yeastUsed,
    double initialBrix,
    double finalBrix,
    double initialPh,
    double finalPh,
    double temperatureMax,
    double temperatureMin,
    string fermentationType,
    string tankCode,
    string startedAt,
    string? completedBy,
    string? observations);