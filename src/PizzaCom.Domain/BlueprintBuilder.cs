using PizzaCom.Domain.AggregatesModel;

namespace PizzaCom.API.Application.Builders;

/// <summary>
/// Builder class for constructing a <see cref="Blueprint"/> instance.
/// </summary>
public class BlueprintBuilder
{
    /// <summary>
    /// The blueprint being constructed.
    /// </summary>
    private readonly Blueprint _blueprint;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlueprintBuilder"/> class.
    /// </summary>
    /// <param name="blueprint">The blueprint instance to be built.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="blueprint"/> is <c>null</c>.
    /// </exception>
    public BlueprintBuilder(Blueprint blueprint)
    {
        _blueprint = blueprint ?? throw new ArgumentNullException(nameof(blueprint));
    }

    /// <summary>
    /// Adds the double meat option to the blueprint and executes it.
    /// </summary>
    public BlueprintBuilder AddDoubleMeatOption()
    {
        var addDoubleMeatOption = new AddDoubleMeatOption(_blueprint);
        addDoubleMeatOption.ExecuteOption();
        return this;
    }

    /// <summary>
    /// Excludes an ingredient from the blueprint based on its ID.
    /// </summary>
    /// <param name="ingredientId">The ID of the ingredient to exclude.</param>
    /// <returns>
    /// The current <see cref="BlueprintBuilder"/> instance, allowing for method chaining.
    /// </returns>
    public BlueprintBuilder ExcludeIngredientById(int ingredientId)
    {
        //TODO: exclude option
        var i = _blueprint.Included.FirstOrDefault(i => i.Id == ingredientId);
        _blueprint.ExcludeIngredient(i);
        return this;
    }

    /// <summary>
    /// Builds and returns the final <see cref="Blueprint"/> instance.
    /// </summary>
    /// <returns>
    /// The constructed <see cref="Blueprint"/> instance.
    /// </returns>
    public Blueprint Build()
    {
        return _blueprint;
    }
}
