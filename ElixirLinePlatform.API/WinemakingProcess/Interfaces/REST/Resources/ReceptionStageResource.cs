namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record ReceptionStageResource(
    Guid id,
    string startedAt, 
    string completedBy,
    double sugarLevel, 
    double pH, 
    double temperature, 
    double weightKg,
    string observations);