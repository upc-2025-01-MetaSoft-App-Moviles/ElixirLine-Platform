using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class CorrectionStage: WinemakingStage
{
    public string FiltrationType { get; private set; } // Type of filtration (e.g. diatomaceous earth)
    public string CorrectionsApplied { get; private set; } // Any final adjustments (e.g. SO2, blending)
    public string FinalParameters { get; private set; } // Final analytical values (e.g. pH, alcohol %)
    public string PerformedBy { get; private set; } // Responsible operator or enologist
    
    // ========== Constructors para inicializar la clase
    public CorrectionStage(): base(StageType.Correction, string.Empty)
    {
        FiltrationType = string.Empty;
        CorrectionsApplied = string.Empty;
        FinalParameters = string.Empty;
        PerformedBy = string.Empty;
    }
    
    // ========== Constructor de inicialización para la creación de una etapa de corrección
    public CorrectionStage(DateTime startedAt, string filtrationType, string correctionsApplied, 
        string finalParameters, string performedBy) : base(StageType.Correction, string.Empty)
    {

        // ========= Validar formato de fecha
        if (!DateTime.TryParseExact(startedAt.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null, DateTimeStyles.None,
                out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de PressingStage.");
        }

        // ========= Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        StageType = StageType.Pressing;
        
        

    FiltrationType = filtrationType;
        CorrectionsApplied = correctionsApplied;
        FinalParameters = finalParameters;
        PerformedBy = performedBy;
    }
    
    // ========== Constructor de inicialización para la creación de una etapa de corrección con command
    /*
    public CorrectionStage(AddCorrectionStageCommand command): this()
    {
        // ========== Validar formato de fecha
        if (!DateTime.TryParseExact(command.startedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de PressingStage.");
        }
        
        // ========= Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        StageType = StageType.Pressing;
        
    }
    */
    
}