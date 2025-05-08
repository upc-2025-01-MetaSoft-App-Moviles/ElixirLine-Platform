using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Queries;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Services;

public interface IWineBatchQueryService
{
    //=========== ALL BATCHES
    Task<IEnumerable<WineBatch>> Handle(GetAllWineBatchQuery query);
    
    //=========== GET BATCH BY GUID
    Task<WineBatch?> Handle(GetWineBatchByIdQuery query);
    
    //=========== GET RECEPTION STAGE BY ID
    Task<ReceptionStage?> Handle(GetReceptionStageByWineBatchIdQuery query);
    
    //=========== GET FERMENTATION STAGE BY ID
    Task<FermentationStage?> Handle(GetFermentationStageByWineBatchIdQuery query);
    
}