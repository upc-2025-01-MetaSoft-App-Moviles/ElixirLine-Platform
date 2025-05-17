namespace ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Resources;

public class SupplyUsageResource
{
    public int Id { get; set; }
    public int SupplyId { get; set; }
    public string SupplyName { get; set; } = null!;
    public decimal QuantityUsed { get; set; }
    public DateTime UsageDate { get; set; }
    public string? Notes { get; set; }
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}