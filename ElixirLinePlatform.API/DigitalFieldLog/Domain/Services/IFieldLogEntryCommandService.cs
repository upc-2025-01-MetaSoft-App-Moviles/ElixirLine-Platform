using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Aggregate;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Commands;

namespace ElixirLinePlatform.API.DigitalFieldLog.Domain.Services;

public interface IFieldLogEntryCommandService
{
    Task<FieldLogEntry?> Handle(CreateFieldLogEntryCommand command);
}