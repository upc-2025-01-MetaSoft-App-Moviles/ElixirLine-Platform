using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class UpdateBottlingStageByWineBatchCommandFromResourceAssembler
{
    public static UpdateBottlingStageCommand ToCommandFromResource(UpdateBottlingStageResource resource)
    {
        return new UpdateBottlingStageCommand(
            resource.StartedAt,
            resource.CompletedBy,
            resource.Observations,
            resource.IsCompleted,
            resource.BottlingLine,
            resource.BottlesFilled,
            resource.BottleVolumeMl,
            resource.TotalVolumeLiters,
            resource.SealType,
            resource.Code,
            resource.Temperature,
            resource.WasFiltered,
            resource.WereLabelsApplied,
            resource.WereCapsulesApplied);
    }
    
}


