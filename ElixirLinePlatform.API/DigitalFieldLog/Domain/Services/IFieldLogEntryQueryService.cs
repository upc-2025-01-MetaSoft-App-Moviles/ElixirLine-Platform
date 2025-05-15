using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Aggregate;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Queries;

namespace ElixirLinePlatform.API.DigitalFieldLog.Domain.Services;

public interface IFieldLogEntryQueryService
{
    Task<IEnumerable<FieldLogEntry>> Handle(GetAllFieldLogEntriesQuery query);
}