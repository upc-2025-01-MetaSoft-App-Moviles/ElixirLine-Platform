using ElixirLinePlatform.API.Shared.Domain.Services.Communication;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;

namespace ElixirLinePlatform.API.SupplyInventory.Domain.Services.Communication;

public class SupplyResponse : BaseResponse<Supply>
{
    public SupplyResponse(Supply resource) : base(resource)
    {
    }

    public SupplyResponse(string message) : base(message)
    {
    }
}