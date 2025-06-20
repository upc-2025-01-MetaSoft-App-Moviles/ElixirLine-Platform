using System;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities
{
    public class EvidencePhoto
    {
        public Guid EvidencePhotoId { get; private set; }
        public Guid ReportId { get; private set; }
        public string PhotoUrl { get; private set; }

        public TaskExecutionReport? Report { get; private set; }

        public EvidencePhoto(Guid evidencePhotoId, Guid reportId, string photoUrl)
        {
            EvidencePhotoId = evidencePhotoId;
            ReportId = reportId;
            PhotoUrl = photoUrl ?? throw new ArgumentNullException(nameof(photoUrl));
        }
    }
}
