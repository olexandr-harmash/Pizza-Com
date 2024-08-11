using AutoMapper;
using PizzaCom.Domain.BoilerplateOptionServices;

namespace PizzaCom.API.Profiles;

public class OptionServiceProfile : Profile
{
    public OptionServiceProfile()
    {
        CreateMap<IBoilerplateOptionService, AppliedOptionDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.Cost))
            .ForMember(dest => dest.TimesApplied, opt => opt.MapFrom(src => src.Times))
            .ForMember(dest => dest.IsApplicable, opt => opt.MapFrom(src => src.MaxTimes - src.Times > 0))
            .ForMember(dest => dest.MaxTimesApplicable, opt => opt.MapFrom(src => src.MaxTimes));
        
        CreateMap<IBoilerplateOptionService, OptionDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.CostPerApplication, opt => opt.MapFrom(src => src.Cost));

        CreateMap<IBoilerplateOptionService, AppliedOptionSummaryDTO>()
            .ForMember(dest => dest.OptionName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.TimesApplied, opt => opt.MapFrom(src => src.Times));
    }
}