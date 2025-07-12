namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

public record ClarificationStageResource(
    string BatchId,
    string StageType,
    string StartedAt, 
    string CompletedAt,
    string CompletedBy,
    bool IsCompleted, 
    string Method, 
    /*List<ClarifyingAgent> clarifyingAgents,*/
    double InitialTurbidityNtu,
    double FinalTurbidityNtu,
    double WineVolumeLitres,
    double Temperature,
    double DurationHours,
    string Observations
    );