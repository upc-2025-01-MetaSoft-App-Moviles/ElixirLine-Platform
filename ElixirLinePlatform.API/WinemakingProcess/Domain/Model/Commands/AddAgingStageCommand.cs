namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddAgingStageCommand(
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