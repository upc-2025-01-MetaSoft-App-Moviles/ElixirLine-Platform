namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddCorrectionStageCommand(
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
    string? observations
    );