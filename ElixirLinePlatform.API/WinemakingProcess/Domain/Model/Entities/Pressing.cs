namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class Pressing
{
    public int Id { get; set; }
    public string PressType { get; set; } = string.Empty;
    public int Duration { get; set; }                         // Minutes
    public decimal MaxPressure { get; set; }                  // bar or psi
    public decimal Yield { get; set; }                        // Liters
    public string Notes { get; set; } = string.Empty;
}