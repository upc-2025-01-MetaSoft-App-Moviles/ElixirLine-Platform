using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class CreateWineBatchCommandFromResourceAssembler
{
    public static CreateWineBatchCommand ToCommandFromResource(CreateWineBatchResource resource)
    {
        return new CreateWineBatchCommand(
            resource.internalCode, 
            resource.receptionDate, 
            resource.campaign, 
            resource.vineyard, 
            resource.grapeVariety, 
            resource.createdBy, 
            resource.initialGrapeQuantityKg);
    }

}

