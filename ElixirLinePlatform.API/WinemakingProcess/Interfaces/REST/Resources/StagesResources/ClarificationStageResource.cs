namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

public record ClarificationStageResource(
    string batchId,
    string stageType,
    string startedAt, 
    string completedAt,
    string completedBy,
    bool isCompleted, 
    string method, 
    /*List<ClarifyingAgent> clarifyingAgents,*/
    double initialTurbidityNTU,
    double finalTurbidityNTU,
    double wineVolumeLitres,
    double temperature,
    int durationHours,
    string observations
    );