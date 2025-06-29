namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record ReceptionStageResource(
    string stageType,
    string startedAt, 
    string completedBy,
    double sugarLevel,
    double pH, 
    double temperature,
    double quantityKg, 
    string observations);