namespace ElixirLinePlatform.API.ProductionHistory.Interfaces.REST.Resources;

public record CreateProductionRecordResource(
    Guid BatchId,
    string StartDate,
    string EndDate,
    float VolumeProduced,
    float Brix,
    float Ph,
    float Temperature);