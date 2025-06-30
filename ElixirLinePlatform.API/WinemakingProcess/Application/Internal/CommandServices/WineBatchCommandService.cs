using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Repositories;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;

namespace ElixirLinePlatform.API.WinemakingProcess.Application.Internal.CommandServices;

public class WineBatchCommandService(IWineBatchRepository wineBatchRepository, IUnitOfWork unitOfWork) : IWineBatchCommandService
{

    // ============= CREAR LOTE DE VINO
    // Creating a new wine batch
    public async Task<WineBatch?> Handle(CreateWineBatchCommand command)
    {
        var wineBatch = new WineBatch(command);

        await wineBatchRepository.AddAsync(wineBatch);
        await unitOfWork.CompleteAsync();
        return wineBatch;
    }
    
    // Updating an existing wine batch
    public async Task<WineBatch?> Handle(UpdateWineBatchCommand command, Guid wineBatchId)
    {
        // 1. Recuperar lote
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);
        if (wineBatch is null)
            throw new InvalidOperationException("Wine batch not found.");

        // 2. Actualizar propiedades del lote
        wineBatch.Update(command); // método definido en WineBatch

        // 3. Persistir cambios
        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return wineBatch;
    }

    
    
    //=========== RECEPTION STAGE ====================================================================
    // Adding reception stage to a wine batch
    public async Task<ReceptionStage?> Handle(AddReceptionStageCommand command, Guid WineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(WineBatchId);

        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");

       

        // Crear la etapa de recepción
        var receptionStage = new ReceptionStage(command);
        

      

        // Agregar la etapa de recepción al lote de vino
        wineBatch.AddStage(receptionStage);


        // Guardar los cambios en el repositorio
        wineBatchRepository.Update(wineBatch);

        await unitOfWork.CompleteAsync();

        return receptionStage;
    }
    
    // Update the reception stage of a wine batch
    public async Task<ReceptionStage?> Handle(UpdateReceptionStageCommand command, Guid wineBatchId)
    {
        // 1. Recuperar lote
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);
        if (wineBatch is null)
            throw new InvalidOperationException("Wine batch not found.");

        // 2. Obtener la etapa de recepción (recomendado usar método del agregado)
        var stage = wineBatch.GetStage(StageType.Reception) as ReceptionStage;

        if (stage is null)
            throw new InvalidOperationException("Reception stage not found for the specified wine batch.");

        // 3. Actualizar la etapa
        stage.Update(command); // método definido en ReceptionStage

        // 4. Persistir cambios
        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return stage;
    }

    
    // ================================================================================================
    
    
    
    

    
    //=========== CORRECTION STAGE ====================================================================
    // Adding correction stage to a wine batch
    public async Task<CorrectionStage?> Handle(AddCorrectionStageCommand command, Guid wineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);

        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");
        

        // Crear la etapa de corrección
        var correctionStage = new CorrectionStage(command);

        // Agregar la etapa de corrección al lote de vino
        wineBatch.AddStage(correctionStage);

        // Guardar los cambios en el repositorio

        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return correctionStage;
    }
    
    // Update the correction stage of a wine batch
    public async Task<CorrectionStage?> Handle(UpdateCorrectionStageCommand command, Guid wineBatchId)
    {
        // 1. Recuperar lote
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);
        if (wineBatch is null)
            throw new InvalidOperationException("Wine batch not found.");

        // 2. Obtener la etapa de corrección (recomendado usar método del agregado)
        var stage = wineBatch.GetStage(StageType.Correction) as CorrectionStage;

        if (stage is null)
            throw new InvalidOperationException("Correction stage not found for the specified wine batch.");

        // 3. Actualizar la etapa
        stage.Update(command); // método definido en CorrectionStage

        // 4. Persistir cambios
        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return stage;
    }
    
    // ================================================================================================

    //=========== PRESSING STAGE
    // Adding pressing stage to a wine batch
    public async Task<PressingStage?> Handle(AddPressingStageCommand command, Guid wineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);

        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");
        

        // Crear la etapa de prensado
        var pressingStage = new PressingStage(command);

        // Agregar la etapa de prensado al lote de vino
        wineBatch.AddStage(pressingStage);

        // Guardar los cambios en el repositorio

        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return pressingStage;
    }
    
    // Update the pressing stage of a wine batch
    public async Task<PressingStage?> Handle(UpdatePressingStageCommand command, Guid wineBatchId)
    {
        // 1. Recuperar lote
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);
        if (wineBatch is null)
            throw new InvalidOperationException("Wine batch not found.");

        // 2. Obtener la etapa de prensado (recomendado usar método del agregado)
        var stage = wineBatch.GetStage(StageType.Pressing) as PressingStage;

        if (stage is null)
            throw new InvalidOperationException("Pressing stage not found for the specified wine batch.");

        // 3. Actualizar la etapa
        stage.Update(command); // método definido en PressingStage

        // 4. Persistir cambios
        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return stage;
    }
        
    //=========== CLARIFICATION STAGE
    // Adding clarification stage to a wine batch
    public async Task<ClarificationStage?> Handle(AddClarificationStageCommand command, Guid wineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);

        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");
        

        // Crear la etapa de clarificación
        var clarificationStage = new ClarificationStage(command);

        // Agregar la etapa de clarificación al lote de vino
        wineBatch.AddStage(clarificationStage);

        // Guardar los cambios en el repositorio

        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return clarificationStage;
    }
    
    // Update the clarification stage of a wine batch
    public async Task<ClarificationStage?> Handle(UpdateClarificationStageCommand command, Guid wineBatchId)
    {
        // 1. Recuperar lote
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);
        if (wineBatch is null)
            throw new InvalidOperationException("Wine batch not found.");

        // 2. Obtener la etapa de clarificación (recomendado usar método del agregado)
        var stage = wineBatch.GetStage(StageType.Clarification) as ClarificationStage;

        if (stage is null)
            throw new InvalidOperationException("Clarification stage not found for the specified wine batch.");

        // 3. Actualizar la etapa
        stage.Update(command); // método definido en ClarificationStage

        // 4. Persistir cambios
        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return stage;
    }
    
    //=========== FERMENTATION STAGE
    // Adding fermentation stage to a wine batch
    public async Task<FermentationStage?> Handle(AddFermentationStageCommand command, Guid wineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);

        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");
        

        // Crear la etapa de fermentación
        var fermentationStage = new FermentationStage(command);

        // Agregar la etapa de recepción al lote de vino
        wineBatch.AddStage(fermentationStage);
        

        
        // Guardar los cambios en el repositorio
        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();
        
        
        return fermentationStage;
    }
    
    // Update the fermentation stage of a wine batch
    public async Task<FermentationStage?> Handle(UpdateFermentationStageCommand command, Guid wineBatchId)
    {
        // 1. Recuperar lote
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);
        if (wineBatch is null)
            throw new InvalidOperationException("Wine batch not found.");

        // 2. Obtener la etapa de fermentación (recomendado usar método del agregado)
        var stage = wineBatch.GetStage(StageType.Fermentation) as FermentationStage;

        if (stage is null)
            throw new InvalidOperationException("Fermentation stage not found for the specified wine batch.");

        // 3. Actualizar la etapa
        stage.Update(command); // método definido en FermentationStage

        // 4. Persistir cambios
        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return stage;
    }
    
    //=========== AGING STAGE
    // Adding aging stage to a wine batch
    public async Task<AgingStage?> Handle(AddAgingStageCommand command, Guid wineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);

        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");

        
        // Crear la etapa de envejecimiento
        var agingStage = new AgingStage(command);

        // Agregar la etapa de envejecimiento al lote de vino
        wineBatch.AddStage(agingStage);

        // Guardar los cambios en el repositorio

        await unitOfWork.CompleteAsync();

        return agingStage;
    }

    // Update the aging stage of a wine batch
    public async Task<AgingStage?> Handle(UpdateAgingStageCommand command, Guid wineBatchId)
    {
        // 1. Recuperar lote
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);
        if (wineBatch is null)
            throw new InvalidOperationException("Wine batch not found.");

        // 2. Obtener la etapa de envejecimiento (recomendado usar método del agregado)
        var stage = wineBatch.GetStage(StageType.Aging) as AgingStage;

        if (stage is null)
            throw new InvalidOperationException("Aging stage not found for the specified wine batch.");

        // 3. Actualizar la etapa
        stage.Update(command); // método definido en AgingStage

        // 4. Persistir cambios
        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return stage;
    }
    
    //=========== FILTRATION STAGE
    // Adding filtration stage to a wine batch
    public async Task<FiltrationStage?> Handle(AddFiltrationStageCommand command, Guid wineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);

        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");

        
        // Crear la etapa de filtración
        var filtrationStage = new FiltrationStage(command);

        // Agregar la etapa de filtración al lote de vino
        wineBatch.AddStage(filtrationStage);

        // Guardar los cambios en el repositorio

        await unitOfWork.CompleteAsync();

        return filtrationStage;
    }
    
    // Update the filtration stage of a wine batch
    public async Task<FiltrationStage?> Handle(UpdateFiltrationStageCommand command, Guid wineBatchId)
    {
        // 1. Recuperar lote
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);
        if (wineBatch is null)
            throw new InvalidOperationException("Wine batch not found.");

        // 2. Obtener la etapa de filtración (recomendado usar método del agregado)
        var stage = wineBatch.GetStage(StageType.Filtration) as FiltrationStage;

        if (stage is null)
            throw new InvalidOperationException("Filtration stage not found for the specified wine batch.");

        // 3. Actualizar la etapa
        stage.Update(command); // método definido en FiltrationStage

        // 4. Persistir cambios
        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return stage;
    }
    
    //=========== BOTTLING STAGE
    // Adding bottling stage to a wine batch
    public async Task<BottlingStage?> Handle(AddBottlingStageCommand command, Guid wineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);

        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");

       

        // Crear la etapa de embotellado
        var bottlingStage = new BottlingStage(command);

        // Agregar la etapa de embotellado al lote de vino
        wineBatch.AddStage(bottlingStage);

        // Guardar los cambios en el repositorio

        await unitOfWork.CompleteAsync();

        return bottlingStage;
    }
    
    // Update the bottling stage of a wine batch
    public async Task<BottlingStage?> Handle(UpdateBottlingStageCommand command, Guid wineBatchId)
    {
        // 1. Recuperar lote
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(wineBatchId);
        if (wineBatch is null)
            throw new InvalidOperationException("Wine batch not found.");

        // 2. Obtener la etapa de embotellado (recomendado usar método del agregado)
        var stage = wineBatch.GetStage(StageType.Bottling) as BottlingStage;

        if (stage is null)
            throw new InvalidOperationException("Bottling stage not found for the specified wine batch.");

        // 3. Actualizar la etapa
        stage.Update(command); // método definido en BottlingStage

        // 4. Persistir cambios
        wineBatchRepository.Update(wineBatch);
        await unitOfWork.CompleteAsync();

        return stage;
    }


}
