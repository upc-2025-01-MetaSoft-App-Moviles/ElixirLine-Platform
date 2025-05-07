using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Repositories;

public interface IWineBatchRepository : IBaseRepository<WineBatch>
{
    //=========== WINE BATCH BY GUID
    Task<WineBatch> GetWineBatchByIdAsync(Guid id);
    //=========== GET RECEPTION STAGE BY GUID
    Task<ReceptionStage> GetReceptionStageByIdAsync(Guid id);
}
