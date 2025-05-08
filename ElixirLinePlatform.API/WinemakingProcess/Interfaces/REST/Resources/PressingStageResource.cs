namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record PressingStageResource(
    Guid id,
    string startedAt,
    string pressType, 
    double maxPressureBar, 
    double extractedLiters, 
    double solidWasteKg, 
    double yieldPercentage);