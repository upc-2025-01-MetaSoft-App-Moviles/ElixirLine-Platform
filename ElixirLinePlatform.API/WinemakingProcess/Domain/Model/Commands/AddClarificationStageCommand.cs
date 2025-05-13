namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddClarificationStageCommand(
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
    string? observation);