using System.ComponentModel.DataAnnotations;

namespace ElixirLinePlatform.API.Modules.FieldWorkers.DTOs;

public class UpdateFieldWorkerDTO
{
    [Required]
    public string FullName { get; set; } = null!;

    [Required]
    [Phone]
    public string Phone { get; set; } = null!;

    [Required]
    public bool IsActive { get; set; }
    [Required]
    public string Position { get; set; } = null!;

}
