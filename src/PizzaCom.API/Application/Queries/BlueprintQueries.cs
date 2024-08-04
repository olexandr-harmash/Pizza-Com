using Microsoft.AspNetCore.Mvc.ApplicationModels;
using PizzaCom.Infrastructure.Repositories;

namespace PizzaCom.API.Queries;

/// <summary>
/// Provides queries for retrieving blueprint-related data.
/// </summary>
public class BlueprintQueries : IBlueprintQueries
{
    private PizzaComContext _context;

    private BlueprintFactory _factory;

    private ILogger<BlueprintQueries> _logger;

    private IBlueprintRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlueprintQueries"/> class.
    /// </summary>
    /// <param name="context">The database context to use.</param>
    public BlueprintQueries(PizzaComContext context, BlueprintFactory factory, ILogger<BlueprintQueries> logger, IBlueprintRepository repository)
    {
        _context = context;
        _factory = factory;
        _logger = logger;
        _repository = repository;
    }

    /// <summary>
    /// Gets the blueprint builder for the specified blueprint ID.
    /// </summary>
    /// <param name="blueprintId">The ID of the blueprint.</param>
    /// <returns>A <see cref="BlueprintBuilder"/> object representing the blueprint.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the blueprint is not found.</exception>
    public async Task<BlueprintBuilderModel> GetBlueprintBuilder(BlueprintOptions options)
    {
        var blueprint = await _repository.GetAsync(options.Id);

        if (blueprint is null)
        {
            //TODO: exception classes and exception handler in api
            throw new KeyNotFoundException("Blueprint not found.");
        }
        
        var builtBlueprint = _factory.BlueprintWithOptions(options, blueprint);

        Func<Ingredient, IngredientDTO> toDto = i => new IngredientDTO
        {
            Id = i.Id,
            Name = i.Name
        };

        // Вернуть модель с данными
        return new BlueprintBuilderModel
        {
            Id = builtBlueprint.Id,
            Name = builtBlueprint.Name,
            Price = builtBlueprint.BaseCost,
            AddDoubleMeatOption = _factory.GetOptionDetails(builtBlueprint, nameof(AddDoubleMeatOption)),
            Included = builtBlueprint.Included.Select(toDto).ToList(),
            Excluded = builtBlueprint.Excluded.Select(toDto).ToList()
        };
    }

    /// <summary>
    /// Gets a list of blueprint cards.
    /// </summary>
    /// <returns>A list of <see cref="BlueprintCard"/> objects.</returns>
    public async Task<List<BlueprintCard>> GetBlueprintCards()
    {
        //Whithout pagination for proposes in small amount (30 max)
        //TODO: select options support
        return await _context.Blueprints
            .Select(b => new BlueprintCard
            {
                Id = b.Id,
                Name = b.Name,
                Price = b.BaseCost,
                Recipe = string.Join(", ", b.Recipes.Select(r => r.Ingredient.Name.ToLower()))
            })
            .ToListAsync();
    }

    /// <summary>
    /// Gets a list of ingredients.
    /// </summary>
    /// <returns>A list of <see cref="BlueprintBuilderRecipeItem"/> objects representing the ingredients.</returns>
    public async Task<List<IngredientDTO>> GetIngredients() =>
        await _context.Ingredients.Select(i => new IngredientDTO{Id = i.Id, Name = i.Name}).ToListAsync();
}
