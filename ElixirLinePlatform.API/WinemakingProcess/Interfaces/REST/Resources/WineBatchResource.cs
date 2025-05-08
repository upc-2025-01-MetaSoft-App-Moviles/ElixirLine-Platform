namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record WineBatchResource(
    Guid id,
    string internalCode,
    string receptionDate,
    string campaign,
    string vineyard,
    string grapeVariety,
    string createdBy,
    double initialGrapeQuantityKg);
