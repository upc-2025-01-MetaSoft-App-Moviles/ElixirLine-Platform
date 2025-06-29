using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;


public static class AddFermentationStageByWineBatchCommandFromResourceAssembler
{

    public static AddFermentationStageCommand ToCommandFromResource(AddFermentationStageResource resource)
    {
        return new AddFermentationStageCommand(
            resource.yeastUsed,
            resource.initialBrix,
            resource.finalBrix,
            resource.initialPh,
            resource.finalPh,
            resource.temperatureMax,
            resource.temperatureMin,
            resource.fermentationType,
            resource.tankCode,
            resource.startedAt,
            resource.completedBy,
            resource.observations);
    }
}