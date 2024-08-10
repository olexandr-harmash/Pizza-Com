
namespace PizzaCom.Domain.BoilerplateOptionServices;

/// <summary>
/// Represents an OptionService to add cheese rim to a blueprint.
/// </summary>
public class AddCheeseRimOptionService : BoilerplateOptionService
{
    private readonly Dictionary<Component, float> _defaultDairyComponents;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddCheeseRimOptionService"/> class.
    /// </summary>
    /// <param name="boilerplate">The blueprint to which the OptionService is applied.</param>
    public AddCheeseRimOptionService(Boilerplate boilerplate, int times) : base(boilerplate, times)
    {
        _defaultDairyComponents = FindComponentsByTypeAndIngredientType(ComponentType.Default, IngredientType.Dairy);
    }

    /// <summary>
    /// Gets the name of the OptionService.
    /// </summary>
    public override string Name => nameof(AddCheeseRimOptionService);

    /// <summary>
    /// Gets the price of the OptionService, calculated based on the dairy ingredients in the recipe.
    /// </summary>
    public override decimal Cost => _defaultDairyComponents.Sum(c => c.Key.Cost) * 0.25m * _times;

    /// <summary>
    /// Gets a value indicating whether the OptionService is available based on the presence of dairy ingredients.
    /// </summary>
    public override bool IsApplicable => _defaultDairyComponents.Any();

    public override int Times => _times;

    public override int MaxTimes => 5;

    public override void Apply()
    {
        if (!IsApplicable)
            throw new Exception(nameof(AddCheeseRimOptionService));

        SetTotalPrice(Cost);

        foreach (var defaultDairyComponent in _defaultDairyComponents.Keys)
        {
            AddComponent(defaultDairyComponent, Times * 0.25f);
        }
    }
}
