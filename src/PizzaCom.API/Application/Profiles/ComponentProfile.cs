using AutoMapper;
using PizzaCom.Domain.AggregatesModel;

namespace PizzaCom.API.Profiles;

public class ComponentProfile : Profile
{
    public ComponentProfile()
    {
        CreateMap<Component, AppliedIngredientSummaryDTO>()
            .ForMember(dest => dest.IngredientName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.Id));

        CreateMap<Component, IngredientDTO>()
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.IngredientId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ComponentType.Name)) 
            .ForMember(dest => dest.AdditionalCost, opt => opt.MapFrom(src => 0));
    }
}