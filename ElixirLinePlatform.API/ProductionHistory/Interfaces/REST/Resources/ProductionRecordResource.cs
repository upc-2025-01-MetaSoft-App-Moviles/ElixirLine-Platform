namespace ElixirLinePlatform.API.ProductionHistory.Interfaces.REST.Resources;

public record ProductionRecordResource(
    Guid RecordId,
    Guid BatchId,
    string StartDate,
    string EndDate,
    float VolumeProduced,
    Dictionary<string, float> QualityMetrics);