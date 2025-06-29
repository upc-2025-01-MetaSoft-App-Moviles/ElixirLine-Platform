namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddClarificationStageResource( 
    string startedAt, 
    string completedBy, 
    string method,
    /*List<ClarifyingAgent> clarifyingAgents,*/
    double turbidityBeforeNtu,
    double turbidityAfterNtu,
    double volumeLiters,
    double temperature,
    int durationHours,
    string? observations
);