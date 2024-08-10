using AutoMapper;
using PizzaCom.API.Models;
using PizzaCom.Domain.AggregatesModel;
using PizzaCom.Domain.BoilerplateOptionServices;

namespace PizzaCom.API.Profiles;

public class BoilerplateProfile : Profile
{
    public BoilerplateProfile()
    {
        CreateMap<Boilerplate, BoilerplateDetails>()
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Components.Where(c => c.ComponentType.Equals(ComponentType.Default))))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<Boilerplate, BuildBoilerplateDTO>()
            .IncludeBase<Boilerplate, BoilerplateDetails>();

            CreateMap<Boilerplate, PizzaTemplateDTO>()
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => 
                src.Components
                    .Where(c => c.ComponentType.Equals(ComponentType.Default))
                    .Select(c => new IngredientDTO
                    {
                        IngredientId = c.IngredientId,
                        Name = c.Name,
                        Type = c.IngredientType.Name, // Убедитесь, что этот тип соответствует вашему перечислению
                        IsSelected = src.ComponentsWithMultiplier.Keys.Any(cc => cc.Id == c.Id) // Проверяем, если компонент в текущих компонентах
                    })
            ))
            .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.PizzaTemplateName, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.PizzaTemplateId, opt => opt.MapFrom(src => src.Id));
    }
}