namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Events;

public class WineBatchCompletedEvent
{
    public Guid BatchId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public double VolumeProduced { get; private set; }
    public float Brix { get; private set; }
    public float Ph { get; private set; }
    public float Temperature { get; private set; }

    public WineBatchCompletedEvent(Guid batchId, DateTime startDate, DateTime endDate, 
        double volumeProduced, float brix, float ph, float temperature)
    {
        BatchId = batchId;
        StartDate = startDate;
        EndDate = endDate;
        VolumeProduced = volumeProduced;
        Brix = brix;
        Ph = ph;
        Temperature = temperature;
    }
}