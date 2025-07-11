using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;

namespace ElixirLinePlatform.API.VinificationProcess.Interfaces.REST.Resources;

public class CreateParcelRequest
{
    public Guid ParcelId { get; set; }
    public string Name { get; set; }
    public double Area { get; set; }
    public string CropType { get; set; }
    public string Location { get; set; }
    public TaskStage Stage { get; set; }
}