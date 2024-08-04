using PizzaCom.Domain.AggregatesModel;
using PizzaCom.API.Domain.BlueprintOptions;

/// <summary>
/// Represents an option to add double meat to a blueprint.
/// </summary>
public class AddDoubleMeatOption : BlueprintOption
{
    private readonly List<Ingredient> _meatIngredients;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddDoubleMeatOption"/> class.
    /// </summary>
    /// <param name="blueprint">The blueprint to which the option is applied.</param>
    public AddDoubleMeatOption(Blueprint blueprint) : base(blueprint)
    {
        _meatIngredients = _blueprint.Included
            .Where(r => r.Type.Equals(IngredientType.Meat))
            .ToList();
    }

    /// <summary>
    /// Gets the name of the option.
    /// </summary>
    public override string Name => nameof(AddDoubleMeatOption);

    /// <summary>
    /// Gets the price of the option, calculated based on the meat ingredients in the recipe.
    /// </summary>
    public override decimal Price => _meatIngredients.Sum(i => i.Cost);

    /// <summary>
    /// Gets a value indicating whether the option is available based on the presence of meat ingredients.
    /// </summary>
    public override bool IsAvailable => _meatIngredients.Any();

    /// <summary>
    /// Executes the option, doubling the weight of all meat ingredients in the blueprint.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the option is not available (i.e., no meat ingredients found in the recipe).
    /// </exception>
    public override void ExecuteOption()
    {
        if (!IsAvailable)
        {
            throw new InvalidOperationException("No meat ingredients found in the recipe.");
        }

        foreach (var meatIngredient in _meatIngredients)
        {
            _blueprint.ChangeIngredientWeight(meatIngredient, meatIngredient.Weight * 2);
        }
    }
}
