using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Commands;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Entities;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Aggregate;

public partial class FieldLogEntry
{
    public Guid EntryId { get; private set; }

    // === Relaciones ===
    public Guid AuthorId { get; private set; }       
    public Guid ParcelId { get; private set; }       
    public Guid? RelatedTaskId { get; private set; } 

    // === Información de la entrada ===
    public EntryType EntryType { get; private set; } // Enum: Observation, Incident, CompletedTask
    public string Description { get; private set; }
    public DateTime Timestamp { get; private set; }

    // === Evidencias ===
    public List<string> PhotoUrls { get; private set; } = new();

    // === Incidencias detectadas (opcional) ===
    public List<FieldIssue> Issues { get; private set; } = new();

    // === Constructores ===
    public FieldLogEntry()
    {
        EntryId = Guid.NewGuid();
        Timestamp = DateTime.UtcNow;
    }

    public FieldLogEntry(CreateFieldLogEntryCommand command)
        : this()
    {
        AuthorId = command.AuthorId;
        ParcelId = command.ParcelId;
        RelatedTaskId = command.RelatedTaskId;
        EntryType = command.EntryType;
        Description = command.Description;
    }

    // === Métodos del Aggregate ===
    public void UpdateDescription(string newText)
    {
        Description = newText;
    }

    public void ReclassifyEntry(EntryType newType)
    {
        EntryType = newType;
    }

    public void AttachPhoto(string photoUrl)
    {
        if (!string.IsNullOrEmpty(photoUrl))
            PhotoUrls.Add(photoUrl);
    }

    public void AddIssue(FieldIssue issue)
    {
        if (issue != null)
            Issues.Add(issue);
    }
}