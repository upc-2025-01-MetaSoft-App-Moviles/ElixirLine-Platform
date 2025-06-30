using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class UpdatePressingStageByWineBatchCommandFromResourceAssembler
{
    public static UpdatePressingStageCommand ToCommandFromResource(UpdatePressingStageResource resource)
    {
        return new UpdatePressingStageCommand(
            resource.StartedAt, 
            resource.CompletedBy,
            resource.IsCompleted,  
            resource.PressType, 
            resource.PressPressureBars, 
            resource.DurationMinutes, 
            resource.PomaceKg, 
            resource.YieldLiters, 
            resource.MustUsage, 
            resource.Observations);
    }
}


