namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddClarificationStageCommand(
    string method,
    /*List<ClarifyingAgent> clarifyingAgents,*/
    double turbidityBeforeNtu,
    double turbidityAfterNtu,
    double volumeLiters,
    double temperature,
    int durationHours,
    string startedAt,
    string? completedBy,
    string? observations);