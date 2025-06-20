using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Commands;
using ElixirLinePlatform.API.ProductionHistory.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.ProductionHistory.Interfaces.REST.Transform;

public static class UpdateVolumeProducedCommandFromResourceAssembler
{
    public static UpdateVolumeProducedCommand ToCommandFromResource(Guid recordId, UpdateVolumeProducedResource resource)
    {
        return new UpdateVolumeProducedCommand(recordId, resource.VolumeProduced);
    }
}