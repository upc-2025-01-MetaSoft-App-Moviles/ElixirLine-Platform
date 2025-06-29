namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.CommandStagesResources;

public record AddFiltrationStageResource(
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
    string changeReason,
    string startedAt,
    string? completedBy,
    string? observations);