using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
using ElixirLinePlatform.API.SupplyInventory.Domain.Services.Communication;

namespace ElixirLinePlatform.API.SupplyInventory.Domain.Services;

public interface ISupplyService
{
    Task<IEnumerable<Supply>> ListAsync();
    Task<IEnumerable<Supply>> ListByCategoryAsync(string category);
    Task<IEnumerable<Supply>> ListByExpirationDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<SupplyResponse> FindByIdAsync(int id);
    Task<SupplyResponse> SaveAsync(Supply supply);
    Task<SupplyResponse> UpdateAsync(int id, Supply supply);
    Task<SupplyResponse> DeleteAsync(int id);
}