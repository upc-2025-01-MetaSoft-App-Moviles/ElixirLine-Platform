using System;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities
{
    public class TaskNotification
    {
        public Guid NotificationId { get; private set; }
        public Guid RecipientId { get; private set; }
        public Guid TaskId { get; private set; }
        public void SetTaskId(Guid taskId)
        {
            TaskId = taskId;
        }
        public string Message { get; private set; }
        public DateTime SentDate { get; private set; }
        public bool ReadStatus { get; private set; }

        public TaskNotification(Guid notificationId, Guid recipientId, Guid taskId, string message, DateTime sentDate)
        {
            NotificationId = notificationId;
            RecipientId = recipientId;
            TaskId = taskId;
            Message = message;
            SentDate = sentDate;
            ReadStatus = false;
        }

        public void MarkAsRead()
        {
            ReadStatus = true;
        }
    }
}
