namespace PizzaCom.Infrastructure.Models;

//TODO: rename that represent item in recipe but not recipe
/// <summary>
/// Represents a recipe for a pizza, including ingredient and its weight.
/// </summary>
public class RecipeEntity
{
    public int Id { get; set; }
    
    /// <summary>
    /// Foreign key to the Blueprint entity. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    public int BlueprintId { get; set; }

    /// <summary>
    /// Foreign key to the Ingredient entity. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    public int IngredientId { get; set; }

    /// <summary>
    /// Weight of the ingredient in the recipe.
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// Type of the recipe.
    /// </summary>
    public RecipeType Type { get; set; }

    /// <summary>
    /// Navigation property. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    public int RecipeTypeId { get; set; }

    /// <summary>
    /// Navigation property to the Blueprint entity. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    public BlueprintEntity Blueprint { get; set; }

    /// <summary>
    /// Ingredient entity.
    /// </summary>
    public IngredientEntity Ingredient { get; set; }

    public RecipeEntity() {}
}