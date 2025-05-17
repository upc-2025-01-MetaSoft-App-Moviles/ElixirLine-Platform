using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Aggregate;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Repositories;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElixirLinePlatform.API.DigitalFieldLog.Infrastructure.Persistence.EFC.Repositories;

public class FieldLogEntryRepository(AppDbContext context)
    : BaseRepository<FieldLogEntry>(context), IFieldLogEntryRepository
{
    public async Task<IEnumerable<FieldLogEntry>> GetAllByParcelIdAsync(Guid parcelId)
    {
        return await Context.Set<FieldLogEntry>()
            .Where(e => e.ParcelId == parcelId)
            .ToListAsync();
    }

    public async Task<IEnumerable<FieldLogEntry>> GetAllByAuthorIdAsync(Guid authorId)
    {
        return await Context.Set<FieldLogEntry>()
            .Where(e => e.AuthorId == authorId)
            .ToListAsync();
    }
}