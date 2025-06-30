using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class UpdateAgingStageByWineBatchCommandFromResourceAssembler
{
    public static UpdateAgingStageCommand ToCommandFromResource(UpdateAgingStageResource resource)
    {
        return new UpdateAgingStageCommand(
            resource.StartedAt,
            resource.CompletedBy,
            resource.Observations,
            resource.IsCompleted,
            resource.ContainerType,
            resource.Material,
            resource.ContainerCode,
            resource.AvgTemperature,
            resource.VolumeLiters,
            resource.DurationMonths,
            resource.FrequencyDays,
            resource.Refilled,
            resource.Batonnage,
            resource.Rackings,
            resource.Purpose);
    }
}


