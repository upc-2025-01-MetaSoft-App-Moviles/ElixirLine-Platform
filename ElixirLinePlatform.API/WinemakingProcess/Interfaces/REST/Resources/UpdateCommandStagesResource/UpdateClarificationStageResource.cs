namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

public record UpdateClarificationStageResource(
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