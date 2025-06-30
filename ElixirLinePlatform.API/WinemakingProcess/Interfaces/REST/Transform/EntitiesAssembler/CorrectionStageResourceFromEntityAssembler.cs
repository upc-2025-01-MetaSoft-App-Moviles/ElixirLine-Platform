using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;

public static class CorrectionStageResourceFromEntityAssembler
{
    public static CorrectionStageResource? ToResourceFromEntity(WinemakingStage entity)
    {
        
        if (entity is not CorrectionStage correction)
            throw new ArgumentException("La etapa no es de tipo CorrectionStage.");
        
        return new CorrectionStageResource(
            correction.BatchId.ToString(),
            correction.StageType.ToString(),
            correction.StartedAt.ToString("dd-MM-yyyy"), 
            correction.CompletedAt?.ToString("dd-MM-yyyy"),
            correction.CompletedBy,
            correction.Observations,
            correction.IsCompleted,
            correction.InitialSugarLevel,
            correction.FinalSugarLevel,
            correction.AddedSugarKg,
            correction.InitialPh,
            correction.FinalPh,
            correction.AcidType,
            correction.AcidAddedGl,
            correction.So2AddedMgL,
            correction.Justification
        );
    }
    
}