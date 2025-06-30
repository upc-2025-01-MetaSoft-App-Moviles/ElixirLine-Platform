namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;

public record AddReceptionStageResource(
    double sugarLevel, 
    double pH, 
    double temperature, 
    double quantityKg, 
    string startedAt, 
    string completedBy, 
    string observations
    );