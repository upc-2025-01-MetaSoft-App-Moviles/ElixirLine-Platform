using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class ClarificationStageResourceFromEntityAssembler
{
    public static ClarificationStageResource ToResourceFromEntity(WinemakingStage entity)
    {
        if (entity is not ClarificationStage clarification)
            throw new ArgumentException("La etapa no es de tipo ClarificationStage.");

        return new ClarificationStageResource(
            clarification.StageType.ToString(), 
            clarification.StartedAt.ToString(), 
            clarification.CompletedBy,
            clarification.Method,
            /*clarification.ClarifyingAgents,*/
            clarification.TurbidityBeforeNtu,
            clarification.TurbidityAfterNtu,
            clarification.VolumeLiters,
            clarification.Temperature,
            clarification.DurationHours,
            clarification.Observations
            );
            

    }
}

