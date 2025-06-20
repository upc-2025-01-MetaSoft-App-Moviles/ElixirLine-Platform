using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class AgingStage : WinemakingStage
{
    public string ContainerType { get; private set; } // Barrel, tank, bottle, etc.
    public string ContainerMaterial { get; private set; } // Wood (oak), stainless steel, etc.
    public double VolumeLiters { get; private set; } // Quantity of wine aged
    public int PlannedMonths { get; private set; } // Expected duration
    public decimal Temperature { get; set; } // Temperature in Centigrade
    public decimal Humidity { get; set; } // Humidity level 
    public string BarrelCode { get; private set; } // Identifier for traceability of a vessel
    
    // ========== Constructors para inicializar la clase 
    public AgingStage()
        : base(StageType.Aging, string.Empty)
    {
        ContainerType = string.Empty;
        ContainerMaterial = string.Empty;
        VolumeLiters = 0;
        PlannedMonths = 0;
        Temperature = 0;
        Humidity = 0;
        BarrelCode = string.Empty;
    }
    
    public AgingStage(DateTime startedAt, string containerType, string containerMaterial, double volumeLiters, int plannedMonths, 
        decimal temperature, decimal humidity, string barrelCode): base(StageType.Aging, string.Empty)
    {
        // ========= Validar formato de fecha
        if (!DateTime.TryParseExact(startedAt.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de PressingStage.");
        }
        
        // ========= Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        StageType = StageType.Pressing;
        
        
        ContainerType = containerType;
        ContainerMaterial = containerMaterial;
        VolumeLiters = volumeLiters;
        PlannedMonths = plannedMonths;
        Temperature = temperature;
        Humidity = humidity;
        BarrelCode = barrelCode;
    }
    
    
    // ========== Constructor de inicialización para la creación de una etapa de clarificación con command
    
    /*
    public AgingStage(AddAgingStageCommand command): this()
    {
        // ========== Validar formato de fecha
        if (!DateTime.TryParseExact(command.startedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de AgingStage.");
        }
        
        // ========== Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        StageType = StageType.Aging;
        
        // ========== Inicializar propiedades con valores del command
        ContainerType = command.containerType;
        ContainerMaterial = command.containerMaterial;
        VolumeLiters = command.volumeLiters;
        PlannedMonths = command.plannedMonths;
        Temperature = command.temperature;
        Humidity = command.humidity;
        BarrelCode = command.barrelCode;
    }
    */
}