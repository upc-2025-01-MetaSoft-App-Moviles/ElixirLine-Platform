namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

public record BottlingStageResource(
    string batchId,
    string stageType,
    string startedAt,
    string completedAt,
    string completedBy,
    string observations,
    bool isCompleted,
    string bottlingLine,
    int bottlesFilled,
    int bottleVolumeMl,
    double totalVolumeLiters,
    string sealType,
    string code,
    double temperature,
    bool wasFiltered,
    bool wereLabelsApplied,
    bool wereCapsulesApplied);
    