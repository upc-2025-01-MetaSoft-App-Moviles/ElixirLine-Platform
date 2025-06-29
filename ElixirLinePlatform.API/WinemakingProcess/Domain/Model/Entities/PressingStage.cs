using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class PressingStage : WinemakingStage
{
    public string PressType { get; private set; }           // Ej: "Neumática"
    public double? PressPressureBars { get; private set; }   // Presión en bares
    public int? DurationMinutes { get; private set; }        // Duración en minutos
    public double? PomaceKg { get; private set; }            // Peso del orujo (kg)
    public double? YieldLiters { get; private set; }         // Rendimiento (L)
    public string MustUsage { get; private set; }           // Uso del mosto

    
    
    public PressingStage() : base(StageType.Pressing, DateTime.Now, null)
    {
        PressType = string.Empty;
        PressPressureBars = null;
        DurationMinutes = null;
        PomaceKg = null;
        YieldLiters = null;
        MustUsage = string.Empty;

        CompletedBy = null;
    }
        
        
    public PressingStage( 
        string pressType, 
        double pressPressureBars, 
        int durationMinutes, 
        double pomaceKg, 
        double yieldLiters, 
        string mustUsage, 
        string startedAt, 
        string? completedBy,
        string? observations)
        : base(StageType.Pressing, ParseDate(startedAt), observations)
    {
        PressType = pressType;
        PressPressureBars = pressPressureBars;
        DurationMinutes = durationMinutes;
        PomaceKg = pomaceKg;
        YieldLiters = yieldLiters;
        MustUsage = mustUsage;
        
        CompletedBy = completedBy;
    }
    
    public PressingStage(AddPressingStageCommand command) : base(StageType.Pressing, ParseDate(command.startedAt), command.observations)    {
        PressType = command.pressType;
        PressPressureBars = command.pressPressureBars;
        DurationMinutes = command.durationMinutes;
        PomaceKg = command.pomaceKg;
        YieldLiters = command.yieldLiters;
        MustUsage = command.mustUsage;

        CompletedBy = command.completedBy;
        Observations = command.observations;
    }
    

    public override void Update(WinemakingStage updatedStage)
    {
        if (updatedStage is not PressingStage updated)
            throw new InvalidOperationException("Tipo incorrecto: se esperaba PressingStage.");

        PressType = updated.PressType;
        PressPressureBars = updated.PressPressureBars;
        DurationMinutes = updated.DurationMinutes;
        PomaceKg = updated.PomaceKg;
        YieldLiters = updated.YieldLiters;
        MustUsage = updated.MustUsage;

        Observations = updated.Observations;
        CompletedAt = updated.CompletedAt;
        CompletedBy = updated.CompletedBy;
    }

    public override void Delete()
    {
        // Borrado lógico de campos propios (si se requiere restaurar a estado inicial)
        PressType = string.Empty;
        PressPressureBars = null;
        DurationMinutes = null;
        PomaceKg = null;
        YieldLiters = null;
        MustUsage = string.Empty;

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
    
    public override void AssignBatchId(Guid batchId)
    {
        BatchId = batchId;
    }
}