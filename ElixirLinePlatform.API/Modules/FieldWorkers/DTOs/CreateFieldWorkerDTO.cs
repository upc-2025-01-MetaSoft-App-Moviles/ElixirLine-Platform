using System.ComponentModel.DataAnnotations;

namespace ElixirLinePlatform.API.Modules.FieldWorkers.DTOs;

public class CreateFieldWorkerDTO
{
    [Required]
    public string FullName { get; set; } = null!;

    [Required]
    [StringLength(8, MinimumLength = 8)]
    public string DNI { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [Phone]
    public string Phone { get; set; } = null!;
    [Required]
    public string Position { get; set; } = null!;

}
