using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Queries;

namespace ElixirLinePlatform.API.ProductionHistory.Domain.Services;

public interface IProductionRecordQueryService
{
    Task<ProductionRecord?> Handle(GetProductionRecordByIdQuery query);
    Task<IEnumerable<ProductionRecord>> Handle(GetAllProductionRecordQuery query);
    Task<IEnumerable<ProductionRecord>> Handle(GetAllProductionRecordByBatchIdQuery query);
}