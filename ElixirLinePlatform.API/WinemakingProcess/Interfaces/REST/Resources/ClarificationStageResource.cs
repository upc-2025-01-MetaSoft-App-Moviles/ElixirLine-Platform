namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record ClarificationStageResource(
    Guid Id, 
    string startedAt, 
    string completedBy, 
    string clarificationMethod, 
    string clarifyingAgent, 
    double initialTurbidityNTU, 
    double finalTurbidityNTU, 
    double wineVolumeLitres, 
    double contactTimeHours, 
    double temperatureCelsius, 
    string? clarifyingAgentsUsed, 
    string? dosagePerAgent, 
    string? observations
    );