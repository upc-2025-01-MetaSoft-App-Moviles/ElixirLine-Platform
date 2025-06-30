namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record UpdateWineBatchResource(
    string InternalCode,
    string Campaign,
    string Vineyard,
    string GrapeVariety,
    string CreatedBy);