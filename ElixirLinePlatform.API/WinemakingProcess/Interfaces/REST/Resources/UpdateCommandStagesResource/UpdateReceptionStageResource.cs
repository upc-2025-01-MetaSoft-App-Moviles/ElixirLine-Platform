namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

public record UpdateReceptionStageResource(
    string StartedAt, 
    string CompletedBy,
    bool IsCompleted,  
    double SugarLevel,
    double Ph, 
    double Temperature,
    double QuantityKg, 
    string Observations);