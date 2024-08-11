namespace PizzaCom.Domain.AggregatesModel;

public class Ingredient : Entity
{
    private string _name;

    private decimal _costPer100g;

    private IngredientType _ingredientType;

    public int IngredientTypeId { get; init; }

    protected Ingredient() {}

    public Ingredient(string name, decimal costPer100g, int ingredientTypeId) 
    {
        _name = name;
        _costPer100g = costPer100g;
        IngredientTypeId = ingredientTypeId;
    }

    public string Name => _name;

    public decimal CostPer100g => _costPer100g;

    public IngredientType IngredientType => _ingredientType;
}