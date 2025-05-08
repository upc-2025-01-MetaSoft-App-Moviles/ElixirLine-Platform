using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Transform;

public static class WineBatchResourceFromEntityAssembler
{
    public static WineBatchResource ToResourceFromEntity( WineBatch entity)
    {
        return new WineBatchResource(
            entity.Id,
            entity.InternalCode,
            entity.ReceptionDate.ToString("dd-MM-yyyy"),
            entity.HarvestCampaign,
            entity.VineyardOrigin,
            entity.GrapeVariety,
            entity.CreatedBy,
            entity.InitialGrapeQuantityKg);
    }
    
}


