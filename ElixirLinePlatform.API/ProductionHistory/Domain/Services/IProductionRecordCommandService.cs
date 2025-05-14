using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Commands;

namespace ElixirLinePlatform.API.ProductionHistory.Domain.Services;

public interface IProductionRecordCommandService
{
    Task<ProductionRecord?> Handle(CreateProductionRecordCommand command);
    Task<ProductionRecord?> Handle(UpdateVolumeProducedCommand command);
    Task<bool> Handle(DeleteProductionRecordCommand command);
}