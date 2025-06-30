using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class UpdateFermentationByWineBatchCommandFromResourceAssembler
{
    public static UpdateFermentationStageCommand ToCommandFromResource(UpdateFermentationStageResource resource)
    {
        return new UpdateFermentationStageCommand(
            resource.StartedAt, 
            resource.CompletedAt,
            resource.CompletedBy,
            resource.IsCompleted, 
            resource.YeastUsed,
            resource.InitialSugarLevel,
            resource.FinalSugarLevel,
            resource.InitialPh,
            resource.FinalPh,
            resource.TemperatureMin,
            resource.TemperatureMax,
            resource.FermentationType,
            resource.TankCode,
            resource.Observations);
    }
    
}

