namespace PizzaCom.UnitTests;

public class BlueprintBuilder
{
    private int _id;
    private string _name;
    private decimal _baseCost;
    private List<Recipe> _recipes;

    public BlueprintBuilder()
    {
        // Устанавливаем значения по умолчанию
        _id = 0;
        _name = "Default Pizza";
        _baseCost = 0.0m;
        _recipes = new List<Recipe>();
    }

    public BlueprintBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public BlueprintBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public BlueprintBuilder WithBaseCost(decimal cost)
    {
        _baseCost = cost;
        return this;
    }

    public BlueprintBuilder WithRecipe(Recipe recipe)
    {
        _recipes.Add(recipe);
        return this;
    }

    public Blueprint Build()
    {
        return new Blueprint(_id, _name, _baseCost, _recipes);
    }
}
