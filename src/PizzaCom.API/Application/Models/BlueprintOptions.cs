namespace PizzaCom.API.Models;

public class BlueprintOptions
{
    public int Id { get; init; }
    public bool AddDoubleMeatOption { get; init; }
    public List<int> ExcludedIngredientIds { get; init; } = [];
}