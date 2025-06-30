using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class AddClarificationStageByWineBatchCommandFromResourceAssembler
{
    public static AddClarificationStageCommand ToCommandFromResource(AddClarificationStageResource resource)
    {
        return new AddClarificationStageCommand(
            resource.method,
            resource.turbidityBeforeNtu,
            resource.turbidityAfterNtu,
            resource.volumeLiters,
            resource.temperature,
            resource.durationHours,
            resource.startedAt,
            resource.completedBy,
            resource.observations);
    }
}