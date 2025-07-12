namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;

public record AddClarificationStageResource( 
    string method,
    /*List<ClarifyingAgent> clarifyingAgents,*/
    double turbidityBeforeNtu,
    double turbidityAfterNtu,
    double volumeLiters,
    double temperature,
    double durationHours,
    string startedAt,
    string? completedBy,
    string? observations
);