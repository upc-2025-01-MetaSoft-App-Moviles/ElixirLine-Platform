namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddFermentationStageResource(
    string startedAt,
    string completedBy,
    string yeastUsed,
    double initialSugarLevel,
    double temperature,
    string tankCode,
    double initialPH,
    double finalPH,
    double maxFermentationTempC,
    double minFermentationTempC,
    string fermentationType,
    bool fermentationCompleted,
    string observations);