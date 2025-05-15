using System.ComponentModel.DataAnnotations;

namespace ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Resources;

public class SaveSupplyResource
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string Category { get; set; } = null!;
    
    [Required]
    public DateOnly ExpirationDate { get; set; }
    
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Quantity { get; set; }
    
    [Required]
    public string Unit { get; set; } = null!;
}