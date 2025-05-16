using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElixirLinePlatform.API.VinificationProcess.Interfaces.REST.AgriculturalActivities
{
    [ApiController]
    [Route("api/tasks/{taskId}/notifications")]
    public class TaskNotificationsController : ControllerBase
    {
        private readonly ITaskNotificationService _notificationService;

        public TaskNotificationsController(ITaskNotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List notifications for a specific task")]
        public async Task<ActionResult<IEnumerable<TaskNotification>>> GetAll(Guid taskId)
        {
            var notifications = await _notificationService.ListByTaskIdAsync(taskId);
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a specific notification by ID")]
        public async Task<ActionResult<TaskNotification>> GetById(Guid taskId, Guid id)
        {
            var notification = await _notificationService.GetByIdAsync(id);
            if (notification == null || notification.TaskId != taskId) return NotFound();
            return Ok(notification);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new task notification")]
        public async Task<ActionResult<TaskNotification>> Create(Guid taskId, [FromBody] TaskNotification notification)
        {
            notification.SetTaskId(taskId);
            var created = await _notificationService.CreateAsync(notification);
            return CreatedAtAction(nameof(GetById), new { taskId, id = created.NotificationId }, created);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing notification")]
        public async Task<ActionResult<TaskNotification>> Update(Guid taskId, Guid id, [FromBody] TaskNotification notification)
        {
            var updated = await _notificationService.UpdateAsync(id, notification);
            if (updated == null || updated.TaskId != taskId) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a notification")]
        public async Task<ActionResult> Delete(Guid taskId, Guid id)
        {
            var deleted = await _notificationService.DeleteAsync(id);
            if (deleted == null || deleted.TaskId != taskId) return NotFound();
            return NoContent();
        }
    }
}
