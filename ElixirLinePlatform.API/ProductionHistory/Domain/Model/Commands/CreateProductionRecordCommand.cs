namespace ElixirLinePlatform.API.ProductionHistory.Domain.Model.Commands;

public record CreateProductionRecordCommand(Guid BatchId, 
    string StartDate,
    string EndDate,
    float VolumeProduced,
    Dictionary<string, float> QualityMetrics);