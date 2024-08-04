using PizzaCom.API.Domain.BlueprintOptions;

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
public class BlueprintBuilderModel
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
    /// Gets the base price of the blueprint.
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Gets a value indicating whether the double meat option is available.
    /// </summary>
    public OptionDetails? AddDoubleMeatOption { get; init; }

    /// <summary>
    /// Gets the list of recipe items for the blueprint.
    /// </summary>
    public List<IngredientDTO> Included { get; init; }

    /// <summary>
    /// Gets the list of excluded recipe items for the blueprint.
    /// </summary>
    public List<IngredientDTO> Excluded { get; init; }
}

public class OptionDetails
{
    public string Name  { get; init; }

    public decimal Price { get; init; }

    public OptionDetails(BlueprintOption option)
    {
        if (option == null)
        {
            throw new ArgumentNullException(nameof(option));
        }

        Name = option.Name;
        Price = option.Price;
    }
}

/// <summary>
/// Represents an item in a blueprint builder recipe.
/// </summary>
public class IngredientDTO
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
