namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.AddCommandStagesResources;

public record CreateWineBatchResource( 
    string internalCode, 
    string campaign, 
    string vineyard, 
    string grapeVariety, 
    string createdBy);