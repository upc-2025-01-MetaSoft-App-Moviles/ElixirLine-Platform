using System.Globalization;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Commands;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Value_Objects;

namespace ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;

public partial class ProductionRecord
{
    public Guid RecordId { get; }
    public Guid BatchId { get; set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public float VolumeProduced { get; private set; }
    public QualityMetrics QualityMetrics { get; private set; }


    public ProductionRecord()
    {
        BatchId = Guid.Empty;
        StartDate = DateTime.Now;
        EndDate = DateTime.Now;
        VolumeProduced = 0;
        QualityMetrics = new QualityMetrics(0, 0, 0);
    }
    
    public ProductionRecord(Guid batchId, string startDate, string endDate, float volumeProduced,
        float brix, float ph, float temperature)
    {
        if (!DateTime.TryParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedStartDate))
            throw new FormatException("The date format is DD/MM/AAAA.");
        
        if (!DateTime.TryParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedEndDate))
            throw new FormatException("The date format is DD/MM/AAAA.");
        
        BatchId = batchId;
        StartDate = parsedStartDate;
        EndDate = parsedEndDate;
        VolumeProduced = volumeProduced;
        QualityMetrics = new QualityMetrics(brix, ph, temperature);
    }
    
    public ProductionRecord(CreateProductionRecordCommand command)
    {
        if (!DateTime.TryParseExact(command.StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedStartDate))
            throw new FormatException("The date format is DD/MM/AAAA.");
        
        if (!DateTime.TryParseExact(command.EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedEndDate))
            throw new FormatException("The date format is DD/MM/AAAA.");
        BatchId = command.BatchId;
        StartDate = parsedStartDate;
        EndDate = parsedEndDate;
        VolumeProduced = command.VolumeProduced;
        QualityMetrics = new QualityMetrics(
            command.Brix, 
            command.Ph, 
            command.Temperature);
    }
    
    public void UpdateVolumeProduced(float volumeProduced)
    {
        if (volumeProduced < 0)
            throw new ArgumentException("Volume produced cannot be negative.");
        
        VolumeProduced = volumeProduced;
    }
    
}