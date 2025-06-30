using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;

public static class BottlingStageResourceFromEntityAssembler
{
    public static BottlingStageResource? ToResourceFromEntity(WinemakingStage entity)
    {
        if (entity is not BottlingStage bottling)
            throw new ArgumentException("La etapa no es de tipo BottlingStage.");

        return new BottlingStageResource(
            bottling.BatchId.ToString(),
            bottling.StageType.ToString(),
            bottling.StartedAt.ToString("dd-MM-yyyy"), 
            bottling.CompletedAt?.ToString("dd-MM-yyyy"),
            bottling.CompletedBy,
            bottling.Observations,
            bottling.IsCompleted,
            bottling.BottlingLine,
            bottling.BottlesFilled,
            bottling.BottleVolumeMl,
            bottling.TotalVolumeLiters,
            bottling.SealType,
            bottling.Code,
            bottling.Temperature,
            bottling.WasFiltered,
            bottling.WereLabelsApplied,
            bottling.WereCapsulesApplied
        );
    }

}


