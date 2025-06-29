namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

public record BottlingStageResource( 
    string batchId,
    string stageType,
    string startedAt, 
    string completedAt,
    string completedBy,
    string observations,
    bool isCompleted);