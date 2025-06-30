using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Services;

public interface IWineBatchCommandService
{
    
    //=========== BATCH
    // Creating a new wine batch
    public Task<WineBatch?> Handle(CreateWineBatchCommand command);
    
    // RECEPTION STAGE ===================================================================
    // Adding reception stage to a wine batch
    public Task<ReceptionStage?> Handle(AddReceptionStageCommand command, Guid wineBatchId);
    
    // Updating the reception stage of a wine batch
    public Task<ReceptionStage?> Handle(UpdateReceptionStageCommand command, Guid wineBatchId);
    
    // ====================================================================================
    
    
    // CORRECTION STAGE ====================================================================
    // Adding correction stage to a wine batch
    public Task<CorrectionStage?> Handle(AddCorrectionStageCommand command, Guid wineBatchId);
    
    // Updating the correction stage of a wine batch
    public Task<CorrectionStage?> Handle(UpdateCorrectionStageCommand command, Guid wineBatchId);
    
    // ====================================================================================
    

    // PRESSING STAGE ====================================================================
    // Adding pressing stage to a wine batch
    public Task<PressingStage?> Handle(AddPressingStageCommand command, Guid wineBatchId);
    
    // Updating the pressing stage of a wine batch
    public Task<PressingStage?> Handle(UpdatePressingStageCommand command, Guid wineBatchId);
    
    // ====================================================================================

        
    // CLARIFICATION STAGE ====================================================================
    // Adding clarification stage to a wine batch
    public Task<ClarificationStage?> Handle(AddClarificationStageCommand command, Guid wineBatchId);
    
    // Updating the clarification stage of a wine batch
    public Task<ClarificationStage?> Handle(UpdateClarificationStageCommand command, Guid wineBatchId);
    
    // ==========================================================================================
    
    
    
    // FERMENTATION STAGE =====================================================================
    // Adding fermentation stage to a wine batch
    public Task<FermentationStage?> Handle(AddFermentationStageCommand command, Guid wineBatchId);
    
    // Updating the fermentation stage of a wine batch
    public Task<FermentationStage?> Handle(UpdateFermentationStageCommand command, Guid wineBatchId);
    
    // ==========================================================================================
    
    
    
    
    // AGING STAGE ========================================================================================
    // Adding aging stage to a wine batch   
    public Task<AgingStage?> Handle(AddAgingStageCommand command, Guid wineBatchId);
    
    // Updating the aging stage of a wine batch
    public Task<AgingStage?> Handle(UpdateAgingStageCommand command, Guid wineBatchId);
    
    // ====================================================================================================
    
    // FILTRATION STAGE ========================================================================================
    // Adding filtration stage to a wine batch
    public Task<FiltrationStage?> Handle(AddFiltrationStageCommand command, Guid wineBatchId);
    // Updating the filtration stage of a wine batch
    public Task<FiltrationStage?> Handle(UpdateFiltrationStageCommand command, Guid wineBatchId);
    
    // ==========================================================================================================
    
    
    // BOTTLING STAGE =========================================================================================
    // Adding bottling stage to a wine batch
    public Task<BottlingStage?> Handle(AddBottlingStageCommand command, Guid wineBatchId);
    
    // Updating the bottling stage of a wine batch
    public Task<BottlingStage?> Handle(UpdateBottlingStageCommand command, Guid wineBatchId);
    
    // ==========================================================================================================
    
}