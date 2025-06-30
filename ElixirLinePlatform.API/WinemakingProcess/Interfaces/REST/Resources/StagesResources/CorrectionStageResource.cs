namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

public record CorrectionStageResource(
    string BatchId,
    string StageType,
    string StartedAt,
    string CompletedAt,
    string CompletedBy,
    string Observations,
    bool IsCompleted,
    double InitialSugarLevel,
    double FinalSugarLevel,
    double AddedSugarKg,
    double FinalPh,
    double InitialPh,
    string AcidType,
    double AcidAddedGl,
    double So2AddedMgL,
    string Justification);
    

    
