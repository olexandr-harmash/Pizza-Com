/// <summary>
/// Represents an OptionService to add a gluten-free crust to a blueprint.
/// </summary>
public class AddGlutenFreeCrustOptionService : BoilerplateOptionService
{   
    private readonly KeyValuePair<Component, float> _glutenCrustComponent;
    private readonly KeyValuePair<Component, float> _glutenFreeCrustComponent;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddGlutenFreeCrustOptionService"/> class.
    /// </summary>
    /// <param name="boilerplate">The blueprint to which the OptionService is applied.</param>
    public AddGlutenFreeCrustOptionService(Boilerplate boilerplate, int times = 1) : base(boilerplate)
    {   
        // Initialize the gluten-free crust component
        _glutenFreeCrustComponent = FindComponentByName(IngredientVariant.GlutenCrust.Name);

        // Initialize the gluten-free crust component
        _glutenFreeCrustComponent = FindComponentByName(IngredientVariant.GlutenFreeCrust.Name);
    }

    /// <summary>
    /// Gets the name of the OptionService.
    /// </summary>
    public override string Name => nameof(AddGlutenFreeCrustOptionService);

    /// <summary>
    /// Gets the price of the OptionService, calculated based on the gluten-free crust component.
    /// </summary>
    public override decimal Cost => _glutenFreeCrustComponent.Key.Cost - _glutenCrustComponent.Key.Cost;

    /// <summary>
    /// Gets a value indicating whether the OptionService is available based on the presence of the gluten-free crust component.
    /// </summary>
    public override bool IsApplicable => 
        _glutenCrustComponent.Key != null &&
        _glutenFreeCrustComponent.Key != null;

    public override int Times => _times;

    public override int MaxTimes => _times;

    public override void Apply()
    {
        if (!IsApplicable)
        {
            throw new InvalidOperationException("Cannot apply gluten-free crust option as it is not applicable.");
        }

        SetTotalPrice(Cost);

        // Add the gluten-free crust component to the pizza
        RemoveComponent(_glutenCrustComponent.Key);

        AddComponent(_glutenFreeCrustComponent.Key);
    }
}