using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;

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