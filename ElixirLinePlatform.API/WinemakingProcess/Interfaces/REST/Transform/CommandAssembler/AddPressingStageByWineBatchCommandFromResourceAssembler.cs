using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.CommandStagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;
    

public static class AddPressingStageByWineBatchCommandFromResourceAssembler
{
    public static AddPressingStageCommand ToCommandFromResource(AddPressingStageResource resource)
    {
        return new AddPressingStageCommand(
            resource.pressType,
            resource.pressPressureBars,
            resource.durationMinutes,
            resource.pomaceKg,
            resource.yieldLiters,
            resource.mustUsage,
            resource.startedAt,
            resource.completedBy,
            resource.observations);
    }

    
}