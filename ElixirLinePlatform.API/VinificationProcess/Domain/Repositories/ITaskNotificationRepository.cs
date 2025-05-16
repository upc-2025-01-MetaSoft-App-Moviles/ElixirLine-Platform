using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities
{
    public interface ITaskNotificationRepository
    {
        Task<IEnumerable<TaskNotification>> ListByRecipientIdAsync(Guid recipientId);
        Task<TaskNotification?> FindByIdAsync(Guid notificationId);
        Task AddAsync(TaskNotification notification);
        void Update(TaskNotification notification);
        void Remove(TaskNotification notification);
        Task<IEnumerable<TaskNotification>> FindByTaskIdAsync(Guid taskId);
    }
}
