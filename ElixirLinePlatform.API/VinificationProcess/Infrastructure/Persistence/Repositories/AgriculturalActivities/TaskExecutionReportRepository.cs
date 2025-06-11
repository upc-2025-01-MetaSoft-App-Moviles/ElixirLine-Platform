using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ElixirLinePlatform.API.VinificationProcess.Infrastructure.Persistence.EFC.Repositories.AgriculturalActivities
{
    public class TaskExecutionReportRepository : ITaskExecutionReportRepository
    {
        private readonly AppDbContext _context;

        public TaskExecutionReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskExecutionReport>> ListByTaskIdAsync(Guid taskId)
        {
            return await _context.Set<TaskExecutionReport>()
                .Where(r => r.TaskId == taskId)
                .ToListAsync();
        }

        public async Task<TaskExecutionReport?> FindByIdAsync(Guid reportId)
        {
            return await _context.Set<TaskExecutionReport>().FindAsync(reportId);
        }

        public async Task AddAsync(TaskExecutionReport report)
        {
            await _context.Set<TaskExecutionReport>().AddAsync(report);
        }

        public void Update(TaskExecutionReport report)
        {
            _context.Set<TaskExecutionReport>().Update(report);
        }

        public void Remove(TaskExecutionReport report)
        {
            _context.Set<TaskExecutionReport>().Remove(report);
        }
    }
}
