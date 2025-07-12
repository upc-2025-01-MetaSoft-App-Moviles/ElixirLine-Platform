namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;

public record AddClarificationStageCommand(
    string method,
    /*List<ClarifyingAgent> clarifyingAgents,*/
    double turbidityBeforeNtu,
    double turbidityAfterNtu,
    double volumeLiters,
    double temperature,
    double durationHours,
    string startedAt,
    string? completedBy,
    string? observations);
    
