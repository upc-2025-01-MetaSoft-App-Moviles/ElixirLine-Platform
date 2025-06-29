using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class CorrectionStage: WinemakingStage
{
   
    public double InitialSugarLevel { get; private set; } // Nivel de azúcar antes.
    public double FinalSugarLevel { get; private set; } // Azúcar deseado tras corrección.
    public double AddedSugarKg { get; private set; } // Azúcar añadido.
    public double InitialPh { get; private set; } // pH inicial.
    public double FinalPh { get; private set; } // pH después de corrección.
    public string AcidType { get; private set; } // Tipo de ácido añadido.
    public double AcidAddedGl { get; private set; } // Cantidad de ácido añadido.
    public double So2AddedMgL { get; private set; } // Dióxido de azufre añadido.
    
    //public List<Nutrient> NutrientsAdded { get; private set; } = new();

    public string Justification { get; private set; }    
    
    
    // ========== Constructors para inicializar la clase
    public CorrectionStage(
        double initialSugarLevel,
        double finalSugarLevel,
        double addedSugarKg,
        double initialPh,
        double finalPh,
        string acidType,
        double acidAddedGl,
        double so2AddedMgL,
        List<Nutrient> nutrientsAdded,
        string justification,
        string startedAt,
        string? completedBy,
        string? observations)
        : base(StageType.Correction, ParseDate(startedAt), observations)
    {
        InitialSugarLevel = initialSugarLevel;
        FinalSugarLevel = finalSugarLevel;
        AddedSugarKg = addedSugarKg;

        InitialPh = initialPh;
        FinalPh = finalPh;

        AcidType = acidType;
        AcidAddedGl = acidAddedGl;

        So2AddedMgL = so2AddedMgL;

        //NutrientsAdded = nutrientsAdded ?? new List<Nutrient>();

        Justification = justification;
        
        CompletedBy = completedBy;
    }
    
    public CorrectionStage(AddCorrectionStageCommand command) 
        : base(StageType.Correction, ParseDate(command.startedAt), command.observations)
    {
        InitialSugarLevel = command.initialSugarLevel;
        FinalSugarLevel = command.finalSugarLevel;
        AddedSugarKg = command.addedSugarKg;

        InitialPh = command.initialPh;
        FinalPh = command.finalPh;

        AcidType = command.acidType;
        AcidAddedGl = command.acidAddedGl;

        So2AddedMgL = command.so2AddedMgL;

        //NutrientsAdded = command.nutrientsAdded ?? new List<Nutrient>();

        Justification = command.justification;
        
        CompletedBy = command.completedBy;
    }
    
    
    public override void Update(WinemakingStage updatedStage)
    {
        if (updatedStage is not CorrectionStage updated)
            throw new InvalidOperationException("Tipo incorrecto: se esperaba CorrectionStage.");

        InitialSugarLevel = updated.InitialSugarLevel;
        FinalSugarLevel = updated.FinalSugarLevel;
        AddedSugarKg = updated.AddedSugarKg;

        InitialPh = updated.InitialPh;
        FinalPh = updated.FinalPh;

        AcidType = updated.AcidType;
        AcidAddedGl = updated.AcidAddedGl;

        So2AddedMgL = updated.So2AddedMgL;

        //NutrientsAdded = updated.NutrientsAdded;
        
        Justification = updated.Justification;

        Observations = updated.Observations;
        
        CompletedAt = updated.CompletedAt;
        
        CompletedBy = updated.CompletedBy;
    }

    public override void Delete()
    {
        InitialSugarLevel = 0;
        FinalSugarLevel = 0;
        AddedSugarKg = 0;
        InitialPh = 0;
        FinalPh = 0;
        AcidType = string.Empty;
        AcidAddedGl = 0;
        So2AddedMgL = 0;
        //NutrientsAdded.Clear();
        Justification = string.Empty;

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
}