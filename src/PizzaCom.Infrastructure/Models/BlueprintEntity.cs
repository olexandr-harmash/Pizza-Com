namespace PizzaCom.Infrastructure.Models;

/// <summary>
/// Represents a blueprint for a pizza in the pizza domain.
/// </summary>
public class BlueprintEntity
{
    public int Id { get; init; }

    public string Name { get; set; }

    public decimal BaseCost { get; set; }

    public List<RecipeEntity> Recipes { get; set; }

    public List<IngredientEntity> Ingredients { get; set; }

    public BlueprintEntity() {}
}
