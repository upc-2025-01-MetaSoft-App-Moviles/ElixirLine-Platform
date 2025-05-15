using System.ComponentModel.DataAnnotations;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;

public class Supply : IEntityWithCreatedUpdatedDate
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string Category { get; set; } = null!;
    
    public DateOnly ExpirationDate { get; set; }
    
    [Required]
    public decimal Quantity { get; set; }
    
    [Required]
    public string Unit { get; set; } = null!;
    
    // Relación con SupplyUsage
    public ICollection<SupplyUsage> SupplyUsages { get; set; } = new List<SupplyUsage>();
    
    // Campos de auditoría
    [Column("CreatedAt")] 
    public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")] 
    public DateTimeOffset? UpdatedDate { get; set; }
}