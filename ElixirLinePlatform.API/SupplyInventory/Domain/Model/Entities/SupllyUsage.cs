using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;

public class SupplyUsage : IEntityWithCreatedUpdatedDate
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int SupplyId { get; set; }
    
    [ForeignKey("SupplyId")]
    public Supply Supply { get; set; } = null!;
    
    [Required]
    public decimal QuantityUsed { get; set; }
    
    [Required]
    public DateTime UsageDate { get; set; }
    
    [MaxLength(500)]
    public string? Notes { get; set; }
    
    // Campos de auditoría
    [Column("CreatedAt")] 
    public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")] 
    public DateTimeOffset? UpdatedDate { get; set; }
}