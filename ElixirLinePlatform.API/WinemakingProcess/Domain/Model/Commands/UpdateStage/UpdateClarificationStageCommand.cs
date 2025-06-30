namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;

public record UpdateClarificationStageCommand(
    string StartedAt, 
    string CompletedBy,
    bool IsCompleted, 
    string Method, 
    /*List<ClarifyingAgent> clarifyingAgents,*/
    double InitialTurbidityNtu,
    double FinalTurbidityNtu,
    double WineVolumeLitres,
    double Temperature,
    int DurationHours,
    string Observations);