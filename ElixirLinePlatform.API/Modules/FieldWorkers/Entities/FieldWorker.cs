namespace ElixirLinePlatform.API.Modules.FieldWorkers.Entities;

public class FieldWorker
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = null!;
    public string DNI { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;

    // Posición interna dentro del rol "Trabajador de Campo"
    public string Position { get; set; } = "Campo";

    public string WorkLocation { get; set; } = "General";
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
