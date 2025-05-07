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

    public async Task<WineBatch?> Handle(AddReceptionStageCommand command, Guid WineBatchId)
    {
        //Verificar si existe el WineBatch
        var wineBatch = await wineBatchRepository.GetWineBatchByIdAsync(WineBatchId);
        
        // Mensaje en caso de que no exista el WineBatch
        if (wineBatch is null) throw new Exception("Wine Batch not found");
        
        // Crear la etapa de recepción
        var receptionStage = new ReceptionStage(command);
        
        // Verificar si la etapa de recepción ya existe
        if (wineBatch.stagesWinemaking.Any(stage => stage.StageType == StageType.Reception))
        {
            throw new Exception("La etapa de recepción ya existe para este lote.");
        }
        
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

        return wineBatch;
    }
}

