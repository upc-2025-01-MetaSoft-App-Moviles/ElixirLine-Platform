using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ElixirLinePlatform.API.VinificationProcess.Infrastructure.Persistence.EFC.Repositories.AgriculturalActivities
{
    public class AgriculturalTaskRepository : IAgriculturalTaskRepository
    {
        private readonly AppDbContext _context;

        public AgriculturalTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AgriculturalTask>> ListAsync()
        {
            return await _context.Set<AgriculturalTask>().ToListAsync();
        }

        public async Task<AgriculturalTask?> FindByIdAsync(Guid taskId)
        {
            return await _context.Set<AgriculturalTask>().FindAsync(taskId);
        }

        public async Task AddAsync(AgriculturalTask task)
        {
            await _context.Set<AgriculturalTask>().AddAsync(task);
        }

        public void Update(AgriculturalTask task)
        {
            _context.Set<AgriculturalTask>().Update(task);
        }

        public void Remove(AgriculturalTask task)
        {
            _context.Set<AgriculturalTask>().Remove(task);
        }
    }
}
