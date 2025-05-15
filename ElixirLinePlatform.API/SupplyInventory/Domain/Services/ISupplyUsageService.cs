using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
using ElixirLinePlatform.API.SupplyInventory.Domain.Services.Communication;

namespace ElixirLinePlatform.API.SupplyInventory.Domain.Services;

public interface ISupplyUsageService
{
    Task<IEnumerable<SupplyUsage>> ListAsync();
    Task<IEnumerable<SupplyUsage>> ListBySupplyIdAsync(int supplyId);
    Task<IEnumerable<SupplyUsage>> ListByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<SupplyUsageResponse> FindByIdAsync(int id);
    Task<SupplyUsageResponse> SaveAsync(SupplyUsage supplyUsage);
    Task<SupplyUsageResponse> UpdateAsync(int id, SupplyUsage supplyUsage);
    Task<SupplyUsageResponse> DeleteAsync(int id);
}