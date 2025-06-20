using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Commands;
using ElixirLinePlatform.API.ProductionHistory.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.ProductionHistory.Interfaces.REST.Transform;

public static class CreateProductionRecordCommandFromResourceAssembler
{
    public static CreateProductionRecordCommand ToCommandFromResource(CreateProductionRecordResource resource)
    {
        return new CreateProductionRecordCommand(
            resource.BatchId,
            resource.StartDate,
            resource.EndDate,
            resource.VolumeProduced,
            resource.Brix,
            resource.Ph,
            resource.Temperature);
    }
}