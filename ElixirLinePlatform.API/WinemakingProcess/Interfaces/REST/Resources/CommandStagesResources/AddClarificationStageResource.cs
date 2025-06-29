namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.CommandStagesResources;

public record AddClarificationStageResource( 
    string method,
    /*List<ClarifyingAgent> clarifyingAgents,*/
    double turbidityBeforeNtu,
    double turbidityAfterNtu,
    double volumeLiters,
    double temperature,
    int durationHours,
    string startedAt,
    string? completedBy,
    string? observations
);