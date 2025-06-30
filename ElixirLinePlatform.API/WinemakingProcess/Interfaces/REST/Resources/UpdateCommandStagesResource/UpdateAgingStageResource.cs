namespace ElixirLinePlatform.API.WinemakingProcess.Interfaces.REST.Resources.UpdateCommandStagesResource;

public record UpdateAgingStageResource( 
    string StartedAt,
    string CompletedBy,
    string Observations,
    bool IsCompleted,
    string ContainerType,
    string Material,
    string ContainerCode,
    double AvgTemperature,
    double VolumeLiters,
    int DurationMonths,
    int FrequencyDays,
    int Refilled,
    int Batonnage,
    int Rackings,
    string Purpose);