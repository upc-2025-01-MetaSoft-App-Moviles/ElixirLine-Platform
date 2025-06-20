namespace ElixirLinePlatform.API.DigitalFieldLog.Interfaces.REST.Resources;

public record FieldLogEntryResource(
    Guid EntryId,
    Guid AuthorId,
    Guid ParcelId,
    string Description,
    string EntryType,
    DateTime Timestamp,
    List<string> PhotoUrls
);