namespace PizzaCom.Domain.BoilerplateOptionServices;

public interface IBoilerplateOptionService
{
    bool IsApplicable { get; }
    string Name { get; }
    decimal Cost { get; }
    int Times { get; }
    int MaxTimes { get; }
    void Apply();
}

public abstract class BoilerplateOptionService : IBoilerplateOptionService
{
    protected readonly int _times;

    private readonly Boilerplate _boilerplate;

    protected BoilerplateOptionService(Boilerplate boilerplate, int times)
    {
        if (times < 1 || times > MaxTimes)
        {
            throw new ArgumentOutOfRangeException(nameof(times), 
                $"The number of times should be between 0 and {MaxTimes}.");
        }

        _times = times;
        _boilerplate = boilerplate ?? throw new ArgumentNullException(nameof(boilerplate));
    }

    public abstract bool IsApplicable { get; }

    public abstract string Name { get; }

    public abstract decimal Cost { get; }

    public abstract int Times { get; }

    public abstract int MaxTimes { get; }

    protected Component? FindRecipeByName(string componentName)
    {
        return FindRecipe(c => 
            c.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase)
        );
    }

    protected Component? FindRecipeByTypeAndName(ComponentType componentType, string componentName)
    {
        return FindRecipe(c => 
            c.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase) &&
            c.ComponentType.Equals(componentType)
        );
    }

    protected List<Component> FindRecipesByType(ComponentType componentType)
    {
        return FindRecipes(c => c.ComponentType.Equals(componentType));
    }

    protected  List<Component> FindRecipesByIngredientType(IngredientType ingredientType)
    {
        return FindRecipes(c => c.Ingredient.Equals(ingredientType));
    }

    protected List<Component> FindRecipesByTypeAndIngredientType(ComponentType componentType, IngredientType ingredientType)
    {
        return FindRecipes(c => 
            c.ComponentType.Equals(componentType) && 
            c.Ingredient.Equals(ingredientType)
        );
    }
    
    /// <summary>
    /// Finds a component by name in the current components of the boilerplate.
    /// </summary>
    protected KeyValuePair<Component, float> FindComponentByName(string componentName)
    {
        return FindComponent(c => 
            c.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase)
        );
    }

    protected KeyValuePair<Component, float> FindComponentByTypeAndName(ComponentType componentType, string componentName)
    {
        return FindComponent(c => 
            c.Name.Equals(componentName, StringComparison.OrdinalIgnoreCase) &&
            c.ComponentType.Equals(componentType)
        );
    }

    protected Dictionary<Component, float> FindComponentsByType(ComponentType componentType)
    {
        return FindComponents(c => c.ComponentType.Equals(componentType));
    }

    protected Dictionary<Component, float> FindComponentsByIngredientType(IngredientType ingredientType)
    {
        return FindComponents(c => c.Ingredient.Equals(ingredientType));
    }

    protected Dictionary<Component, float> FindComponentsByTypeAndIngredientType(ComponentType componentType, IngredientType ingredientType)
    {
        return FindComponents(c => 
            c.ComponentType.Equals(componentType) && 
            c.Ingredient.Equals(ingredientType)
        );
    }

    /// <summary>
    /// Adds a component to the current components of the boilerplate.
    /// </summary>
    protected void AddComponent(Component component, float times = 1)
    {
        _boilerplate.AddComponent(component, times);
    }

    /// <summary>
    /// Removes a component from the current components of the boilerplate.
    /// </summary>
    protected void RemoveComponent(Component component, float times = 1)
    {
        _boilerplate.RemoveComponent(component, times);
    }

    private Dictionary<Component, float> FindComponents(Func<Component, bool> predicate)
    {
        return _boilerplate.ComponentsWithMultiplier
            .Where(c => predicate(c.Key))
            .ToDictionary(c => c.Key, c => c.Value);
    }

    private KeyValuePair<Component, float> FindComponent(Func<Component, bool> predicate)
    {
        return _boilerplate.ComponentsWithMultiplier
            .FirstOrDefault(c => predicate(c.Key));
    }

    private List<Component> FindRecipes(Func<Component, bool> predicate)
    {
        return _boilerplate.Components
            .Where(c => predicate(c))
            .ToList();
    }

    private Component? FindRecipe(Func<Component, bool> predicate)
    {
        return _boilerplate.Components
            .FirstOrDefault(c => predicate(c));
    }

    protected void SetTotalPrice(decimal price)
    {
        _boilerplate.SetNewPrice(_boilerplate.Price + price);
    }

    /// <summary>
    /// IsApplicable the OptionService to the boilerplate.
    /// This method should be implemented by derived classes to define specific behavior.
    /// </summary>
    public abstract void Apply();
}