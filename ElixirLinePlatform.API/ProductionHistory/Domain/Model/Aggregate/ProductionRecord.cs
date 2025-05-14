using System.Globalization;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Commands;

namespace ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;

public partial class ProductionRecord
{
    public Guid RecordId { get; }
    public Guid BatchId { get; set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public float VolumeProduced { get; private set; }
    public Dictionary<string, float> QualityMetrics { get; private set; }

    public ProductionRecord(Guid batchId, string startDate, string endDate, float volumeProduced,
        Dictionary<string, float> qualityMetrics)
    {
        if (!DateTime.TryParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedStartDate))
            throw new FormatException("The date format is DD/MM/AAAA.");
        
        if (!DateTime.TryParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedEndDate))
            throw new FormatException("The date format is DD/MM/AAAA.");
        
        RecordId = Guid.NewGuid();
        BatchId = batchId;
        StartDate = parsedStartDate;
        EndDate = parsedEndDate;
        VolumeProduced = volumeProduced;
        QualityMetrics = qualityMetrics ?? new Dictionary<string, float>();
    }
    
    public ProductionRecord(CreateProductionRecordCommand command)
    {
        if (!DateTime.TryParseExact(command.StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedStartDate))
            throw new FormatException("The date format is DD/MM/AAAA.");
        
        if (!DateTime.TryParseExact(command.EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedEndDate))
            throw new FormatException("The date format is DD/MM/AAAA.");
        RecordId = Guid.NewGuid();
        BatchId = command.BatchId;
        StartDate = parsedStartDate;
        EndDate = parsedEndDate;
        VolumeProduced = command.VolumeProduced;
        QualityMetrics = command.QualityMetrics;
    }
    
    public void UpdateVolumeProduced(float volumeProduced)
    {
        if (volumeProduced < 0)
            throw new ArgumentException("Volume produced cannot be negative.");
        
        VolumeProduced = volumeProduced;
    }
    
}