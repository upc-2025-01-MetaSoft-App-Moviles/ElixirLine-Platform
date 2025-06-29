using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Repositories;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;

namespace ElixirLinePlatform.API.WinemakingProcess.Application.Internal.CommandServices;

public class WineBatchCommandService(IWineBatchRepository wineBatchRepository, IUnitOfWork unitOfWork) : IWineBatchCommandService
{

    // ============= CREAR LOTE DE VINO
    public async Task<WineBatch?> Handle(CreateWineBatchCommand command)
    {
        var wineBatch = new WineBatch(command);

        await wineBatchRepository.AddAsync(wineBatch);
        await unitOfWork.CompleteAsync();
        return wineBatch;
    }

    //=========== RECEPTION STAGE
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

    
    //=========== CORRECTION STAGE
    // Adding correction stage to a wine batch
    public async Task<CorrectionStage?> Handle(AddCorrectionStageCommand command, Guid WineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(WineBatchId);

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


    //=========== PRESSING STAGE
    // Adding pressing stage to a wine batch
    public async Task<PressingStage?> Handle(AddPressingStageCommand command, Guid WineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(WineBatchId);

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
    
        
    //=========== CLARIFICATION STAGE
    // Adding clarification stage to a wine batch
    public async Task<ClarificationStage?> Handle(AddClarificationStageCommand command, Guid WineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(WineBatchId);

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

    
    //=========== FERMENTATION STAGE
    // Adding fermentation stage to a wine batch
    public async Task<FermentationStage?> Handle(AddFermentationStageCommand command, Guid WineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(WineBatchId);

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
    
    
    //=========== FILTRATION STAGE
    // Adding filtration stage to a wine batch
    public async Task<FiltrationStage?> Handle(AddFiltrationStageCommand command, Guid WineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(WineBatchId);

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
    
    
    //=========== BOTTLING STAGE
    // Adding bottling stage to a wine batch
    public async Task<BottlingStage?> Handle(AddBottlingStageCommand command, Guid WineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(WineBatchId);

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
    


}
