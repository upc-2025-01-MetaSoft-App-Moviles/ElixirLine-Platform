using System.Threading.Tasks;
using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}