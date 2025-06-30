using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform.CommandAssembler;

public static class UpdateWineBatchCommandFromResourceAssembler
{
    public static UpdateWineBatchCommand ToCommandFromResource(UpdateWineBatchResource resource)
    {
        return new UpdateWineBatchCommand(
            resource.InternalCode,
            resource.Campaign,
            resource.Vineyard,
            resource.GrapeVariety,
            resource.CreatedBy);
    }
    
}