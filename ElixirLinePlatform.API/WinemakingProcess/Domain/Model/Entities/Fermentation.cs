namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class Fermentation
{
    public int Id { get; set; }
    public decimal InitialTemperature { get; set; }
    public decimal MaxTemperature { get; set; }
    public decimal Duration { get; set; }                     // Days
    public string YeastType { get; set; } = string.Empty;
    public decimal InitialSugarLevel { get; set; }            // °Brix
    public decimal FinalSugarLevel { get; set; }              // °Brix
    public string Notes { get; set; } = string.Empty;
}