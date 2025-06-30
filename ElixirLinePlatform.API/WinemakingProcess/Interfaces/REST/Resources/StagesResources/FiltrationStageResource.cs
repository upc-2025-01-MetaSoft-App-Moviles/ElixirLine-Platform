namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.StagesResources;

public record FiltrationStageResource(
    string batchId,
    string stageType,
    string startedAt,
    string completedAt,
    string completedBy,
    string observations,
    bool isCompleted,
    string filterType,
    string filtrationType,
    string filterMedia,
    double poreMicrons,
    double turbidityBefore,
    double turbidityAfter,
    double temperature,
    double pressureBars,
    double filteredVolumeLiters,
    bool isSterile,
    bool filterChanged,
    string changeReason);
    
    
    
    
