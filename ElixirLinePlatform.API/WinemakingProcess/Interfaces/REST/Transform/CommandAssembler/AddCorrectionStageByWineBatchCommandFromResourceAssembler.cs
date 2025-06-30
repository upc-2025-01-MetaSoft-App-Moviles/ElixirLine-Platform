using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class AddCorrectionStageByWineBatchCommandFromResourceAssembler
{
    public static AddCorrectionStageCommand ToCommandFromResource(AddCorrectionStageResource resource)
    {
        return new AddCorrectionStageCommand(
            resource.InitialSugarLevel,
            resource.FinalSugarLevel,
            resource.AddedSugarKg,
            resource.InitialPh,
            resource.FinalPh,
            resource.AcidType,
            resource.AcidAddedGl,
            resource.So2AddedMgL,
            /*resource.List<Nutrient> nutrientsAdded,*/
            resource.Justification,
            resource.StartedAt,
            resource.CompletedBy,
            resource.Observations);
    }
    
}


