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
    public StageType StageType { get; protected set; } // Tipo de etapa (enum)
    public DateTime StartedAt { get; protected set; } // Fecha de inicio
    private DateTime? CompletedAt { get; set; } // Fecha de finalización (opcional)

    public bool IsCompleted => CompletedAt.HasValue;

    protected WinemakingStage(StageType stageType, string startedAt)
    {
        if (!DateTime.TryParseExact(startedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA.");
        }
        
        Id = Guid.NewGuid();
        StageType = stageType;
        StartedAt = parsedDate;
    }

    /// <summary>
    /// Marca la etapa como completada.
    /// </summary>
    public virtual void Complete(DateTime completedAt)
    {
        CompletedAt = completedAt;
    }
}
