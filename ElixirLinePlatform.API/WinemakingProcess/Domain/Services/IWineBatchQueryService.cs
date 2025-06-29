using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Queries;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Services;

public interface IWineBatchQueryService
{
    //=========== ALL BATCHES
    Task<IEnumerable<WineBatch>> Handle(GetAllWineBatchQuery query);
    
    // ========== GET ALL STAGES BY BATCH ID
    Task<IEnumerable<WinemakingStage>> Handle(GetAllStagesByWineBatchIdQuery query);
    
    
    
    //=========== GET BATCH BY GUID
    Task<WineBatch?> Handle(GetWineBatchByIdQuery query);
    
    //=========== GET RECEPTION STAGE BY ID
    Task<ReceptionStage?> Handle(GetReceptionStageByWineBatchIdQuery query);
    
    //=========== GET FERMENTATION STAGE BY ID
    Task<FermentationStage?> Handle(GetFermentationStageByWineBatchIdQuery query);
    
    //=========== GET PRESSING STAGE BY ID
    Task<PressingStage?> Handle(GetPressingStageByWineBatchIdQuery query);
    
    //=========== GET CLARIFICATION STAGE BY ID
    Task<ClarificationStage?> Handle(GetClarificationStageByWineBatchIdQuery query);
    
    //=========== GET CORRECTION STAGE BY ID
    Task<CorrectionStage?> Handle(GetCorrectionStageByWineBatchIdQuery query);
    
    //=========== GET FILTRATION STAGE BY ID
    Task<FiltrationStage?> Handle(GetFiltrationStageByWineBatchIdQuery query);
    
    
    //=========== GET BOTTLING STAGE BY ID
    Task<BottlingStage?> Handle(GetBottlingStageByWineBatchIdQuery query);

}