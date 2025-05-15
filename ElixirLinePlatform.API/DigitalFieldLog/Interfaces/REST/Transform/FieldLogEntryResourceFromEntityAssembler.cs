using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Aggregate;
using ElixirLinePlatform.API.DigitalFieldLog.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.DigitalFieldLog.Interfaces.REST.Transform;

public static class FieldLogEntryResourceFromEntityAssembler
{
    public static FieldLogEntryResource ToResourceFromEntity(FieldLogEntry entity)
    {
        return new FieldLogEntryResource(
            entity.EntryId,
            entity.AuthorId,
            entity.ParcelId,
            entity.Description,
            entity.EntryType.ToString(),
            entity.Timestamp,
            entity.PhotoUrls.ToList()
        );
    }
}