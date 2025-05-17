using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Queries;
using ElixirLinePlatform.API.ProductionHistory.Domain.Repositories;
using ElixirLinePlatform.API.ProductionHistory.Domain.Services;

namespace ElixirLinePlatform.API.ProductionHistory.Application.Internal.QueryServices;

public class ProductionRecordQueryService(IProductionRecordRepository productionRecordRepository)
    : IProductionRecordQueryService
{
    public async Task<ProductionRecord?> Handle(GetProductionRecordByIdQuery query)
    {
        return await productionRecordRepository.GetProductionRecordByIdAsync(query.RecordId);
    }

    public async Task<IEnumerable<ProductionRecord>> Handle(GetAllProductionRecordQuery query)
    {
        return await productionRecordRepository.ListAsync();
    }
    
    public async Task<IEnumerable<ProductionRecord>> Handle(GetAllProductionRecordByBatchIdQuery query)
    {
        return await productionRecordRepository.GetAllProductionRecordByBatchIdAsync(query.BatchId);
    }
}