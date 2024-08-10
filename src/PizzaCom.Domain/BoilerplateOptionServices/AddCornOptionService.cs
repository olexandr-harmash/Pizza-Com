
namespace PizzaCom.Domain.BoilerplateOptionServices;

/// <summary>
/// Represents an OptionService to add corn to a blueprint.
/// </summary>
public class AddCornOptionService : BoilerplateOptionService
{
    private readonly Component? _cornComponent;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddCornOptionService"/> class.
    /// </summary>
    /// <param name="boilerplate">The blueprint to which the OptionService is applied.</param>
    public AddCornOptionService(Boilerplate boilerplate, int times) : base(boilerplate, times)
    {
        _cornComponent = FindRecipeByName(IngredientVariant.Corn.Name);
    }

    /// <summary>
    /// Gets the name of the OptionService.
    /// </summary>
    public override string Name => nameof(AddCornOptionService);

    /// <summary>
    /// Gets the price of the OptionService, calculated based on the default corn ingredients in the recipe.
    /// </summary>
    public override decimal Cost => _cornComponent.Cost * _times;

    /// <summary>
    /// Gets a value indicating whether the OptionService is available based on the presence of default corn ingredients.
    /// </summary>
    public override bool IsApplicable => _cornComponent != null;

    public override int Times => _times;

    public override int MaxTimes => 5;

    public override void Apply()
    {
        if (!IsApplicable)
            throw new Exception(nameof(AddCornOptionService));

        SetTotalPrice(Cost);

        AddComponent(_cornComponent, Times);
    }
}