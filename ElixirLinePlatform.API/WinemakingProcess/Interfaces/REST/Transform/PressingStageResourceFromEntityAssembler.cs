using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public class PressingStageResourceFromEntityAssembler
{
    public static PressingStageResource ToResourceFromEntity(WinemakingStage entity)
    {
        if (entity is not PressingStage pressing)
            throw new ArgumentException("La etapa no es de tipo ReceptionStage.");

        return new PressingStageResource(
            stageType: pressing.StageType.ToString(),
            startedAt: pressing.StartedAt.ToString("dd-MM-yyyy"), // ISO 8601 format
            pressType: pressing.PressType,
            pressPressureBars: pressing.PressPressureBars ?? 0,
            durationMinutes: pressing.DurationMinutes ?? 0,
            pomaceKg: pressing.PomaceKg ?? 0,
            yieldLiters: pressing.YieldLiters ?? 0,
            mustUsage: pressing.MustUsage,
            observations: pressing.Observations ?? string.Empty
            );
    }
}