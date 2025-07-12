using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class AgingStage : WinemakingStage
{
    public string ContainerType { get; private set; }     // Ej: Barrica, tanque, ánfora
    public string Material { get; private set; }          // Ej: Roble Francés
    public string ContainerCode { get; private set; }     // Ej: código de identificación del recipiente
    public double AvgTemperature { get; private set; }    // Temperatura promedio
    public double VolumeLiters { get; private set; }      // Volumen contenido
    public int DurationMonths { get; private set; }       // Tiempo de añejamiento

    public int FrequencyDays { get; private set; }       // Frecuencia de intervención
    public int Refilled { get; private set; }             // Número de rellenados
    public int Batonnage { get; private set; }            // Número de bâtonnage realizados
    public int Rackings { get; private set; }             // Número de trasiegos

    public string Purpose { get; private set; }           // Finalidad del añejamiento
    
    
    public AgingStage() : base(StageType.Aging, DateTime.Now, null)
    {
        ContainerType = string.Empty;
        Material = string.Empty;
        ContainerCode = string.Empty;
        AvgTemperature = 0;
        VolumeLiters = 0;
        DurationMonths = 0;
        FrequencyDays = 0;
        Refilled = 0;
        Batonnage = 0;
        Rackings = 0;
        Purpose = string.Empty;

        CompletedBy = null;
    }

    public AgingStage(
        string containerType,
        string material,
        string containerCode,
        double avgTemperature,
        double volumeLiters,
        int durationMonths,
        int frequencyDays,
        int refilled,
        int batonnage,
        int rackings,
        string purpose,
        string startedAt, 
        string? completedBy,
        string? observations
    ) : base(StageType.Aging, ParseDate(startedAt), observations)
    {
        ContainerType = containerType;
        Material = material;
        ContainerCode = containerCode;
        AvgTemperature = avgTemperature;
        VolumeLiters = volumeLiters;
        DurationMonths = durationMonths;
        FrequencyDays = frequencyDays;
        Refilled = refilled;
        Batonnage = batonnage;
        Rackings = rackings;
        Purpose = purpose;

        CompletedBy = completedBy;
    }
     
     
    public AgingStage(AddAgingStageCommand command) 
        : base(StageType.Aging, ParseDate(command.startedAt), command.observations)
    {
       
        ContainerType = command.containerType;
        Material = command.material;
        ContainerCode = command.containerCode;
        AvgTemperature = command.avgTemperature;
        VolumeLiters = command.volumeLiters;
        DurationMonths = command.durationMonths;
        FrequencyDays = command.frequencyDays;
        Refilled = command.refilled;
        Batonnage = command.batonnage;
        Rackings = command.rackings;
        Purpose = command.purpose;

        CompletedBy = command.completedBy;
    }
     
    
    public void Update(UpdateAgingStageCommand command)
    {
        if (command == null) throw new ArgumentNullException(nameof(command));

        StartedAt = ParseDate(command.StartedAt);
        CompletedBy = command.CompletedBy;
        IsCompleted = command.IsCompleted;
        ContainerType = command.ContainerType;
        Material = command.Material;
        ContainerCode = command.ContainerCode;
        AvgTemperature = command.AvgTemperature;
        VolumeLiters = command.VolumeLiters;
        DurationMonths = command.DurationMonths;
        FrequencyDays = command.FrequencyDays;
        Refilled = command.Refilled;
        Batonnage = command.Batonnage;
        Rackings = command.Rackings;
        Purpose = command.Purpose;

        CompletedAt = command.IsCompleted ? DateTime.Now : null;
        Observations = command.Observations;
    }

   
    public override void Delete()
    {
        ContainerType = string.Empty;
        Material = string.Empty;
        ContainerCode = string.Empty;
        AvgTemperature = 0;
        VolumeLiters = 0;
        DurationMonths = 0;
        FrequencyDays = 0;
        Refilled = 0;
        Batonnage = 0;
        Rackings = 0;
        Purpose = string.Empty;

        Observations = null;
        CompletedAt = null;
        CompletedBy = null;
    }

    private static DateTime ParseDate(string date)
    {
        if (!DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
            throw new FormatException("La fecha debe estar en formato dd/MM/yyyy.");
        return parsed;
    }

    
    // Método para asignar el batchId a la etapa de añejamiento
    public override void AssignBatchId(Guid batchId)
    {
        BatchId = batchId;
    }
}