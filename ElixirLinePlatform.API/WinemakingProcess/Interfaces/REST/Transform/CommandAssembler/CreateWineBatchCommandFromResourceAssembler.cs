using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.CommandStagesResources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class CreateWineBatchCommandFromResourceAssembler
{
    public static CreateWineBatchCommand ToCommandFromResource(CreateWineBatchResource resource)
    {
        return new CreateWineBatchCommand(
            resource.internalCode, 
            resource.campaign, 
            resource.vineyard, 
            resource.grapeVariety, 
            resource.createdBy);
    }

}

