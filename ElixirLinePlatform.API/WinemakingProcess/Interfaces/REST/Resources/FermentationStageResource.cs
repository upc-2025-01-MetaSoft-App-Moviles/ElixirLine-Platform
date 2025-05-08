namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;
public record FermentationStageResource(
    Guid Id, 
    string startedAt, 
    string yeastUsed, 
    double initialSugarLevel, 
    double temperature, 
    bool malo, 
    string tankCode
    );