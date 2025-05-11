using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class PressingStage: WinemakingStage
{
    public string PressType { get; private set; } // Type of press (pneumatic, hydraulic, etc.)
    public double MaxPressureBar { get; private set; } // Peak pressure applied during pressing
    public int PressingDurationMinutes { get; private set; } // Duration of pressing in minutes
    public double GrapePomadeWeightKg { get; private set; } // Weight of grape pomade after pressing

    public double ExtractedLiters { get; private set; } // Total liquid extracted
    public string IntendedWineUse { get; private set; } // Intended use of the wine (e.g., red, white, sparkling)
    public double YieldPercentage { get; private set; } // Ratio of liquid extracted vs. total weight

    private PressingStage() : base(StageType.Fermentation, string.Empty)
    {
        PressType = string.Empty;
        MaxPressureBar = 0;
        ExtractedLiters = 0;
        YieldPercentage = 0;
        PressingDurationMinutes = 0;
        GrapePomadeWeightKg = 0;
        IntendedWineUse = string.Empty;
        CompletedBy = string.Empty;
        Observations = string.Empty;
        // Inicializamos atributos
        
        // Inicializar StartedAt en formato dd/MM/yyyy
        StartedAt = DateTime.Now;
        CompletedAt = null;
        CompletedBy = null;
        Observations = null;
        
    }
    
    public PressingStage(DateTime startedAt, string pressType, double maxPressureBar, int pressingDurationMinutes,double grapePomadeWeightKg ,double extractedLiters, string intendedWineUse, double yieldPercentage, string completedBy, string observations)
        : base(StageType.Pressing, observations)
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
        
        
        PressType = pressType;
        MaxPressureBar = maxPressureBar;
        ExtractedLiters = extractedLiters;
        YieldPercentage = yieldPercentage;
        PressingDurationMinutes = pressingDurationMinutes;
        GrapePomadeWeightKg = grapePomadeWeightKg;
        IntendedWineUse = intendedWineUse;
        CompletedBy = completedBy;
        Observations = observations;
        
    }
    
    
    
    public PressingStage(AddPressingStageCommand command): this()
    {
        // ========== Validar formato de fecha
        if (!DateTime.TryParseExact(command.startedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de PressingStage.");
        }
        
        // ========== Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        StageType = StageType.Pressing;
        CompletedBy = command.completedBy;
        Observations = command.observations;
        
        // ========== Inicializar propiedades con valores del command
        PressType = command.pressType;
        MaxPressureBar = command.maxPressureBar;
        ExtractedLiters = command.extractedLiters;
        YieldPercentage = command.yieldPercentage;
        PressingDurationMinutes = command.pressingDurationMinutes;
        GrapePomadeWeightKg = command.grapePomadeWeightKg;
        IntendedWineUse = command.intendedWineUse;
       
        
    }
    
    
}