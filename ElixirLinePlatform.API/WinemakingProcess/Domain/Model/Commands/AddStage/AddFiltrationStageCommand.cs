namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;

public record AddFiltrationStageCommand(
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