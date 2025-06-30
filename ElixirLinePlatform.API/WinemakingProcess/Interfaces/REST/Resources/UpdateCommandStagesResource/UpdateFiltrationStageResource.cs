namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

public record UpdateFiltrationStageResource( 
    string StartedAt,
    string CompletedBy,
    string Observations,
    bool IsCompleted,
    string FilterType,
    string FiltrationType,
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