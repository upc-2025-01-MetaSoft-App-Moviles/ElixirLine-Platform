namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddPressingStageCommand(
    string startedAt, 
    string pressType, 
    double maxPressureBar, 
    double extractedLiters, 
    double solidWasteKg, 
    double yieldPercentage);