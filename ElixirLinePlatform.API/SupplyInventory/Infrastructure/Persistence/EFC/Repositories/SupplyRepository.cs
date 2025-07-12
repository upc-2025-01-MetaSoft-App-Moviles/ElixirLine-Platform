using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
using ElixirLinePlatform.API.SupplyInventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElixirLinePlatform.API.SupplyInventory.Infrastructure.Persistence.EFC.Repositories;

public class SupplyRepository : BaseRepository<Supply>, ISupplyRepository
{
    public SupplyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Supply>> ListByCategoryAsync(string category)
    {
        return await Context.Set<Supply>()
            .Where(s => s.Category == category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Supply>> ListByExpirationDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await Context.Set<Supply>()
            .Where(s => s.ExpirationDate >= startDate && s.ExpirationDate <= endDate)
            .ToListAsync();
    }
}