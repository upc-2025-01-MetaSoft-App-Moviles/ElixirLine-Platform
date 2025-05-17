using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Aggregate;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Queries;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Repositories;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Services;

namespace ElixirLinePlatform.API.DigitalFieldLog.Application.Internal.QueryServices;

public class FieldLogEntryQueryService(IFieldLogEntryRepository repository)
    : IFieldLogEntryQueryService
{
    public async Task<IEnumerable<FieldLogEntry>> Handle(GetAllFieldLogEntriesQuery query)
    {
        return await repository.ListAsync();
    }
}