namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class Bottling
{
    public int Id { get; set; }
    public string BottleType { get; set; } = string.Empty;
    public decimal VolumePerBottle { get; set; }              // mL
    public int BottleCount { get; set; }
    public string StopperType { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}