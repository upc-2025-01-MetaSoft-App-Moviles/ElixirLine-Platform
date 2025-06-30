namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;

public record AddCorrectionStageResource( 
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
    string? Observations);