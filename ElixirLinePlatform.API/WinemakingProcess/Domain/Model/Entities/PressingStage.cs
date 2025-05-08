using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class PressingStage: WinemakingStage
{
    public string PressType { get; private set; } // Type of press (pneumatic, hydraulic, etc.)
    public double MaxPressureBar { get; private set; } // Peak pressure applied during pressing
    public double ExtractedLiters { get; private set; } // Total liquid extracted
    public double SolidWasteKg { get; private set; } // Mass of grape pomace and solids
    public double YieldPercentage { get; private set; } // Ratio of liquid extracted vs. total weight

    private PressingStage() : base(StageType.Fermentation, string.Empty)
    {
        PressType = string.Empty;
        MaxPressureBar = 0;
        ExtractedLiters = 0;
        SolidWasteKg = 0;
        YieldPercentage = 0;
    }
    
    public PressingStage(DateTime startedAt, string pressType, double maxPressureBar, double extractedLiters, double solidWasteKg, double yieldPercentage)
        : base(StageType.Pressing, string.Empty)
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
        SolidWasteKg = solidWasteKg;
        YieldPercentage = yieldPercentage;
    }
    
    
    /*
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
        
        // ========== Inicializar propiedades con valores del command
        PressType = command.pressType;
        MaxPressureBar = command.maxPressureBar;
        ExtractedLiters = command.extractedLiters;
        SolidWasteKg = command.solidWasteKg;
        YieldPercentage = command.yieldPercentage;
    }
    */
    
}