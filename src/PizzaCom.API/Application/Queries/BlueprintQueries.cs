using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.VisualBasic;
using PizzaCom.API.Factories;
using PizzaCom.Domain.BoilerplateOptionServices;
//using PizzaCom.Infrastructure.Repositories;

namespace PizzaCom.API.Queries;

/// <summary>
/// Provides queries for retrieving blueprint-related data.
/// </summary>
public class BlueprintQueries : IBlueprintQueries
{
    private PizzaComContext _context;


    private ILogger<BlueprintQueries> _logger;

    private IBoilerplateFactory _factory;

    //private IBlueprintRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlueprintQueries"/> class.
    /// </summary>
    /// <param name="context">The database context to use.</param>
    public BlueprintQueries(PizzaComContext context, ILogger<BlueprintQueries> logger, IBoilerplateFactory factory)
    {
        _context = context;
        _logger = logger;
        _factory = factory;
    }

    public async Task<BlueprintBuilderModel> GetBlueprintBuilder(BuildBoilerplateDTO OptionServices)
    {   
        var boilerplate = await _context.Boilerplates
            .Include(b => b.Components)
                .ThenInclude(c => c.ComponentType)
            .Include(b => b.Components)
                .ThenInclude(c => c.Ingredient)
                    .ThenInclude(i => i.IngredientType)
            .FirstOrDefaultAsync(b => b.Id == OptionServices.Id);

    var components = await _context.Components
            .Include(c => c.ComponentType)
            .Include(c => c.Ingredient)
            .ThenInclude(i => i.IngredientType)
            .Where(c => OptionServices.Components.Select(d => d.Id).Contains(c.Id))
            .ToListAsync();
            _logger.LogInformation($"{string.Join(",", components.Select(i => i.Id.ToString()))}");
             _logger.LogInformation($"{string.Join(",", OptionServices.Components.Select(i => i.Id.ToString()))}");


        var service =  new BoilerplateOptionBuilderService(boilerplate, OptionServices, _context);
        service.InitializeAllOptions(OptionServices.Options);
        var builtBoilerplate = await service.ConfigureBoilerplate(OptionServices);

        return new BlueprintBuilderModel
        {
            Id = builtBoilerplate.Id,
            Name = builtBoilerplate.Title,
            Price = builtBoilerplate.Price,
            Recipe = builtBoilerplate.Recipe,
            Options = service.GetAvailableOptions(),
            Ingredients = builtBoilerplate.Components
                .Select(c => new ComponentDto 
                { 
                    Id = c.Id, 
                    Name = c.Name,
                    Type = c.IngredientType.Name,
                    Selected = OptionServices.Components.Any(d => d.Id == c.Id)
                })
                .ToList(),
        };
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
                Price = b.Price,
                Recipe = b.Recipe
            })
            .ToListAsync();
    }
}
