using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class ReceptionStage : WinemakingStage
{
    public double SugarLevel { get; private set; } // Nivel de azúcar
    public double PH { get; private set; } // Acidez inicial
    public double Temperature { get; private set; } // Temperatura al recibir
    public double WeightKg { get; private set; } // Peso total del lote
    public string ReceivedBy { get; private set; } // Técnico responsable
    
    public string? Observations { get; private set; } // Observaciones

    /// Constructor de inicialización para la creación de una etapa de recepción
    private ReceptionStage() : base(StageType.Reception, string.Empty)
    {
        SugarLevel = 0;
        PH = 0;
        Temperature = 0;
        WeightKg = 0;
        ReceivedBy = string.Empty;
        Observations = null;
        
    }
    
    
    public ReceptionStage(string startedAt, double sugarLevel, double pH, double temperature, double weightKg,
        string receivedBy, string? observations)
        : base(StageType.Reception, startedAt)
    {
        SugarLevel = sugarLevel;
        PH = pH;
        Temperature = temperature;
        WeightKg = weightKg;
        ReceivedBy = receivedBy;
        Observations = observations;
    }
    
    /// Constructor para la creación de una etapa de recepción con command
    
    public ReceptionStage(AddReceptionStageCommand command): this() 
    {
        if (!DateTime.TryParseExact(command.startedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA.");
        }
        
        // ========== Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        StageType = StageType.Reception;
        
        // ========== Inicializar propiedades con valores del command
        SugarLevel = command.sugarLevel;
        PH = command.pH;
        Temperature = command.temperature;
        WeightKg = command.weightKg;
        ReceivedBy = command.receivedBy;
        Observations = command.observations;
        
    }
    

}