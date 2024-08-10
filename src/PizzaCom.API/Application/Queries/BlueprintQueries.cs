using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using PizzaCom.Domain.Extensions;
using PizzaCom.Domain.AggregatesModel;
using PizzaCom.Domain.BoilerplateOptionServices;
using PizzaCom.Domain.Models;
using AutoMapper;
//using PizzaCom.Infrastructure.Repositories;

namespace PizzaCom.API.Queries;

/// <summary>
/// Provides queries for retrieving blueprint-related data.
/// </summary>
public class BlueprintQueries : IBlueprintQueries
{
    private readonly PizzaComContext _context;
    private readonly IServiceProvider _provider;
    private readonly IMapper _mapper;
    private readonly ILogger<BlueprintQueries> _logger;


    //private IBlueprintRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlueprintQueries"/> class.
    /// </summary>
    /// <param name="context">The database context to use.</param>
    public BlueprintQueries(PizzaComContext context, ILogger<BlueprintQueries> logger, IServiceProvider provider, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
        _provider = provider;
    }

    public async Task<PizzaTemplateDTO> GetBlueprintBuilder(CreateOrUpdatePizzaTemplateRequestDTO request)
    {
        // Получение деталей шаблона пиццы
        var boilerplate = await GetBoilerplateDetailsByIdOrThrowExceptionAsync(request.PizzaTemplateId);

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
  
        var boilerplateBuiltModel = _mapper.Map<PizzaTemplateDTO>(boilerplate);
        boilerplateBuiltModel.AppliedOptions = _mapper.Map<List<AppliedOptionDTO>>(appliedOptions);
        boilerplateBuiltModel.Options = _mapper.Map<List<OptionDTO>>(availableOptions);
        boilerplateBuiltModel.Summary = new SummaryDTO 
        {
            AppliedOptions = _mapper.Map<List<AppliedOptionSummaryDTO>>(appliedOptions),
            SelectedIngredients = _mapper.Map<List<AppliedIngredientSummaryDTO>>(boilerplate.ComponentsWithMultiplier.Keys)
        };

        return boilerplateBuiltModel;
    }

    public async Task<List<BlueprintCard>> GetBlueprintCards()
    {
        return await _context.Boilerplates
            .Include(b => b.Components)
                .ThenInclude(c => c.Ingredient)
            .Select(b => new BlueprintCard
            {
                Id = b.Id,
                Name = b.Title,
                Price = b.Price
            })
            .ToListAsync();
    }

    public async Task<BoilerplateDetails> GetBoilerplateDetails(int id)
    {   
        var boilerplate = await GetBoilerplateDetailsByIdOrThrowExceptionAsync(id);

        var optionServiceInfo = _provider.GetRequiredService<IOptions<OptionServiceInfo>>().Value;

        var applicableOptions = optionServiceInfo.OptionServiceTypes.Keys
            .Select(k => _provider.ExploreOptionByKeyFromProvider(boilerplate, k, 1))
            .Where(option => option.IsApplicable)
            .ToList();

        // Использование AutoMapper для маппинга данных
        var boilerplateDetails = _mapper.Map<BoilerplateDetails>(boilerplate);
        boilerplateDetails.Options = _mapper.Map<List<OptionDetailDto>>(applicableOptions);

        return boilerplateDetails;
    }

    private async Task<Boilerplate> GetBoilerplateDetailsByIdOrThrowExceptionAsync(int id)
    {
        var result = await _context.Boilerplates
            .Include(b => b.Components)
                .ThenInclude(c => c.ComponentType)
            .Include(b => b.Components)
                .ThenInclude(c => c.Ingredient)
                    .ThenInclude(i => i.IngredientType)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (result == null)
        {
            throw new Exception("Boilerplate not found");
        }

        return result;
    }
}
