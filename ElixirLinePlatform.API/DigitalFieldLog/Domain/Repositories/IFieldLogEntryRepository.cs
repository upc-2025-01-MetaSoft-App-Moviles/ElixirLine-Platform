using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Aggregate;
using ElixirLinePlatform.API.Shared.Domain.Repositories;

namespace ElixirLinePlatform.API.DigitalFieldLog.Domain.Repositories;

public interface IFieldLogEntryRepository : IBaseRepository<FieldLogEntry>
{
    Task<IEnumerable<FieldLogEntry>> GetAllByParcelIdAsync(Guid parcelId);
    Task<IEnumerable<FieldLogEntry>> GetAllByAuthorIdAsync(Guid authorId);
}