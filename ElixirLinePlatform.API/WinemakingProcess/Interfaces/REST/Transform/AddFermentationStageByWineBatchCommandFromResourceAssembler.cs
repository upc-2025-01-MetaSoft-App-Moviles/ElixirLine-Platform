using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;


public class AddFermentationStageByWineBatchCommandFromResourceAssembler
{
    
    public static AddFermentationStageCommand ToCommandFromResource(AddFermentationStageResource resource)
    {
        return new AddFermentationStageCommand(
            resource.startedAt, 
            resource.yeastUsed, 
            resource.initialSugarLevel, 
            resource.temperature,
            resource.malo, 
            resource.tankCode);
    }
    
}