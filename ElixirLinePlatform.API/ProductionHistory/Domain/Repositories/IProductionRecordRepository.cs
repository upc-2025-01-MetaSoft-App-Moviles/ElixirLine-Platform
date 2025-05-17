using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;
using ElixirLinePlatform.API.Shared.Domain.Repositories;

namespace ElixirLinePlatform.API.ProductionHistory.Domain.Repositories;

public interface IProductionRecordRepository : IBaseRepository<ProductionRecord>
{
    Task<ProductionRecord> GetProductionRecordByIdAsync(Guid recordId);
    Task<IEnumerable<ProductionRecord>> GetAllProductionRecordByBatchIdAsync(Guid batchId);
}