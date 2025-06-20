using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities
{
    public interface ITaskNotificationService
    {
        Task<IEnumerable<TaskNotification>> ListByRecipientIdAsync(Guid recipientId);
        Task<IEnumerable<TaskNotification>> ListByTaskIdAsync(Guid taskId);
        Task<TaskNotification?> GetByIdAsync(Guid id);
        Task<TaskNotification> CreateAsync(TaskNotification notification);
        Task<TaskNotification?> UpdateAsync(Guid id, TaskNotification notification);
        Task<TaskNotification?> DeleteAsync(Guid id);
    }
}
