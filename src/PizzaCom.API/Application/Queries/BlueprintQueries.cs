using Microsoft.Extensions.Options;
using PizzaCom.Domain.Extensions;
using PizzaCom.Domain.Models;
using AutoMapper;
using PizzaCom.API.Builders;
using AutoMapper.Internal;
using PizzaCom.Infrastructure.Repositories;

namespace PizzaCom.API.Queries;

/// <summary>
/// Provides queries for retrieving blueprint-related data.
/// </summary>
public class BlueprintQueries : IBlueprintQueries
{
    private readonly IBoilerplateRepository _repository;
    private readonly IServiceProvider _provider;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlueprintQueries"/> class.
    /// </summary>
    /// <param name="context">The database context to use.</param>
    public BlueprintQueries(IBoilerplateRepository repository, IServiceProvider provider, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _provider = provider;
    }

    public async Task<PizzaTemplateDTO> GetBlueprintBuilder(int id, CreateOrUpdatePizzaTemplateRequestDTO request)
    {
        var boilerplate = await _repository.GetBoilerplateDetailsByIdAsync(id);

        var optionServiceInfo = _provider.GetRequiredService<IOptions<OptionServiceInfo>>().Value;

        var appliedOptions = request.AppliedOptions
            .Select(o => _provider.ExploreOptionByKeyFromProvider(boilerplate, o.OptionName, o.TimesApplied))
            .ToList();

        var availableOptions = optionServiceInfo.OptionServiceTypes.Keys
            .Except(request.GetKeys())
            .Select(key => _provider.ExploreOptionByKeyFromProvider(boilerplate, key, 1))
            .Where(o => o.IsApplicable)
            .ToList();
        
        foreach (var ingredient in request.Ingredients)
        {
            var found = boilerplate.Components.First(c => c.IngredientId.Equals(ingredient.IngredientId));

            boilerplate.AddComponent(found);
        }       
        
        appliedOptions.ForEach(o => o.Apply());
  
        var builder = new PizzaTemplateDTOBuilder(_mapper.Map<PizzaTemplateDTO>(boilerplate));

        var pizzaTemplateDTO = builder
            .SetOptions(
                _mapper.Map<List<OptionDTO>>(availableOptions)
                .Concat(_mapper.Map<List<OptionDTO>>(appliedOptions))
            )
            .SetSummary(
                _mapper.Map<List<AppliedOptionDTO>>(appliedOptions),
                _mapper.Map<List<AppliedIngredientSummaryDTO>>(boilerplate.ComponentsWithMultiplier.Keys)
            )
            .Build();

        return pizzaTemplateDTO;
    }

    public async Task<List<BoilerplateDTO>> GetBoilerplateDTOs()
    {
        var boilerplates = await _repository.GetBoilerplateDTOsAsync();

        return _mapper.Map<List<BoilerplateDTO>>(boilerplates);
    }
}