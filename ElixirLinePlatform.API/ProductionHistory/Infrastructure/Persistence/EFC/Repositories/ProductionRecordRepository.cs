using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;
using ElixirLinePlatform.API.ProductionHistory.Domain.Repositories;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElixirLinePlatform.API.ProductionHistory.Infrastructure.Persistence.EFC.Repositories;

public class ProductionRecordRepository(AppDbContext context) : BaseRepository<ProductionRecord>(context), IProductionRecordRepository
{
    public async Task<ProductionRecord> GetProductionRecordByIdAsync(Guid recordId)
    {
        return await Context.Set<ProductionRecord>().FirstOrDefaultAsync(x => x.RecordId == recordId);
    }

    public async Task<IEnumerable<ProductionRecord>> GetAllProductionRecordByBatchIdAsync(Guid batchId)
    {
        var records = await Context.Set<ProductionRecord>().Where(x => x.BatchId == batchId).ToListAsync();
        
        if(records.Count == 0)
        {
            throw new Exception($"No production records found for batch ID: {batchId}");
        }

        return records;

    }
}