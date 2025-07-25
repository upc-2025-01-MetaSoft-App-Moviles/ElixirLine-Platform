using System;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities
{
    public enum TaskStatus
    {
        Scheduled,
        InProgress,
        Completed,
        Cancelled
    }

    public class AgriculturalTask
    {
        public Guid TaskId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid ParcelId { get; private set; }
        public Guid AssignedTo { get; private set; }
        public DateTime ScheduledDate { get; private set; }
        public TaskStatus Status { get; private set; }

        public AgriculturalTask(Guid taskId, string title, string description, Guid parcelId, Guid assignedTo, DateTime scheduledDate)
        {
            TaskId = taskId;
            Title = title;
            Description = description;
            ParcelId = parcelId;
            AssignedTo = assignedTo;
            ScheduledDate = scheduledDate;
            Status = TaskStatus.Scheduled;
        }

        public void StartTask()
        {
            if (Status != TaskStatus.Scheduled)
                throw new InvalidOperationException("La tarea solo puede iniciarse si está programada.");
            Status = TaskStatus.InProgress;
        }

        public void CompleteTask()
        {
            if (Status != TaskStatus.InProgress)
                throw new InvalidOperationException("La tarea solo puede completarse si está en progreso.");
            Status = TaskStatus.Completed;
        }

        public void CancelTask(string reason)
        {
            if (Status == TaskStatus.Completed)
                throw new InvalidOperationException("No se puede cancelar una tarea completada.");
            // Puedes almacenar la razón si agregas un campo Reason o Notes
            Status = TaskStatus.Cancelled;
        }
    }
}
