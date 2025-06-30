using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class UpdateClarificationByWineBatchCommandFromResourceAssembler
{
    public static UpdateClarificationStageCommand ToCommandFromResource(UpdateClarificationStageResource resource)
    {
        return new UpdateClarificationStageCommand(
            resource.StartedAt, 
            resource.CompletedBy,
            resource.IsCompleted, 
            resource.Method, 
            /*resource.List<ClarifyingAgent> clarifyingAgents,*/
            resource.InitialTurbidityNtu,
            resource.FinalTurbidityNtu,
            resource.WineVolumeLitres,
            resource.Temperature,
            resource.DurationHours,
            resource.Observations);
    }
    
}


