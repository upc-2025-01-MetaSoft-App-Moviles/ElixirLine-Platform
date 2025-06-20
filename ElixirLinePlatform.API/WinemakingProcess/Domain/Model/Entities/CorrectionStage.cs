using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class CorrectionStage: WinemakingStage
{
    /*
    initialSugarLevelBrix	double	Nivel de azúcar antes.
    finalSugarLevelBrix	double?	Azúcar deseado tras corrección.
    addedSugarKg	double?	Azúcar añadido.
    initialpH	double	pH inicial.
    finalpH	double?	pH después de corrección.
    addedAcidType	string?	Tipo de ácido añadido.
    addedAcidGramsPerLitre	double?	Cantidad de ácido añadido.
    addedSO2MgPerLitre	double?	Dióxido de azufre añadido.
    addedYeastNutrients	string?	Nutrientes añadidos.
    correctionReason	string?	Motivo de la corrección.
     */
   
    public string InitialSugarLevelBrix { get; private set; } // Nivel de azúcar antes.
    public string FinalSugarLevelBrix { get; private set; } // Azúcar deseado tras corrección.
    public string AddedSugarKg { get; private set; } // Azúcar añadido.
    public string InitialPH { get; private set; } // pH inicial.
    public string FinalPH { get; private set; } // pH después de corrección.
    public string AddedAcidType { get; private set; } // Tipo de ácido añadido.
    public string AddedAcidGramsPerLitre { get; private set; } // Cantidad de ácido añadido.
    public string AddedSO2MgPerLitre { get; private set; } // Dióxido de azufre añadido.
    public string AddedYeastNutrients { get; private set; } // Nutrientes añadidos.
    public string CorrectionReason { get; private set; } // Motivo de la corrección.
    
    
    // ========== Constructors para inicializar la clase
    private CorrectionStage() : base(StageType.Correction, string.Empty)
    {
        // Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = DateTime.Now;
        
        // Inicialización de datos específicos de la etapa de corrección
        InitialSugarLevelBrix = string.Empty;
        FinalSugarLevelBrix = string.Empty;
        AddedSugarKg = string.Empty;
        InitialPH = string.Empty;
        FinalPH = string.Empty;
        AddedAcidType = string.Empty;
        AddedAcidGramsPerLitre = string.Empty;
        AddedSO2MgPerLitre = string.Empty;
        AddedYeastNutrients = string.Empty;
        CorrectionReason = string.Empty;
    }
  
    
    // ========== Constructor de inicialización para la creación de una etapa de corrección
    public CorrectionStage(DateTime startedAt, string completedBy, string initialSugarLevelBrix, string finalSugarLevelBrix, string addedSugarKg, string initialpH, string finalpH, string addedAcidType, string addedAcidGramsPerLitre, string addedSO2MgPerLitre, string addedYeastNutrients, string correctionReason, string observations) 
        : base(StageType.Correction, observations)
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
        CompletedBy = completedBy;
        
        // Inicialización de datos específicos de la etapa de corrección
        InitialSugarLevelBrix = initialSugarLevelBrix;
        FinalSugarLevelBrix = finalSugarLevelBrix;
        AddedSugarKg = addedSugarKg;
        InitialPH = initialpH;
        FinalPH = finalpH;
        AddedAcidType = addedAcidType;
        AddedAcidGramsPerLitre = addedAcidGramsPerLitre;
        AddedSO2MgPerLitre = addedSO2MgPerLitre;
        AddedYeastNutrients = addedYeastNutrients;
        CorrectionReason = correctionReason;
    }
   
    
    // ========== Constructor de inicialización para la creación de una etapa de corrección con command
    public CorrectionStage(AddCorrectionStageCommand command) : base(StageType.Correction, command.observations)
    {
        // ========== Validar formato de fecha
        if (!DateTime.TryParseExact(command.startedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de PressingStage.");
        }
        // Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = DateTime.Now;
        CompletedBy = command.completedBy;
        
        // Inicialización de datos específicos de la etapa de corrección
        InitialSugarLevelBrix = command.initialSugarLevelBrix;
        FinalSugarLevelBrix = command.finalSugarLevelBrix;
        AddedSugarKg = command.addedSugarKg;
        InitialPH = command.initialPH;
        FinalPH = command.finalPH;
        AddedAcidType = command.addedAcidType;
        AddedAcidGramsPerLitre = command.addedAcidGramsPerLitre;
        AddedSO2MgPerLitre = command.addedSO2MgPerLitre;
        AddedYeastNutrients = command.addedYeastNutrients;
        CorrectionReason = command.correctionReason;
        Observations = command.observations;
    }
    
}