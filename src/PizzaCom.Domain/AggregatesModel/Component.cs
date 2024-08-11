namespace PizzaCom.Domain.AggregatesModel;

public class Component : Entity
{
    private int _weight;

    private Ingredient _ingredient;

    private ComponentType _componentType;

    protected Component() {}

    public int IngredientId { get; init; }

    public int BoilerplateId { get; init; }

    public int ComponentTypeId { get; init; }

    public Component(int ingredientId, int componentTypeId, int weight) 
    {
        _weight = weight;
        IngredientId = ingredientId;
        ComponentTypeId = componentTypeId;
    }

    public int Weight => _weight;

    public string Name => _ingredient.Name;

    public decimal Cost => 
        _ingredient.CostPer100g * _weight / 100;

    public Ingredient Ingredient => _ingredient;

    public ComponentType ComponentType => _componentType;

    public IngredientType IngredientType => _ingredient.IngredientType;
}