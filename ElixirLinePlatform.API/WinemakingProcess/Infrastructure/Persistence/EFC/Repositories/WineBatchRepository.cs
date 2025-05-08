using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElixirLinePlatform.API.WinemakingProcess.Infrastructure.Persistence.EFC.Repositories;

public class WineBatchRepository(AppDbContext context):  BaseRepository<WineBatch>(context), IWineBatchRepository
{
    //=========== WINE BATCH BY GUID 
    public async Task<WineBatch> GetWineBatchByIdAsync(Guid id)
    {
        return await Context.Set<WineBatch>().FirstOrDefaultAsync(wineBatch => wineBatch.Id == id);
    }

    //=========== GET RECEPTION STAGE BY WINE BATCH GUID
    public async Task<ReceptionStage?> GetReceptionStageByWineBatchIdAsync(Guid wineBatchId)
    {
        //Para devolver un objeto de tipo ReceptionStage, debo buscarlo en una lista de tipo WinemakingStage que se encuentra en el objeto WineBatch
        var wineBatch = await Context.Set<WineBatch>()
            .Include(w => w.WinemakingStages)
            .FirstOrDefaultAsync(wineBatch => wineBatch.Id == wineBatchId);
        
        if (wineBatch == null) 
        {
            return null; // O lanzar una excepción si lo prefieres
        }
        
        // Buscar la etapa de recepción en la lista de etapas del lote de vino
        var receptionStage = wineBatch.WinemakingStages
            .OfType<ReceptionStage>()
            .FirstOrDefault();
        return receptionStage;
    }
    
    
    // ========== GET FERMENTATION STAGE BY WINE BATCH GUID
    public async Task<FermentationStage?> GetFermentationStageByWineBatchIdAsync(Guid id)
    {
        //Para devolver un objeto de tipo FermentationStage, debo buscarlo en una lista de tipo WinemakingStage que se encuentra en el objeto WineBatch
        var wineBatch = await Context.Set<WineBatch>()
            .Include(w => w.WinemakingStages)
            .FirstOrDefaultAsync(wineBatch => wineBatch.Id == id);
        
        if (wineBatch == null) 
        {
            return null; // O lanzar una excepción si lo prefieres
        }
        
        // Buscar la etapa de fermentación en la lista de etapas del lote de vino
        var fermentationStage = wineBatch.WinemakingStages.OfType<FermentationStage>().FirstOrDefault();
        
        return fermentationStage;
    }

    // ========== GET PRESSING STAGE BY WINE BATCH GUID
    public async Task<PressingStage> GetPressingStageByWineBatchIdAsync(Guid id)
    {
        //Para devolver un objeto de tipo PressingStage, debo buscarlo en una lista de tipo WinemakingStage que se encuentra en el objeto WineBatch
        var wineBatch = await Context.Set<WineBatch>()
            .Include(w => w.WinemakingStages)
            .FirstOrDefaultAsync(wineBatch => wineBatch.Id == id);

        if (wineBatch == null)
        {
            return null; // O lanzar una excepción si lo prefieres
        }
        
        // Buscar la etapa de prensado en la lista de etapas del lote de vino
        var pressingStage = wineBatch.WinemakingStages
            .OfType<PressingStage>()
            .FirstOrDefault();
        
        return pressingStage;
    }
}
