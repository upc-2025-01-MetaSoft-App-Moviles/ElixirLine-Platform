using System.ComponentModel.DataAnnotations;

namespace ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Resources;

public class SaveSupplyUsageResource
{
    [Required]
    public int SupplyId { get; set; }
    
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal QuantityUsed { get; set; }
    
    [Required]
    public DateTime UsageDate { get; set; }
    
    [MaxLength(500)]
    public string? Notes { get; set; }
}