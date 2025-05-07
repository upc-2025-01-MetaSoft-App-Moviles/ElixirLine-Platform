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

    //=========== GET RECEPTION STAGE BY GUID
    public async  Task<ReceptionStage> GetReceptionStageByIdAsync(Guid id)
    {
        return await Context.Set<ReceptionStage>().FirstOrDefaultAsync(reception => reception.Id == id);
    }
}
