using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class AddReceptionStageByWineBatchCommandFromResourceAssembler
{
    public static AddReceptionStageCommand ToCommandFromResource(AddReceptionStageResource resource)
    {
        return new AddReceptionStageCommand(
            resource.startedAt,
            resource.completedBy,
            resource.sugarLevel,
            resource.pH,
            resource.temperature,
            resource.weightKg,
            resource.observations);
    }
    
}