namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;

public record UpdateBottlingStageCommand(
    string StartedAt,
    string CompletedBy,
    string Observations,
    bool IsCompleted,
    string BottlingLine,
    int BottlesFilled,
    int BottleVolumeMl,
    double TotalVolumeLiters,
    string SealType,
    string Code,
    double Temperature,
    bool WasFiltered,
    bool WereLabelsApplied,
    bool WereCapsulesApplied);