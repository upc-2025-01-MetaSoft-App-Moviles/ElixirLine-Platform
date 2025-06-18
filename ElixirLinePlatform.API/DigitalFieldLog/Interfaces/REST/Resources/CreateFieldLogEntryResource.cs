namespace ElixirLinePlatform.API.DigitalFieldLog.Interfaces.REST.Resources;

public record CreateFieldLogEntryResource(
    Guid AuthorId,
    Guid ParcelId,
    string Description,
    string EntryType,
    Guid? RelatedTaskId,
    List<string>? PhotoUrls
);
