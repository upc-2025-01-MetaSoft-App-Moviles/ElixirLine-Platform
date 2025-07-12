namespace ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Resources;

public class SupplyResource
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = null!;
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}