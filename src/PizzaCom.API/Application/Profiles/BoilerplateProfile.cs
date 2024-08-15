using AutoMapper;

namespace PizzaCom.API.Profiles;

public class BoilerplateProfile : Profile
{
    public BoilerplateProfile()
    {
        CreateMap<Boilerplate, PizzaDTO>()
            .ForMember(dest => dest.Recipe, opt => opt.MapFrom(src => src.Recipe))
            .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.PizzaTemplateName, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.PizzaTemplateId, opt => opt.MapFrom(src => src.Id));

        CreateMap<Boilerplate, PizzaDetailsDTO>()
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Components.Where(c => c.ComponentType.Equals(ComponentType.Default))))
            .IncludeBase<Boilerplate, PizzaDTO>();  

        CreateMap<Boilerplate, PizzaTemplateDTO>()
            .IncludeBase<Boilerplate, PizzaDetailsDTO>(); 
    }
}