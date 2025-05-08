using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Repositories;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;

namespace ElixirLinePlatform.API.WinemakingProcess.Application.Internal.CommandServices;

public class WineBatchCommandService(IWineBatchRepository wineBatchRepository, IUnitOfWork unitOfWork) : IWineBatchCommandService
{

    public async Task<WineBatch?> Handle(CreateWineBatchCommand command)
    {
        var wineBatch = new WineBatch(command);
        
        await wineBatchRepository.AddAsync(wineBatch);
        await unitOfWork.CompleteAsync();
        return wineBatch;
    }

    public async Task<ReceptionStage?> Handle(AddReceptionStageCommand command, Guid WineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(WineBatchId);
        
        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");
        
        // Verificar si la etapa de recepción ya existe en el lote de vino
        var existingReceptionStage = await wineBatchRepository.GetReceptionStageByWineBatchIdAsync(wineBatch.Id);
        
        if (existingReceptionStage != null)
        {
            throw new Exception("La etapa de recepción ya existe para este lote de vino.");
        }
        
        // Crear la etapa de recepción
        var receptionStage = new ReceptionStage(command);
        
      
        
        // Verificar si el estado del lote es "Recibido"
        if (wineBatch.Status != BatchStatus.Received)
        {
            throw new Exception("El lote no está en estado 'Recibido'.");
        }
        
        // Verificar si la fecha de inicio de la etapa es anterior a la fecha de recepción del lote
        if (receptionStage.StartedAt < wineBatch.ReceptionDate)
        {
            throw new Exception("La fecha de inicio de la etapa no puede ser anterior a la fecha de recepción del lote.");
        }
        
        // Agregar la etapa de recepción al lote de vino
        wineBatch.AddStage(receptionStage);
        
        
        // Guardar los cambios en el repositorio
        wineBatchRepository.Update(wineBatch);
        
        await unitOfWork.CompleteAsync();

        return receptionStage;
    }

    public async Task<FermentationStage?> Handle(AddFermentationStageCommand command, Guid WineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(WineBatchId);
        
        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");
        
        // Verificar si la etapa de recepción ya existe en el lote de vino
        var existingReceptionStage = await wineBatchRepository.GetReceptionStageByWineBatchIdAsync(wineBatch.Id);
        if (existingReceptionStage == null)
        {
            throw new Exception("No se puede agregar la etapa de fermentación sin una etapa de recepción previa.");
        }
        
        // Verificar si la etapa de fermentación ya existe en el lote de vino
        var existingFermentationStage = await wineBatchRepository.GetFermentationStageByWineBatchIdAsync(wineBatch.Id);
        
        if (existingFermentationStage != null)
        {
            throw new Exception("La etapa de fermentación ya existe para este lote de vino.");
        }
        
        // Crear la etapa de fermentación
        var fermentationStage = new FermentationStage(command);
        
        // Agregar la etapa de recepción al lote de vino
        wineBatch.AddStage(fermentationStage);
        
        
        return fermentationStage;
    }

    public async Task<PressingStage?> Handle(AddPressingStageCommand command, Guid WineBatchId)
    {
        // Obtener el lote de vino por su ID
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(WineBatchId);
        
        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");
        
        // Verificar si la etapa de fermentación ya existe en el lote de vino
        var existingFermentationStage = await wineBatchRepository.GetFermentationStageByWineBatchIdAsync(wineBatch.Id);
        if (existingFermentationStage == null)
        {
            throw new Exception("No se puede agregar la etapa de prensado sin una etapa de fermentación previa.");
        }
        
        // Verificar si la etapa de prensado ya existe en el lote de vino
        var existingPressingStage = await wineBatchRepository.GetPressingStageByWineBatchIdAsync(wineBatch.Id);
        
        if (existingPressingStage != null)
        {
            throw new Exception("La etapa de prensado ya existe para este lote de vino.");
        }
        
        // Crear la etapa de prensado
        var pressingStage = new PressingStage(command);
        
        // Agregar la etapa de prensado al lote de vino
        wineBatch.AddStage(pressingStage);
        
        // Guardar los cambios en el repositorio
        wineBatchRepository.Update(wineBatch);
        
        await unitOfWork.CompleteAsync();
        
        return pressingStage;
    }
}

