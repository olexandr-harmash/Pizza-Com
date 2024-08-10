
namespace PizzaCom.Domain.BoilerplateOptionServices;

/// <summary>
/// Represents an OptionService to make the pizza vegan by removing all meat components.
/// </summary>
public class AddVeganOptionService : BoilerplateOptionService
{
    private readonly Dictionary<Component, float> _meatComponents;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddVeganOptionService"/> class.
    /// </summary>
    /// <param name="boilerplate">The boilerplate to which the OptionService is applied.</param>
    public AddVeganOptionService(Boilerplate boilerplate) : base(boilerplate)
    {
        _meatComponents = FindComponentsByIngredientType(IngredientType.Meat);
    }

    /// <summary>
    /// Gets the name of the OptionService.
    /// </summary>
    public override string Name => nameof(AddVeganOptionService);

    /// <summary>
    /// Gets the price of the OptionService, which is free since it's removing meat.
    /// </summary>
    public override decimal Cost => 0m;

    /// <summary>
    /// Gets a value indicating whether the OptionService is applicable, based on the presence of meat ingredients.
    /// </summary>
    public override bool IsApplicable => 
        _meatComponents.Any() &&
        _meatComponents.All(c => 
            c.Value != 1 &&
            c.Key.ComponentType.Equals(ComponentType.Optional)
        );

    public override int Times => _times;

    public override int MaxTimes => _times; // This OptionService can be applied only once.

    /// <summary>
    /// Applies the OptionService by removing all meat components from the current components of the boilerplate.
    /// </summary>
    public override void Apply()
    {
        if (!IsApplicable)
            throw new Exception(nameof(AddVeganOptionService));

        foreach (var meatComponent in _meatComponents)
        {
            RemoveComponent(meatComponent.Key, meatComponent.Value);
        }
    }
}