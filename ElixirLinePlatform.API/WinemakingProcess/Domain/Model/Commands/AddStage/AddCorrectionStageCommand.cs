namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;

public record AddCorrectionStageCommand(
    double InitialSugarLevel,
    double FinalSugarLevel,
    double AddedSugarKg,
    double InitialPh,
    double FinalPh,
    string AcidType,
    double AcidAddedGl,
    double So2AddedMgL,
    /*List<Nutrient> nutrientsAdded,*/
    string Justification,
    string StartedAt,
    string? CompletedBy,
    string? Observations
    );