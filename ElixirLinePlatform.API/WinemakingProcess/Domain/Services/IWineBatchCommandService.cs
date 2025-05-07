using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Services;

public interface IWineBatchCommandService
{
    
    //=========== BATCH
    public Task<WineBatch?> Handle(CreateWineBatchCommand command);
    
    //=========== STAGE
    public Task<WineBatch?> Handle(AddReceptionStageCommand command, Guid WineBatchId);
    
}