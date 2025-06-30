namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;

public record UpdateCorrectionStageCommand(
    string StartedAt,
    string CompletedBy,
    string Observations,
    bool IsCompleted,
    double InitialSugarLevel,
    double FinalSugarLevel,
    double AddedSugarKg,
    double InitialPh,
    double FinalPh,
    string AcidType,
    double AcidAddedGl,
    double So2AddedMgL,
    string Justification);