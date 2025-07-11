using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;

namespace ElixirLinePlatform.API.VinificationProcess.Interfaces.REST.Resources;

public class CreateAgriculturalTaskRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ParcelId { get; set; }
    public Guid AssignedTo { get; set; }
    public DateTime ScheduledDate { get; set; }
    public TaskStage Stage { get; set; }
}
