﻿using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Repositories;

public interface IWineBatchRepository : IBaseRepository<WineBatch>
{
    //=========== WINE BATCH BY GUID
    Task<WineBatch> GetWineBatchByIdAsync(Guid id);
    
    //=========== GET RECEPTION STAGE BY GUID
    Task<ReceptionStage> GetReceptionStageByWineBatchIdAsync(Guid id);
    
    //=========== GET FERMENTATION STAGE BY GUID
    Task<FermentationStage> GetFermentationStageByWineBatchIdAsync(Guid id);
    
    //=========== GET PRESSING STAGE BY GUID
    Task<PressingStage> GetPressingStageByWineBatchIdAsync(Guid id);
    
    //=========== GET ALL STAGES BY WINE BATCH ID
    Task<IEnumerable<WinemakingStage>> GetAllStagesByWineBatchIdAsync(Guid id);
    
    //=========== GET CLARIFICATION STAGE BY GUID
    Task<ClarificationStage> GetClarificationStageByWineBatchIdAsync(Guid id);
    
    //=========== GET CORRECTION STAGE BY GUID
    Task<CorrectionStage> GetCorrectionStageByWineBatchIdAsync(Guid id);
    
    
}
