namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

public record CorrectionStageResource( 
    string batchId,
    string stageType,
    string startedAt, 
    string completedAt,
    string completedBy,
    string observations,
    bool isCompleted);