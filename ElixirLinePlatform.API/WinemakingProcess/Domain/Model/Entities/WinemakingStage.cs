using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

/// <summary>
/// Clase base abstracta para una etapa del proceso de vinificación.
/// Cada etapa especializada hereda de esta clase.
/// </summary>
public abstract class WinemakingStage
{
    
  
    
    public Guid Id { get; protected set; } // ID único de la etapa
    public StageType StageType { get; set; } // Tipo de etapa (enum)
    public DateTime StartedAt { get; set; } // Fecha de inicio
    public DateTime? CompletedAt { get; set; } // Fecha de finalización (opcional)
    public string? CompletedBy { get; set; } // Nombre de la persona que completó la etapa
    public string? Observations { get; set; } // Observaciones

    public bool IsCompleted => CompletedAt.HasValue;

    protected WinemakingStage()
    { }
    
    protected WinemakingStage(StageType stageType, string? observations)
    {
        //Inicializamos atributos
        StageType = stageType;
        // Inicializar StartedAt en formato dd/MM/yyyy
        StartedAt = DateTime.Now;
        Observations = null;
        CompletedAt = null;
        CompletedBy = null;
        
        
    }

    /// <summary>
    /// Marca la etapa como completada.
    /// </summary>
    public virtual void Complete(DateTime completedAt)
    {
        CompletedAt = completedAt;
    }
    
}
