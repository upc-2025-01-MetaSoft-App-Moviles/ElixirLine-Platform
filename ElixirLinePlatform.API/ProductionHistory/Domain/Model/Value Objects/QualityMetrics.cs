namespace ElixirLinePlatform.API.ProductionHistory.Domain.Model.Value_Objects;

public record QualityMetrics
{
    public float Brix { get; }
    public float Ph { get; }
    public float Temperature { get; }

    public QualityMetrics(float brix, float ph, float temperature)
    {
        Brix = brix;
        Ph = ph;
        Temperature = temperature;
    }
}