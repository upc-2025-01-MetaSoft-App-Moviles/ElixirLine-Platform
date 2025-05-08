namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddReceptionStageResource(
    string startedAt, 
    double sugarLevel, 
    double pH, 
    double temperature, 
    double weightKg,
    string receivedBy, 
    string? observations);