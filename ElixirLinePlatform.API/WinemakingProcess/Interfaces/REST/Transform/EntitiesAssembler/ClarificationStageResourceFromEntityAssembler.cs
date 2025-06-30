using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.EntitiesAssembler;

public static class ClarificationStageResourceFromEntityAssembler
{
    public static ClarificationStageResource? ToResourceFromEntity(WinemakingStage entity)
    {
        if (entity is not ClarificationStage clarification)
            throw new ArgumentException("La etapa no es de tipo ClarificationStage.");

        return new ClarificationStageResource(
            clarification.BatchId.ToString(),
            clarification.StageType.ToString(),
            clarification.StartedAt.ToString(), 
            clarification.CompletedAt?.ToString("dd-MM-yyyy"),
            clarification.CompletedBy,
            clarification.IsCompleted,
            clarification.Method,
            clarification.TurbidityBeforeNtu,
            clarification.TurbidityAfterNtu,
            clarification.VolumeLiters,
            clarification.Temperature,
            clarification.DurationHours,
            clarification.Observations);

    }
}

