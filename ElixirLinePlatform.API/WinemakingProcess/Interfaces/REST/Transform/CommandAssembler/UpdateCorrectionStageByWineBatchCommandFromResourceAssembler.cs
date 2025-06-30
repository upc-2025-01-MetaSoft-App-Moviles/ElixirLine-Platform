using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class UpdateCorrectionStageByWineBatchCommandFromResourceAssembler
{
    public static UpdateCorrectionStageCommand ToCommandFromResource(UpdateCorrectionStageResource resource)
    {
        return new UpdateCorrectionStageCommand(
            resource.StartedAt,
            resource.CompletedBy,
            resource.Observations,
            resource.IsCompleted,
            resource.InitialSugarLevel,
            resource.FinalSugarLevel,
            resource.AddedSugarKg,
            resource.InitialPh,
            resource.FinalPh,
            resource.AcidType,
            resource.AcidAddedGl,
            resource.So2AddedMgL,
            resource.Justification);
    }
}

