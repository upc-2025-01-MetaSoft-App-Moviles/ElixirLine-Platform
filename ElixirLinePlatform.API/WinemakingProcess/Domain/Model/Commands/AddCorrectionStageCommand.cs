namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record AddCorrectionStageCommand(
    string startedAt,
    string completedBy, 
    string initialSugarLevelBrix, 
    string finalSugarLevelBrix, 
    string addedSugarKg, 
    string initialPH, 
    string finalPH, 
    string addedAcidType, 
    string addedAcidGramsPerLitre, 
    string addedSO2MgPerLitre, 
    string addedYeastNutrients, 
    string correctionReason, 
    string observations
    );