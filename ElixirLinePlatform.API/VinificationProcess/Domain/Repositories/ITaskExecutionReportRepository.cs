using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities
{
    public interface ITaskExecutionReportRepository
    {
        Task<IEnumerable<TaskExecutionReport>> ListByTaskIdAsync(Guid taskId);
        Task<TaskExecutionReport?> FindByIdAsync(Guid reportId);
        Task AddAsync(TaskExecutionReport report);
        void Update(TaskExecutionReport report);
        void Remove(TaskExecutionReport report);
    }
}
