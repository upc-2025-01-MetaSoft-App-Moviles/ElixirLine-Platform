namespace ElixirLinePlatform.API.ProductionHistory.Domain.Model.Commands;

public record UpdateVolumeProducedCommand(Guid recordID, float VolumeProduced);