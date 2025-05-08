namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;

public record CreateWineBatchCommand(string internalCode, string receptionDate, string campaign, string vineyard, string grapeVariety, string createdBy, double initialGrapeQuantityKg);