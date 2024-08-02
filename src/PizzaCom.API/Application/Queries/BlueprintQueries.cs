using Microsoft.EntityFrameworkCore;
using PizzaCom.API.Application;
using PizzaCom.API.Models;

namespace PizzaCom.API.Queries;

/// <summary>
/// Provides queries for retrieving blueprint-related data.
/// </summary>
public class BlueprintQueries : IBlueprintQueries
{
    private PizzaComContext _context;

    private BlueprintFactory _factory;

    ILogger<BlueprintQueries> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlueprintQueries"/> class.
    /// </summary>
    /// <param name="context">The database context to use.</param>
    public BlueprintQueries(PizzaComContext context, BlueprintFactory factory, ILogger<BlueprintQueries> logger)
    {
        _context = context;
        _factory = factory;
        _logger = logger;
    }

    /// <summary>
    /// Gets the blueprint builder for the specified blueprint ID.
    /// </summary>
    /// <param name="blueprintId">The ID of the blueprint.</param>
    /// <returns>A <see cref="BlueprintBuilder"/> object representing the blueprint.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the blueprint is not found.</exception>
    public async Task<BlueprintBuilderModel> GetBlueprintBuilder(BlueprintOptions options)
    {
        var blueprint = await _context.Blueprints
            .Include(b => b.Recipe)
            .ThenInclude(r => r.Ingredient)
            .ThenInclude(i => i.Type)
            .Include(b => b.Recipe)           
            .ThenInclude(r => r.Type)      
            .FirstOrDefaultAsync(b => b.Id == options.Id);
        
        var builtBlueprint = await _factory.BlueprintWithOptions(options, blueprint);

        // Вернуть модель с данными
        return new BlueprintBuilderModel
        {
            Id = builtBlueprint.Id,
            Name = builtBlueprint.Name,
            Price = builtBlueprint.BaseCost,
            AddDoubleMeatOption = _factory.GetOptionDetails(builtBlueprint, nameof(AddDoubleMeatOption)),
            BlueprintBuilderRecipeItems = builtBlueprint.Recipe.Select(r => new BlueprintBuilderRecipeItem
            {
                Id = r.Ingredient.Id,
                Name = r.Ingredient.Name,
                IsExcluded = options.ExcludedIngredientIds.Contains(r.Ingredient.Id)
            }).ToList()
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
                Recipe = string.Join(", ", b.Recipe.Select(r => r.Ingredient.Name.ToLower()))
            })
            .ToListAsync();
    }

    /// <summary>
    /// Gets a list of ingredients.
    /// </summary>
    /// <returns>A list of <see cref="BlueprintBuilderRecipeItem"/> objects representing the ingredients.</returns>
    public async Task<List<BlueprintBuilderRecipeItem>> GetIngredients() =>
        await _context.Ingredients.Select(i => new BlueprintBuilderRecipeItem { Id = i.Id, Name = i.Name }).ToListAsync();
}
