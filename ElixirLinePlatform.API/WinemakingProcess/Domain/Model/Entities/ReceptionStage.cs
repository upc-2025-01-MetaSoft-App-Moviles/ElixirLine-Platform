using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.AddStage;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands.UpdateStage;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class ReceptionStage : WinemakingStage
{
    
    
    public double SugarLevel { get; private set; } // Nivel de azúcar
    public double PH { get; private set; } // Acidez inicial
    public double Temperature { get; private set; } // Temperatura al recibir
    public double QuantityKg { get; private set; } // Peso total del lote

    
    public ReceptionStage() : base(StageType.Reception, DateTime.Now, null)
    {
        SugarLevel = 0;
        PH = 0;
        Temperature = 0;
        QuantityKg = 0;
        
        CompletedBy = null;
    }
    
    
    public ReceptionStage( double sugarLevel, double pH, double temperature, double quantityKg, string startedAt, string completedBy, string observations)
        : base(StageType.Reception, ParseDate(startedAt), observations)
    {
        SugarLevel = sugarLevel;
        PH = pH;
        Temperature = temperature;
        QuantityKg = quantityKg;
        
        CompletedBy = completedBy;
    }
    
    public ReceptionStage(AddReceptionStageCommand command)
        : base(StageType.Reception, ParseDate(command.startedAt), command.observations)
    {
        SugarLevel = command.sugarLevel;
        PH = command.pH;
        Temperature = command.temperature;
        QuantityKg = command.quantityKg;
        
        CompletedBy = command.completedBy;
    }
    
    public void Update(UpdateReceptionStageCommand command)
    {
        if (command == null) throw new ArgumentNullException(nameof(command));
        
        StartedAt = ParseDate(command.StartedAt);
        CompletedBy = command.CompletedBy;
        IsCompleted = command.IsCompleted;
        SugarLevel = command.SugarLevel;
        PH = command.Ph;
        Temperature = command.Temperature;
        QuantityKg = command.QuantityKg;
        CompletedAt = command.IsCompleted ? DateTime.Now : null;
        Observations = command.Observations;
    }

    
    public override void Delete()
    {
        // En caso de lógica específica como "resetear campos"
        SugarLevel = 0;
        PH = 0;
        Temperature = 0;
        QuantityKg = 0;
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