namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

public record UpdateCorrectionStageResource(
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