namespace PizzaCom.Domain.BoilerplateOptionServices;

/// <summary>
/// Represents an OptionService to add double meat to a blueprint.
/// </summary>
public class AddDoubleMeatOptionService : BoilerplateOptionService
{
    private readonly Dictionary<Component, float> _defaultMeatComponents;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddDoubleMeatOptionService"/> class.
    /// </summary>
    /// <param name="boilerplate">The blueprint to which the OptionService is applied.</param>
    public AddDoubleMeatOptionService(Boilerplate boilerplate, int times) : base(boilerplate, times)
    {
        _defaultMeatComponents = FindComponentsByTypeAndIngredientType(ComponentType.Default, IngredientType.Meat);
    }

    /// <summary>
    /// Gets the name of the OptionService.
    /// </summary>
    public override string Name => 
        nameof(AddDoubleMeatOptionService);

    /// <summary>
    /// Gets the price of the OptionService, calculated based on the default meat ingredients in the recipe.
    /// </summary>
    public override decimal Cost => 
        _defaultMeatComponents.Sum(c => c.Key.Cost) * _times;

    /// <summary>
    /// Gets a value indicating whether the OptionService is available based on the presence of default meat ingredients.
    /// </summary>
    public override bool IsApplicable => 
        _defaultMeatComponents.Any();

    public override int Times => _times;

    public override int MaxTimes => 5;

    public override void Apply()
    {
        if (!IsApplicable)
            throw new Exception(nameof(AddDoubleMeatOptionService));

        SetTotalPrice(Cost);

        foreach (var defaultMeatComponent in _defaultMeatComponents.Keys)
        {
            AddComponent(defaultMeatComponent, Times);
        }
    }
}