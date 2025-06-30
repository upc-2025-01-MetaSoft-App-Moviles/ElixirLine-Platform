namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record UpdateWineBatchCommand(
    string InternalCode,
    string Campaign,
    string Vineyard,
    string GrapeVariety,
    string CreatedBy);