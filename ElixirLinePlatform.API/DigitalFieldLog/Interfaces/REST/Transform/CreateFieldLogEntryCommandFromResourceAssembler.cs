using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Commands;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.ValueObjects;
using ElixirLinePlatform.API.DigitalFieldLog.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.DigitalFieldLog.Interfaces.REST.Transform;

public static class CreateFieldLogEntryCommandFromResourceAssembler
{
    public static CreateFieldLogEntryCommand ToCommandFromResource(CreateFieldLogEntryResource resource)
    {
        return new CreateFieldLogEntryCommand(
            resource.AuthorId,
            resource.ParcelId,
            resource.Description,
            Enum.Parse<EntryType>(resource.EntryType),
            resource.RelatedTaskId
        );
    }
}