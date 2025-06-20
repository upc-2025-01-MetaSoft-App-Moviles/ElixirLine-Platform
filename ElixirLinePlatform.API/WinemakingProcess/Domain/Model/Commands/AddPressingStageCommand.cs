namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddPressingStageCommand(
    string startedAt, 
    string pressType, 
    double maxPressureBar, 
    int pressingDurationMinutes,
    double grapePomadeWeightKg ,
    double extractedLiters, 
    string intendedWineUse, 
    double yieldPercentage, 
    string completedBy, 
    string observations);