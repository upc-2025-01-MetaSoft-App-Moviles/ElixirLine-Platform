using ElixirLinePlatform.API.Shared.Domain.Services.Communication;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;

namespace ElixirLinePlatform.API.SupplyInventory.Domain.Services.Communication;

public class SupplyUsageResponse : BaseResponse<SupplyUsage>
{
    public SupplyUsageResponse(SupplyUsage resource) : base(resource)
    {
    }

    public SupplyUsageResponse(string message) : base(message)
    {
    }
}