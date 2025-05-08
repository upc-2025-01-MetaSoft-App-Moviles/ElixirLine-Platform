namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources;

public record AddFermentationStageResource(
    string startedAt, 
    string yeastUsed, 
    double initialSugarLevel, 
    double temperature, 
    bool malo, 
    string tankCode);