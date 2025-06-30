using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class AddBottlingStageByWineBatchCommandFromResourceAssembler
{
    public static AddBottlingStageCommand ToCommandFromResource(AddBottlingStageResource resource)
    {
        return new AddBottlingStageCommand(
            resource.bottlingLine,
            resource.bottlesFilled,
            resource.bottleVolumeMl,
            resource.totalVolumeLiters,
            resource.sealType,
            resource.code,
            resource.temperature,
            resource.wasFiltered,
            resource.wereLabelsApplied,
            resource.wereCapsulesApplied,
            resource.startedAt,
            resource.completedBy,
            resource.observations
            );
    }
    
}

