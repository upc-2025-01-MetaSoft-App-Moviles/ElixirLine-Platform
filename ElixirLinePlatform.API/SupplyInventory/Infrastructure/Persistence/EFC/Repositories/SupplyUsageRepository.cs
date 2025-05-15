using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
using ElixirLinePlatform.API.SupplyInventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElixirLinePlatform.API.SupplyInventory.Infrastructure.Persistence.EFC.Repositories;

public class SupplyUsageRepository : BaseRepository<SupplyUsage>, ISupplyUsageRepository
{
    public SupplyUsageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<SupplyUsage>> ListBySupplyIdAsync(int supplyId)
    {
        return await Context.Set<SupplyUsage>()
            .Where(su => su.SupplyId == supplyId)
            .Include(su => su.Supply)
            .ToListAsync();
    }

    public async Task<IEnumerable<SupplyUsage>> ListByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await Context.Set<SupplyUsage>()
            .Where(su => su.UsageDate >= startDate && su.UsageDate <= endDate)
            .Include(su => su.Supply)
            .ToListAsync();
    }
}