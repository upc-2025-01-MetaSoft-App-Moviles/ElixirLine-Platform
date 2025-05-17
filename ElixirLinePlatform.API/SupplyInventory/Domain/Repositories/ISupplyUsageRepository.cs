using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;

namespace ElixirLinePlatform.API.SupplyInventory.Domain.Repositories;

public interface ISupplyUsageRepository : IBaseRepository<SupplyUsage>
{
    Task<IEnumerable<SupplyUsage>> ListBySupplyIdAsync(int supplyId);
    Task<IEnumerable<SupplyUsage>> ListByDateRangeAsync(DateTime startDate, DateTime endDate);
}