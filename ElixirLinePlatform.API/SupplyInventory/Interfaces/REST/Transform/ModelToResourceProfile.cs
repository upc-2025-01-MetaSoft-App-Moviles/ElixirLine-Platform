using AutoMapper;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
using ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Resources;

namespace ElixirLinePlatform.API.SupplyInventory.Interfaces.REST.Transform;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Supply, SupplyResource>();
        
        CreateMap<SupplyUsage, SupplyUsageResource>()
            .ForMember(dest => dest.SupplyName, opt => opt.MapFrom(src => src.Supply.Name));
    }
}