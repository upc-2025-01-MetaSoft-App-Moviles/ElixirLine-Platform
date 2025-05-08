using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Services;

public interface IWineBatchCommandService
{
    
    //=========== BATCH
    // Creating a new wine batch
    public Task<WineBatch?> Handle(CreateWineBatchCommand command);
    
    //=========== RECEPTION STAGE
    // Adding reception stage to a wine batch
    public Task<ReceptionStage?> Handle(AddReceptionStageCommand command, Guid WineBatchId);
    
    //=========== FERMENTATION STAGE
    // Adding fermentation stage to a wine batch
    public Task<FermentationStage?> Handle(AddFermentationStageCommand command, Guid WineBatchId);
    
    //=========== PRESSING STAGE
    // Adding pressing stage to a wine batch
    public Task<PressingStage?> Handle(AddPressingStageCommand command, Guid WineBatchId);
    
}