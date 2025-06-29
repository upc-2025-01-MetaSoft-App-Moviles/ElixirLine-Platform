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
    public Guid BatchId { get; set; } // ID del lote al que pertenece la etapa
    public StageType StageType { get; set; } // Tipo de etapa (enum)
    public DateTime StartedAt { get; set; } // Fecha de inicio
    public DateTime? CompletedAt { get; set; } // Fecha de finalización (opcional)
    public string? CompletedBy { get; set; } // Nombre de la persona que completó la etapa
    public string? Observations { get; set; } // Observaciones

    // variable booleana para indicar si la etapa está completada
    public bool IsCompleted => CompletedAt.HasValue;

    protected WinemakingStage(StageType stageType, DateTime startedAt, string? observations)
    {
        StageType = stageType;
        StartedAt = startedAt;
        Observations = observations;
    }
    
    
    /// <summary>
    /// Método que debe implementar cada subclase para actualizar sus propios campos.
    /// </summary>
    public abstract void Update(WinemakingStage updatedStage);
    
    /// <summary>
    /// Método que debe implementar cada subclase para eliminar sus propios campos.
    /// </summary>
    public abstract void Delete();
    
    /// <summary>
    /// Marca la etapa como completada.
    /// </summary>
    public virtual void Complete(DateTime completedAt)
    {
        CompletedAt = completedAt;
    }

    public abstract void AssignBatchId(Guid batchId);

}
