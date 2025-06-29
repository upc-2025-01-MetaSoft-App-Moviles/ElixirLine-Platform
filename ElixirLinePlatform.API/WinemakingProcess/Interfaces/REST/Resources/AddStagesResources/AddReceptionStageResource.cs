namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddReceptionStageResource(
    double? sugarLevel, 
    double? pH, 
    double? temperature, 
    double? quantityKg, 
    string startedAt, 
    string? completedBy, 
    string? observations
    );