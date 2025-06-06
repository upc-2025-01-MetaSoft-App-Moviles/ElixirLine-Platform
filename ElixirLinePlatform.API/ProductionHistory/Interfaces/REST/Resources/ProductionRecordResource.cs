namespace ElixirLinePlatform.API.ProductionHistory.Interfaces.REST.Resources;

public record ProductionRecordResource(
    Guid RecordId,
    Guid BatchId,
    string StartDate,
    string EndDate,
    float VolumeProduced,
    float Brix,
    float Ph,
    float Temperature);