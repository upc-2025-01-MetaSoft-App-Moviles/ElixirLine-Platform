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
            pressing.Id,
            pressing.StartedAt.ToString("dd-MM-yyyy"),
            pressing.PressType,
            pressing.MaxPressureBar,
            pressing.PressingDurationMinutes,
            pressing.GrapePomadeWeightKg,
            pressing.ExtractedLiters,
            pressing.IntendedWineUse,
            pressing.YieldPercentage,
            pressing.CompletedBy,
            pressing.Observations
            );
    }
}