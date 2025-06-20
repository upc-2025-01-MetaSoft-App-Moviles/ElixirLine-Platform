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
            clarification.Id,
            clarification.StartedAt.ToString("dd-MM-yyyy"),
            clarification.CompletedBy,
            clarification.ClarificationMethod,
            clarification.ClarifyingAgent,
            clarification.InitialTurbidityNTU,
            clarification.FinalTurbidityNTU,
            clarification.WineVolumeLitres,
            clarification.ContactTimeHours,
            clarification.TemperatureCelsius,
            clarification.ClarifyingAgentsUsed,
            clarification.DosagePerAgent,
            clarification.Observations
        );

    }
}