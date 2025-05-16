using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities
{
    public interface ITaskExecutionReportService
    {
        Task<IEnumerable<TaskExecutionReport>> ListByTaskIdAsync(Guid taskId);
        Task<TaskExecutionReport?> GetByIdAsync(Guid id);
        Task<TaskExecutionReport> CreateAsync(TaskExecutionReport report);
        Task<TaskExecutionReport?> UpdateAsync(Guid id, TaskExecutionReport report);
        Task<TaskExecutionReport?> DeleteAsync(Guid id);
    }
}
