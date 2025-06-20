using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Commands;

public record CreateFieldLogEntryCommand(
    Guid AuthorId,
    Guid ParcelId,
    string Description,
    EntryType EntryType,
    Guid? RelatedTaskId = null
);