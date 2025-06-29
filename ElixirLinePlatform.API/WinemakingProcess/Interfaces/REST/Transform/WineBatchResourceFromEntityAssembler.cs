using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class WineBatchResourceFromEntityAssembler
{
    public static WineBatchResource ToResourceFromEntity( WineBatch entity)
    {
        return new WineBatchResource(
            entity.Id,
            entity.CampaignId,
            entity.InternalCode,
            entity.HarvestCampaign,
            entity.VineyardOrigin,
            entity.GrapeVariety,
            entity.CreatedBy
            );
    }
    
}


