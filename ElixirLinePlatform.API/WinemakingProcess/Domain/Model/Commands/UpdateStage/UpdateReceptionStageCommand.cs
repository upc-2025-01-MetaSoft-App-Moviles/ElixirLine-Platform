namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;

public record UpdateReceptionStageCommand(
    string StartedAt, 
    string CompletedBy,
    bool IsCompleted,  
    double SugarLevel,
    double Ph, 
    double Temperature,
    double QuantityKg, 
    string Observations);
    