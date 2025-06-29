namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddBottlingStageCommand( 
    string bottlingLine,
    int bottlesFilled,
    int bottleVolumeMl,
    double totalVolumeLiters,
    string sealType,
    string code,
    double temperature,
    bool wasFiltered,
    bool wereLabelsApplied,
    bool wereCapsulesApplied,
    string startedAt,
    string? completedBy,
    string? observations);