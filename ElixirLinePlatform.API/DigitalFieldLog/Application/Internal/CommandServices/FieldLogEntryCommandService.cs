using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Aggregate;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Commands;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Repositories;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Services;
using ElixirLinePlatform.API.Shared.Domain.Repositories;

namespace ElixirLinePlatform.API.DigitalFieldLog.Application.Internal.CommandServices;

public class FieldLogEntryCommandService(
    IFieldLogEntryRepository repository,
    IUnitOfWork unitOfWork
) : IFieldLogEntryCommandService
{
    public async Task<FieldLogEntry?> Handle(CreateFieldLogEntryCommand command)
    {
        var entry = new FieldLogEntry(command);
        await repository.AddAsync(entry);
        await unitOfWork.CompleteAsync();
        return entry;
    }
}