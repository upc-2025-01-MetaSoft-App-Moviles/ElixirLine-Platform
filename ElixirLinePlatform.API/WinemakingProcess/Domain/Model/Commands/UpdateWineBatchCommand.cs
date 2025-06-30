namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record UpdateWineBatchCommand(
    string internalCode,
    string campaign,
    string vineyard,
    string grapeVariety,
    string createdBy);