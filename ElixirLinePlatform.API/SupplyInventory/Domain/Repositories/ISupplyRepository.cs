using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;

namespace ElixirLinePlatform.API.SupplyInventory.Domain.Repositories;

public interface ISupplyRepository : IBaseRepository<Supply>
{
    Task<IEnumerable<Supply>> ListByCategoryAsync(string category);
    Task<IEnumerable<Supply>> ListByExpirationDateRangeAsync(DateTime startDate, DateTime endDate);
}