using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class AddAgingStageByWineBatchCommandFromResourceAssembler
{
    public static AddAgingStageCommand ToCommandFromResource(AddAgingStageResource resource)
    {
        return new AddAgingStageCommand(
            resource.containerType,
            resource.material,
            resource.containerCode,
            resource.avgTemperature,
            resource.volumeLiters,
            resource.durationMonths,
            resource.frequencyDays,
            resource.refilled,
            resource.batonnage,
            resource.rackings,
            resource.purpose,
            resource.startedAt, 
            resource.completedBy,
            resource.observations);
    }
    
}


