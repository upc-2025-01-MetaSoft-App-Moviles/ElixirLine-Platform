namespace ElixirLinePlatform.API.ProductionHistory.Domain.Model.Commands;

public record CreateProductionRecordCommand(Guid BatchId, 
    string StartDate,
    string EndDate,
    float VolumeProduced,
    float Brix,
    float Ph,
    float Temperature);