using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities
{
    public class TaskNotificationService : ITaskNotificationService
    {
        private readonly ITaskNotificationRepository _notificationRepository;

        public TaskNotificationService(ITaskNotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<IEnumerable<TaskNotification>> ListByRecipientIdAsync(Guid recipientId)
        {
            return await _notificationRepository.ListByRecipientIdAsync(recipientId);
        }

        public async Task<TaskNotification?> GetByIdAsync(Guid id)
        {
            return await _notificationRepository.FindByIdAsync(id);
        }

        public async Task<TaskNotification> CreateAsync(TaskNotification notification)
        {
            await _notificationRepository.AddAsync(notification);
            return notification;
        }

        public async Task<TaskNotification?> UpdateAsync(Guid id, TaskNotification notification)
        {
            var existing = await _notificationRepository.FindByIdAsync(id);
            if (existing == null) return null;

            if (notification.ReadStatus)
            {
                existing.MarkAsRead();
            }
            _notificationRepository.Update(existing);
            return existing;
        }

        public async Task<TaskNotification?> DeleteAsync(Guid id)
        {
            var existing = await _notificationRepository.FindByIdAsync(id);
            if (existing == null) return null;

            _notificationRepository.Remove(existing);
            return existing;
        }

        public async Task<IEnumerable<TaskNotification>> ListByTaskIdAsync(Guid taskId)
        {
            return await _notificationRepository.FindByTaskIdAsync(taskId);
        }

    }
}
