using AutoMapper;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
using ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Transform;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveSupplyResource, Supply>();
        CreateMap<SaveSupplyUsageResource, SupplyUsage>();
    }
}