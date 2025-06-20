using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities
{
    public class TaskExecutionReportService : ITaskExecutionReportService
    {
        private readonly ITaskExecutionReportRepository _reportRepository;

        public TaskExecutionReportService(ITaskExecutionReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<IEnumerable<TaskExecutionReport>> ListByTaskIdAsync(Guid taskId)
        {
            return await _reportRepository.ListByTaskIdAsync(taskId);
        }

        public async Task<TaskExecutionReport?> GetByIdAsync(Guid id)
        {
            return await _reportRepository.FindByIdAsync(id);
        }

        public async Task<TaskExecutionReport> CreateAsync(TaskExecutionReport report)
        {
            await _reportRepository.AddAsync(report);
            return report;
        }

        public async Task<TaskExecutionReport?> UpdateAsync(Guid id, TaskExecutionReport report)
        {
            var existing = await _reportRepository.FindByIdAsync(id);
            if (existing == null) return null;

            existing.UpdateObservations(report.Observations);
            _reportRepository.Update(existing);
            return existing;
        }

        public async Task<TaskExecutionReport?> DeleteAsync(Guid id)
        {
            var existing = await _reportRepository.FindByIdAsync(id);
            if (existing == null) return null;

            _reportRepository.Remove(existing);
            return existing;
        }
    }
}
