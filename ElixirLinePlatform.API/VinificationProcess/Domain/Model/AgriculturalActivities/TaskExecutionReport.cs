using System;
using System.Collections.Generic;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities
{
    public class TaskExecutionReport
    {
        public Guid ReportId { get; private set; }
        public Guid TaskId { get; set; }
        public Guid ExecutorId { get; private set; }
        public DateTime ExecutionDate { get; private set; }
        public string Observations { get; private set; }

        public List<EvidencePhoto> EvidencePhotos { get; private set; }

        public TaskExecutionReport(Guid reportId, Guid taskId, Guid executorId, DateTime executionDate, string observations = "")
        {
            ReportId = reportId;
            TaskId = taskId;
            ExecutorId = executorId;
            ExecutionDate = executionDate;
            Observations = observations;
            EvidencePhotos = new List<EvidencePhoto>();
        }

        public void AttachEvidence(string photoUrl)
        {
            if (string.IsNullOrWhiteSpace(photoUrl))
                throw new ArgumentException("URL de evidencia no válida.");
            EvidencePhotos.Add(new EvidencePhoto(Guid.NewGuid(), ReportId, photoUrl));
        }

        public void UpdateObservations(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            Observations = text;
        }

        public void SetTaskId(Guid taskId)
        {
            TaskId = taskId;
        }
    }
}
