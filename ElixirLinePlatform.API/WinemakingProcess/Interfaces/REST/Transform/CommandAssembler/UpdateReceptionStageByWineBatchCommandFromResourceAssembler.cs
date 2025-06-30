using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class UpdateReceptionStageByWineBatchCommandFromResourceAssembler
{
    public static UpdateReceptionStageCommand ToCommandFromResource(UpdateReceptionStageResource resource)
    {
        return new UpdateReceptionStageCommand(
            resource.StartedAt,
            resource.CompletedBy,
            resource.IsCompleted,
            resource.SugarLevel,
            resource.Ph,
            resource.Temperature,
            resource.QuantityKg,
            resource.Observations);
    }
    
}