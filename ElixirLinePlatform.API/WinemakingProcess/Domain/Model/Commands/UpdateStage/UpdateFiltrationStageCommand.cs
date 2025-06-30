namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;

public record UpdateFiltrationStageCommand( 
    string StartedAt,
    string CompletedBy,
    string Observations,
    bool IsCompleted,
    string FilterType,
    string FilterMedia,
    double PoreMicrons,
    double TurbidityBefore,
    double TurbidityAfter,
    double Temperature,
    double PressureBars,
    double FilteredVolumeLiters,
    bool IsSterile,
    bool FilterChanged,
    string ChangeReason);