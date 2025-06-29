namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record WineBatchResource(
    Guid id,
    string campaignId,
    string internalCode,
    string campaign,
    string vineyard,
    string grapeVariety,
    string createdBy
    );
