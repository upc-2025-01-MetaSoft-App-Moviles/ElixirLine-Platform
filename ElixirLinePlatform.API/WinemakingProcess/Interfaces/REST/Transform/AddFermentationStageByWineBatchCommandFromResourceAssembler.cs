using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;


public static class AddFermentationStageByWineBatchCommandFromResourceAssembler
{

    public static AddFermentationStageCommand ToCommandFromResource(AddFermentationStageResource resource)
    {
        return new AddFermentationStageCommand(
            resource.startedAt,
            resource.completedBy,
            resource.yeastUsed,
            resource.initialSugarLevel,
            resource.temperature,
            resource.tankCode,
            resource.initialPH,
            resource.finalPH,
            resource.maxFermentationTempC,
            resource.minFermentationTempC,
            resource.fermentationType,
            resource.fermentationCompleted,
            resource.observations
        );
    }
}