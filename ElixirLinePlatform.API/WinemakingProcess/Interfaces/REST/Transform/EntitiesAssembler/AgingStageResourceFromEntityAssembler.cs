using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;

public static class AgingStageResourceFromEntityAssembler
{
    public static AgingStageResource? ToResourceFromEntity(WinemakingStage entity)
    {
        if (entity is not AgingStage aging)
            throw new ArgumentException("La etapa no es de tipo AgingStage.");

        return new AgingStageResource(
            aging.BatchId.ToString(),
            aging.StageType.ToString(),
            aging.StartedAt.ToString("dd-MM-yyyy"),
            aging.CompletedAt?.ToString("dd-MM-yyyy"),
            aging.CompletedBy,
            aging.Observations,
            aging.IsCompleted,
            aging.ContainerType,
            aging.Material,
            aging.ContainerCode,
            aging.AvgTemperature,
            aging.VolumeLiters,
            aging.DurationMonths,
            aging.FrequencyDays,
            aging.Refilled,
            aging.Batonnage,
            aging.Rackings,
            aging.Purpose
            );

    }
}




