using AutoMapper;
using PizzaCom.Domain.AggregatesModel;

namespace PizzaCom.API.Profiles;

public class ComponentProfile : Profile
{
    public ComponentProfile()
    {
        CreateMap<Component, IngredientDTO2>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<Component, AppliedIngredientSummaryDTO>()
            .ForMember(dest => dest.IngredientName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.Id));
    }
}