using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;
using ElixirLinePlatform.API.ProductionHistory.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.ProductionHistory.Interfaces.REST.Transform;

public static class ProductionRecordFromEntityAssembler
{
    public static ProductionRecordResource ToResourceFromEntity(ProductionRecord entity)
    {
        return new ProductionRecordResource(
            entity.RecordId,
            entity.BatchId,
            entity.StartDate.ToString("dd-MM-yyyy"),
            entity.EndDate.ToString("dd-MM-yyyy"),
            entity.VolumeProduced,
            entity.QualityMetrics.Brix,
            entity.QualityMetrics.Ph,
            entity.QualityMetrics.Temperature);
    }
}