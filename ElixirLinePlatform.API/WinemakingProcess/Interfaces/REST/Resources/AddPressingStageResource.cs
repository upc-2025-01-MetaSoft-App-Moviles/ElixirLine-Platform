namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddPressingStageResource(
    string startedAt, 
    string pressType, 
    double maxPressureBar, 
    double extractedLiters, 
    double solidWasteKg, 
    double yieldPercentage);