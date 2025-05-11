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
            reception.Id,
            reception.StartedAt.ToString("dd-MM-yyyy"),
            reception.CompletedBy,
            reception.SugarLevel,
            reception.PH,
            reception.Temperature,
            reception.WeightKg,
            reception.Observations
        );
    }
}

