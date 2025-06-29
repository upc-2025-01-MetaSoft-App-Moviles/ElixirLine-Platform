namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record ClarificationStageResource(
    string stageType,
    string startedAt, 
    string completedBy, 
    string method, 
    /*List<ClarifyingAgent> clarifyingAgents,*/
    double initialTurbidityNTU,
    double finalTurbidityNTU,
    double wineVolumeLitres,
    double temperature,
    int durationHours,
    string? observations
    );