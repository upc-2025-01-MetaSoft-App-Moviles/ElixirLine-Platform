using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class ClarificationStage : WinemakingStage
{
    public string Method { get; private set; } // Method of clarification (e.g. centrifugation, filtration)
    public string ClarifyingAgent { get; private set; } // Substance used for fining (e.g. bentonite)
    public double TurbidityBefore { get; private set; } // Clarity before treatment (in NTU)
    public double TurbidityAfter { get; private set; } // Final clarity after clarification
    public int ClarificationDays { get; private set; } // Time taken to settle solids
    
    // ========== Constructors para inicializar la clase 
    public ClarificationStage()
        : base(StageType.Clarification, string.Empty)
    {
        Method = string.Empty;
        ClarifyingAgent = string.Empty;
        TurbidityBefore = 0;
        TurbidityAfter = 0;
        ClarificationDays = 0;
    }
    
    // ========== Constructor de inicialización para la creación de una etapa de clarificación
    public ClarificationStage(DateTime startedAt, string method, string agent, double turbidityBefore, int clarificationDays)
        : base(StageType.Clarification, string.Empty)
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
        
        
        Method = method;
        ClarifyingAgent = agent;
        TurbidityBefore = turbidityBefore;
        ClarificationDays = clarificationDays;
    }
    
    // ========== Constructor de inicialización para la creación de una etapa de clarificación con command
    
    
    public void CompleteClarification(DateTime completedAt, double turbidityAfter)
    {
        TurbidityAfter = turbidityAfter;
        Complete(completedAt);
    }
}