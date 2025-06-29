using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;

public class PressingStageResourceFromEntityAssembler
{
    public static PressingStageResource ToResourceFromEntity(WinemakingStage entity)
    {
        if (entity is not PressingStage pressing)
            throw new ArgumentException("La etapa no es de tipo ReceptionStage.");

        return new PressingStageResource(
            pressing.BatchId.ToString(),
            pressing.StageType.ToString(),
            pressing.StartedAt.ToString("dd-MM-yyyy"), // ISO 8601 format 
            pressing.CompletedAt.ToString(), // ISO 8601 format
            pressing.CompletedBy,
            pressing.IsCompleted,
            pressing.PressType,
            pressing.PressPressureBars,
            pressing.DurationMinutes,
            pressing.PomaceKg,
            pressing.YieldLiters,
            pressing.MustUsage,
            pressing.Observations
        );
    }
}