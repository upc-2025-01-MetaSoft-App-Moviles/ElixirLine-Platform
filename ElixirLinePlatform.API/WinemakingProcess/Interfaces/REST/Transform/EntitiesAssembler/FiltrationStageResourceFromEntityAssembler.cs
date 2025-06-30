using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;

public static class FiltrationStageResourceFromEntityAssembler
{
    public static FiltrationStageResource? ToResourceFromEntity(WinemakingStage entity)
    {
        if (entity is not FiltrationStage filtration)
            throw new ArgumentException("La etapa no es de tipo FiltrationStage.");

        return new FiltrationStageResource(
            filtration.BatchId.ToString(),
            filtration.StageType.ToString(),
            filtration.StartedAt.ToString("dd-MM-yyyy"),
            filtration.CompletedAt?.ToString("dd-MM-yyyy"),
            filtration.CompletedBy,
            filtration.Observations,
            filtration.IsCompleted,
            filtration.FiltrationType,
            filtration.FiltrationType,
            filtration.FilterMedia,
            filtration.PoreMicrons,
            filtration.TurbidityBefore,
            filtration.TurbidityAfter,
            filtration.Temperature,
            filtration.PressureBars,
            filtration.FilteredVolumeLiters,
            filtration.IsSterile,
            filtration.FilterChanged,
            filtration.ChangeReason
            );
        


    }
    
}

