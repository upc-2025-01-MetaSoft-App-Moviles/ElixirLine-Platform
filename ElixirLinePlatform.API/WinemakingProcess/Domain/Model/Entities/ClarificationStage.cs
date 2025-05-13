using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class ClarificationStage : WinemakingStage
{
    // ========== Propiedades de la clase ClarificationStage
    public string ClarificationMethod { get; private set; } // Method of clarification (e.g. centrifugation, filtration)
    public string ClarifyingAgent { get; private set; } // Substance used for fining (e.g. bentonite)
    public double InitialTurbidityNTU { get; private set; } // Clarity before treatment (in NTU)
    public double FinalTurbidityNTU { get; private set; } // Final clarity after clarification
    public double WineVolumeLitres { get; private set; } // Volume of wine treated (in litres)
    public double ContactTimeHours { get; private set; } // Contact time (in hours)
    public double TemperatureCelsius { get; private set; } // Temperature during clarification (in Celsius)
    public string? ClarifyingAgentsUsed { get; private set; } // Clarifying agents used
    public string? DosagePerAgent { get; private set; } // Dosage per agent used
    
    // ========== Constructors para inicializar la clase 
    public ClarificationStage()
        : base(StageType.Clarification, string.Empty)
    {
        // Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = DateTime.Now;
        StageType = StageType.Clarification;
        
        
        // Inicialización de datos específicos de la etapa de clarificación
        ClarificationMethod = string.Empty;
        ClarifyingAgent = string.Empty;
        InitialTurbidityNTU = 0.0;
        FinalTurbidityNTU = 0.0;
        WineVolumeLitres = 0.0;
        ContactTimeHours = 0.0;
        TemperatureCelsius = 0.0;
        ClarifyingAgentsUsed = string.Empty;
        DosagePerAgent = string.Empty;
        CompletedBy = string.Empty;
        Observations = string.Empty;
        CompletedAt = null;
    }
    
    // ========== Constructor de inicialización para la creación de una etapa de clarificación
    public ClarificationStage( DateTime startedAt, string completedBy, string clarificationMethod, string clarifyingAgent, double initialTurbidityNTU, double finalTurbidityNTU, double wineVolumeLitres, double contactTimeHours, double temperatureCelsius, string? clarifyingAgentsUsed, string? dosagePerAgent, string? observations)
        : base(StageType.Clarification, observations)
    {
        
        if (!DateTime.TryParseExact(startedAt.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null, DateTimeStyles.None,
                out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de PressingStage.");
        }

        // Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        
        // Inicialización de datos específicos de la etapa de clarificación
        CompletedBy = completedBy;
        ClarificationMethod = clarificationMethod;
        ClarifyingAgent = clarifyingAgent;
        InitialTurbidityNTU = initialTurbidityNTU;
        FinalTurbidityNTU = finalTurbidityNTU;
        WineVolumeLitres = wineVolumeLitres;
        ContactTimeHours = contactTimeHours;
        TemperatureCelsius = temperatureCelsius;
        ClarifyingAgentsUsed = clarifyingAgentsUsed;
        DosagePerAgent = dosagePerAgent;
    }
    
    
    // Constructor para crear la etapa de clarificación con command
    public ClarificationStage(AddClarificationStageCommand command): this()
    {
        // ========== Validar formato de fecha
        if (!DateTime.TryParseExact(command.startedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de PressingStage.");
        }
        
        // Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        Observations = command.observation;
        
        
        // Inicialización de datos específicos de la etapa de clarificación
        CompletedBy = command.completedBy;
        ClarificationMethod = command.clarificationMethod;
        ClarifyingAgent = command.clarifyingAgent;
        InitialTurbidityNTU = command.initialTurbidityNTU;
        FinalTurbidityNTU = command.finalTurbidityNTU;
        WineVolumeLitres = command.wineVolumeLitres;
        ContactTimeHours = command.contactTimeHours;
        TemperatureCelsius = command.temperatureCelsius;
        ClarifyingAgentsUsed = command.clarifyingAgentsUsed;
        DosagePerAgent = command.dosagePerAgent;
        
    }
    
    public void CompleteClarification(DateTime completedAt, double turbidityAfter)
    {
        FinalTurbidityNTU = turbidityAfter;
        Complete(completedAt);
    }
}