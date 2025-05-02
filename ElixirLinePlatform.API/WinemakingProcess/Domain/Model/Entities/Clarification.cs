namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class Clarification
{
    public int Id { get; set; }
    public string Method { get; set; } = string.Empty;
    public string ClarifyingAgent { get; set; } = string.Empty;
    public decimal AgentAmount { get; set; }                  // g/L
    public int SedimentationTime { get; set; }                // Hours or days
    public string Notes { get; set; } = string.Empty;
}