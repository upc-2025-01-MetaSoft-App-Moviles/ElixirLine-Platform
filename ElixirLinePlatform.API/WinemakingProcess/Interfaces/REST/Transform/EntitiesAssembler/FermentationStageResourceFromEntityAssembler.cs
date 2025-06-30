using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;

public static class FermentationStageResourceFromEntityAssembler
{
    public static FermentationStageResource? ToResourceFromEntity(WinemakingStage entity)
    {
        if (entity is not FermentationStage fermentation)
            throw new ArgumentException("La etapa no es de tipo ReceptionStage.");

        return new FermentationStageResource(
            fermentation.BatchId.ToString(),
            fermentation.StageType.ToString(),
            fermentation.StartedAt.ToString("dd-MM-yyyy"), // ISO 8601 format 
            fermentation.CompletedAt?.ToString("dd-MM-yyyy"),
            fermentation.CompletedBy,
            fermentation.IsCompleted,
            fermentation.YeastUsed,
            fermentation.InitialSugarLevel,
            fermentation.FinalSugarLevel,
            fermentation.InitialPh,
            fermentation.FinalPh,
            fermentation.TemperatureMax,
            fermentation.TemperatureMin,
            fermentation.FermentationType,
            fermentation.TankCode,
            fermentation.Observations
        );
  
    }
}