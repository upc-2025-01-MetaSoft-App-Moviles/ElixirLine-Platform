namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record CreateWineBatchCommand(string internalCode, string campaign, string vineyard, string grapeVariety, string createdBy);