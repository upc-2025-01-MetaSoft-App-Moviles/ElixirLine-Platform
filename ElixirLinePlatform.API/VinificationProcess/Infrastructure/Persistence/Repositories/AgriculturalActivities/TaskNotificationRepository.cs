using System;
using System.Collections.Generic;
using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Infrastructure.Persistence.EFC.Repositories.AgriculturalActivities
{
    public class TaskNotificationRepository : ITaskNotificationRepository
    {
        private readonly AppDbContext _context;

        public TaskNotificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskNotification>> ListByRecipientIdAsync(Guid recipientId)
        {
            return await _context.Set<TaskNotification>()
                .Where(n => n.RecipientId == recipientId)
                .ToListAsync();
        }
        public async Task<IEnumerable<TaskNotification>> FindByTaskIdAsync(Guid taskId)
        {
            return await _context.TaskNotifications
                .Where(n => n.TaskId == taskId)
                .ToListAsync();
        }

        public async Task<TaskNotification?> FindByIdAsync(Guid notificationId)
        {
            return await _context.Set<TaskNotification>().FindAsync(notificationId);
        }

        public async Task AddAsync(TaskNotification notification)
        {
            await _context.Set<TaskNotification>().AddAsync(notification);
        }

        public void Update(TaskNotification notification)
        {
            _context.Set<TaskNotification>().Update(notification);
        }

        public void Remove(TaskNotification notification)
        {
            _context.Set<TaskNotification>().Remove(notification);
        }

        
    }
}
