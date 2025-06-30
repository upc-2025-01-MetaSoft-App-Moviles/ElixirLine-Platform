namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

public record AgingStageResource(
    string batchId,
    string stageType,
    string startedAt,
    string completedAt,
    string completedBy,
    string observations,
    bool isCompleted,
    string containerType,
    string material,
    string containerCode,
    double avgTemperature,
    double volumeLiters,
    int durationMonths,
    int frequencyDays,
    int refilled,
    int batonnage,
    int rackings,
    string purpose);
    

