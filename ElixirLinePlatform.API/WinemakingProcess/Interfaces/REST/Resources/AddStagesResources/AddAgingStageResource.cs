namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddAgingStageResource(
    string containerType,
    string material,
    string containerCode,
    double avgTemperature,
    double volumeLiters,
    int durationMonths,
    int? frequencyDays,
    int refilled,
    int batonnage,
    int rackings,
    string purpose,
    string startedAt, 
    string? completedBy,
    string? observations);