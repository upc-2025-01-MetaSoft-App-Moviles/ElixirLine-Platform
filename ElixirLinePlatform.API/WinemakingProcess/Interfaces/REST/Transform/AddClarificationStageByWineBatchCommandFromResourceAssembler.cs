using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class AddClarificationStageByWineBatchCommandFromResourceAssembler
{
    public static AddClarificationStageCommand ToCommandFromResource(AddClarificationStageResource resource)
    {
        return new AddClarificationStageCommand(
            resource.startedAt,
            resource.completedBy,
            resource.clarificationMethod,
            resource.clarifyingAgent,
            resource.initialTurbidityNTU,
            resource.finalTurbidityNTU,
            resource.wineVolumeLitres,
            resource.contactTimeHours,
            resource.temperatureCelsius,
            resource.clarifyingAgentsUsed,
            resource.dosagePerAgent,
            resource.observation
        );
    }
}