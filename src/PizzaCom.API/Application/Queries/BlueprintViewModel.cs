
using PizzaCom.Domain.AggregatesModel;
using PizzaCom.Domain.BoilerplateOptionServices;

namespace PizzaCom.API.Queries;

/// <summary>
/// Represents a blueprint card with basic blueprint information.
/// </summary>
public class BlueprintCard
{
    /// <summary>
    /// Gets the ID of the blueprint.
    /// </summary>
    public int Id  { get; init; }

    /// <summary>
    /// Gets the name of the blueprint.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Gets the recipe of the blueprint.
    /// </summary>
    public string Recipe { get; init; }

    /// <summary>
    /// Gets the price of the blueprint.
    /// </summary>
    public decimal Price { get; init; }
}

/// <summary>
/// Represents a builder for creating or modifying blueprints.
/// </summary>
public class BoilerplateBuilderModel : BoilerplateDetails
{

    public List<OptionDto2> Options { get; set; }


}

public class BoilerplateDetails
{
    public int Id  { get; init; }

    public string Name  { get; init; }

    public decimal Price { get; init; }

    public List<OptionDetailDto> Options { get; set; }

    public List<IngredientDTO> Ingredients { get; init; }
}

public class OptionDetailDto 
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
}

public class OptionServiceDetails
{
    public string Name  { get; init; }

    public decimal Price { get; init; }

    public OptionServiceDetails(BoilerplateOptionService OptionService)
    {
        if (OptionService == null)
        {
            throw new ArgumentNullException(nameof(OptionService));
        }

        Name = OptionService.Name;
        Price = OptionService.Cost;
    }
}

/// <summary>
/// Represents an item in a blueprint builder recipe.
/// </summary>
public class IngredientDTO2
{
    /// <summary>
    /// Gets the ID of the ingredient.
    /// </summary>
    public int Id  { get; init; }

    /// <summary>
    /// Gets the name of the ingredient.
    /// </summary>
    public string Name { get; init; }
}
