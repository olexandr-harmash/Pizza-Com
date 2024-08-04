namespace PizzaCom.Infrastructure.Models;

/// <summary>
/// Represents an ingredient in the pizza domain.
/// </summary>
public class IngredientEntity
{
    public int Id { get; set; }
    
    /// <summary>
    /// The name of the ingredient.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The cost of the ingredient.
    /// </summary>
    public decimal Cost { get; set; }

    /// <summary>
    /// Navigation property. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    public List<RecipeEntity> Recipe { get; set; }

    /// <summary>
    /// The type of the ingredient.
    /// </summary>
    public IngredientType Type { get; set; }

    /// <summary>
    /// Navigation property. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    public int IngredientTypeId { get; set; }

    /// <summary>
    /// Navigation property. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    public List<BlueprintEntity> Blueprints{ get; set; }

    public IngredientEntity() {}
}