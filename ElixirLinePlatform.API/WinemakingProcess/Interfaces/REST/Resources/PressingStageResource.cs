namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record PressingStageResource(
    Guid id,
    string startedAt, 
    string pressType, 
    double maxPressureBar, 
    int pressingDurationMinutes,
    double grapePomadeWeightKg ,
    double extractedLiters, 
    string intendedWineUse, 
    double yieldPercentage, 
    string completedBy, 
    string observations
    );