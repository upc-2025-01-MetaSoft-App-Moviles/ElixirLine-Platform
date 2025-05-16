using ElixirLinePlatform.API.Modules.FieldWorkers.DTOs;
using ElixirLinePlatform.API.Modules.FieldWorkers.Entities;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ElixirLinePlatform.API.Modules.FieldWorkers.Services;

public class FieldWorkerService
{
    private readonly AppDbContext _context;

    public FieldWorkerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<FieldWorker>> GetAllAsync()
    {
        return await _context.FieldWorkers
            .OrderByDescending(fw => fw.CreatedAt)
            .ToListAsync();
    }

    public async Task<FieldWorker?> GetByIdAsync(Guid id)
    {
        return await _context.FieldWorkers.FirstOrDefaultAsync(fw => fw.Id == id);
    }

    public async Task<FieldWorker> CreateAsync(CreateFieldWorkerDTO dto)
    {
        var worker = new FieldWorker
        {
            FullName = dto.FullName,
            DNI = dto.DNI,
            Email = dto.Email,
            Phone = dto.Phone,
            Position = dto.Position
        };

        _context.FieldWorkers.Add(worker);
        await _context.SaveChangesAsync();

        return worker;
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateFieldWorkerDTO dto)
    {
        var worker = await _context.FieldWorkers.FindAsync(id);
        if (worker == null) return false;

        worker.FullName = dto.FullName;
        worker.Phone = dto.Phone;
        worker.IsActive = dto.IsActive;
        worker.Position = dto.Position;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var worker = await _context.FieldWorkers.FindAsync(id);
        if (worker == null) return false;

        _context.FieldWorkers.Remove(worker);
        await _context.SaveChangesAsync();
        return true;
    }
}
