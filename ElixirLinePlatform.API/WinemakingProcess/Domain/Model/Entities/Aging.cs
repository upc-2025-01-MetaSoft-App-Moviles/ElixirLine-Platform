namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class Aging
{
    public int Id { get; set; }
    public string ContainerType { get; set; } = string.Empty;
    public string ContainerOrigin { get; set; } = string.Empty;
    public int Duration { get; set; }                         // Months
    public decimal Temperature { get; set; }
    public decimal Humidity { get; set; }                     // %
    public string Notes { get; set; } = string.Empty;
}