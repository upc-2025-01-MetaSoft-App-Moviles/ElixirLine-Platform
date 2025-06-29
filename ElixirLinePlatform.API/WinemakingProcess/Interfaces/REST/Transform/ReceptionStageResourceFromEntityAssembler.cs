using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;
public static class ReceptionStageResourceFromEntityAssembler
{
    public static ReceptionStageResource ToResourceFromEntity(WinemakingStage entity)
    {
        if (entity is not ReceptionStage reception)
            throw new ArgumentException("La etapa no es de tipo ReceptionStage.");

        return new ReceptionStageResource(
            stageType: reception.StageType.ToString(),
            startedAt: reception.StartedAt.ToString("dd-MM-yyyy"),
            completedBy: reception.CompletedBy,
            sugarLevel: reception.SugarLevel ?? 0,
            pH: reception.PH ?? 0,
            temperature: reception.Temperature ?? 0,
            quantityKg: reception.QuantityKg ?? 0,
            observations: reception.Observations ?? string.Empty
        );
    }
}

