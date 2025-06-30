using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;
public static class ReceptionStageResourceFromEntityAssembler
{
    public static ReceptionStageResource? ToResourceFromEntity(WinemakingStage entity)
    {
        if (entity is not ReceptionStage reception)
            throw new ArgumentException("La etapa no es de tipo ReceptionStage.");

        return new ReceptionStageResource(
            reception.BatchId.ToString(),
            reception.StageType.ToString(),
            reception.StartedAt.ToString("dd-MM-yyyy"), // ISO 8601 format 
            reception.CompletedAt?.ToString("dd-MM-yyyy"),
            reception.CompletedBy,
            reception.IsCompleted,
            reception.SugarLevel,
            reception.PH,
            reception.Temperature,
            reception.QuantityKg,
            reception.Observations
        );
        
        
    }
}

