namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;
public record FermentationStageResource(
    string batchId,
    string stageType,
    string startedAt, 
    string completedAt,
    string completedBy,
    bool isCompleted, 
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