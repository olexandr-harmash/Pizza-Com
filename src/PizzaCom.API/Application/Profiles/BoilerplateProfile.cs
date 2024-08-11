using AutoMapper;

namespace PizzaCom.API.Profiles;

public class BoilerplateProfile : Profile
{
    public BoilerplateProfile()
    {
        CreateMap<Boilerplate, BoilerplateDTO>()
            .ForMember(dest => dest.Recipe, opt => opt.MapFrom(src => src.Recipe))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Boilerplate, PizzaTemplateDTO>()
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => 
                src.Components
                    .Where(c => c.ComponentType.Equals(ComponentType.Default))
                    .Select(c => new IngredientDTO
                    {
                        IngredientId = c.IngredientId,
                        Name = c.Name,
                        Type = c.IngredientType.Name
                    })
            ))
            .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.PizzaTemplateName, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.PizzaTemplateId, opt => opt.MapFrom(src => src.Id));
    }
}