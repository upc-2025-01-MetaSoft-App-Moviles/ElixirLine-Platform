namespace ElixirLinePlatform.API.ProductionHistory.Application.Internal.EventHandlers;

using ElixirLinePlatform.API.ProductionHistory.Domain.Repositories;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;
using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.Shared.Domain.Events;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Events;

public class WineBatchCompletedEventHandler : IEventHandler<WineBatchCompletedEvent>
{
    private readonly IProductionRecordRepository _productionRecordRepository;
    private readonly IUnitOfWork _unitOfWork;

    public WineBatchCompletedEventHandler(
        IProductionRecordRepository productionRecordRepository,
        IUnitOfWork unitOfWork)
    {
        _productionRecordRepository = productionRecordRepository;
        _unitOfWork = unitOfWork;
    }

    public void Handle(WineBatchCompletedEvent @event)
    {
        // Crear un nuevo registro de producción
        var productionRecord = new ProductionRecord(
            @event.BatchId,
            @event.StartDate.ToString("dd/MM/yyyy"),
            @event.EndDate.ToString("dd/MM/yyyy"),
            (float)@event.VolumeProduced,
            @event.Brix,
            @event.Ph,
            @event.Temperature
        );

        // Persistir el registro
        _productionRecordRepository.Add(productionRecord);
        _unitOfWork.CompleteAsync().GetAwaiter().GetResult();
    }
}