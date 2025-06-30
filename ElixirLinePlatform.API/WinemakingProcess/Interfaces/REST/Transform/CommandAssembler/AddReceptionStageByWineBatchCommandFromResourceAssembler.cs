using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class AddReceptionStageByWineBatchCommandFromResourceAssembler
{
    public static AddReceptionStageCommand ToCommandFromResource(AddReceptionStageResource resource)
    {
        return new AddReceptionStageCommand(
            resource.sugarLevel,
            resource.pH,
            resource.temperature,
            resource.quantityKg,
            resource.startedAt,
            resource.completedBy,
            resource.observations);
    }
    
}