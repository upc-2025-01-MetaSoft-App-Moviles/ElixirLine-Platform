using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;


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