using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class UpdateFiltrationStageByWineBatchCommandFromResourceAssembler
{
    public static UpdateFiltrationStageCommand ToCommandFromResource(UpdateFiltrationStageResource resource)
    {
        return new UpdateFiltrationStageCommand(
            resource.StartedAt,
            resource.CompletedBy,
            resource.Observations,
            resource.IsCompleted,
            resource.FilterType,
            resource.FilterMedia,
            resource.PoreMicrons,
            resource.TurbidityBefore,
            resource.TurbidityAfter,
            resource.Temperature,
            resource.PressureBars,
            resource.FilteredVolumeLiters,
            resource.IsSterile,
            resource.FilterChanged,
            resource.ChangeReason);
    }
    
}

