namespace PizzaCom.API.Models;

public class BoilerplateSetUpOptionServices
{
    public int Id { get; init; }
    public bool AddDoubleMeatOptionService { get; init; }
    public bool AddCheeseRimOptionService { get; init; }
    public bool AddVeganOptionService { get; init; }
    public bool AddCornOptionService { get; init; }
    public List<int> ExcludedIngredientIds { get; init; } = [];
}