using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Entities;

public class FieldIssue
{
    public Guid IssueId { get; private set; }
    public string Description { get; private set; }
    public IssueSeverity Severity { get; private set; }
    public DateTime ReportedAt { get; private set; }

    public FieldIssue(string description, IssueSeverity severity)
    {
        IssueId = Guid.NewGuid();
        Description = description;
        Severity = severity;
        ReportedAt = DateTime.UtcNow;
    }
}
