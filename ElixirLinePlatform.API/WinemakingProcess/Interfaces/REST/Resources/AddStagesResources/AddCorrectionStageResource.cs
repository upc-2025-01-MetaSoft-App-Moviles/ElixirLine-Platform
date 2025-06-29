namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddCorrectionStageResource( 
    double initialSugarLevel,
    double finalSugarLevel,
    double addedSugarKg,
    double initialPh,
    double finalPh,
    string acidType,
    double acidAddedGl,
    double so2AddedMgL,
    /*List<Nutrient> nutrientsAdded,*/
    string justification,
    string startedAt,
    string? completedBy,
    string? observations);