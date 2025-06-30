using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class AddFiltrationStageByWineBatchCommandFromResourceAssembler
{
    public static AddFiltrationStageCommand ToCommandFromResource(AddFiltrationStageResource resource)
    {
        return new AddFiltrationStageCommand(
            resource.filtrationType,
            resource.filterMedia,
            resource.poreMicrons,
            resource.turbidityBefore,
            resource.turbidityAfter, 
            resource.temperature, 
            resource.pressureBars, 
            resource.filteredVolumeLiters, 
            resource.isSterile, 
            resource.filterChanged, 
            resource.changeReason, 
            resource.startedAt, 
            resource.completedBy, 
            resource.observations);
    }
    
}


