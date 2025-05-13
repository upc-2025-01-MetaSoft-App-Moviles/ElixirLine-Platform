using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElixirLinePlatform.API.WinemakingProcess.Infrastructure.Persistence.EFC.Repositories;

public class WineBatchRepository(AppDbContext context):  BaseRepository<WineBatch>(context), IWineBatchRepository
{
    private IWineBatchRepository _wineBatchRepositoryImplementation;

    //=========== WINE BATCH BY GUID 
    public async Task<WineBatch> GetWineBatchByIdAsync(Guid id)
    {
        return await Context.Set<WineBatch>().FirstOrDefaultAsync(wineBatch => wineBatch.Id == id);
    }
    
    // =========== WINE ALL STAGES BY WINE BATCH GUID
    public async Task<IEnumerable<WinemakingStage>> GetAllStagesByWineBatchIdAsync(Guid id)
    {
        //Para devolver una lista de objetos de tipo WinemakingStage, debo verificar si el objeto WineBatch existe
        var wineBatch = await Context.Set<WineBatch>()
            .Include(w => w.WinemakingStages)
            .FirstOrDefaultAsync(wineBatch => wineBatch.Id == id);
        
        if (wineBatch == null)
        {
            throw new Exception("Lote de vino no encontrado.");
        }
        
        // Si el objeto existe, devuelvo la lista de etapas de vinificación que se encuentra en el objeto WineBatch
        var winemakingStages = wineBatch.WinemakingStages;
        
        // Verificar si la lista de etapas de vinificación es nula o está vacía y mostrar un mensaje
        if (winemakingStages == null || !winemakingStages.Any())
        {
            throw new Exception("No hay etapas de vinificación disponibles para este lote de vino.");
        }
        
        
        // Devolver la lista de etapas de vinificación
        return winemakingStages;
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
    
    // ========== GET CLARIFICATION STAGE BY WINE BATCH GUID
    public async Task<ClarificationStage> GetClarificationStageByWineBatchIdAsync(Guid id)
    {
        //Para devolver un objeto de tipo ClarificationStage, debo buscarlo en una lista de tipo WinemakingStage que se encuentra en el objeto WineBatch
        var wineBatch = await Context.Set<WineBatch>()
            .Include(w => w.WinemakingStages)
            .FirstOrDefaultAsync(wineBatch => wineBatch.Id == id);

        if (wineBatch == null)
        {
            return null; // O lanzar una excepción si lo prefieres
        }
        
        // Buscar la etapa de clarificación en la lista de etapas del lote de vino
        var clarificationStage = wineBatch.WinemakingStages
            .OfType<ClarificationStage>()
            .FirstOrDefault();
        
        return clarificationStage;
    }

   
}
