namespace PizzaCom.API.Application;

/// <summary>
/// Factory class for creating a Blueprint using the BlueprintBuilder.
/// </summary>
public class BlueprintFactory
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BlueprintFactory"/> class.
    /// </summary>
    public BlueprintFactory() {}

    /// <summary>
    /// Creates a Blueprint with the specified options.
    /// </summary>
    /// <param name="options">The options to apply to the blueprint.</param>
    /// <returns>The constructed <see cref="Blueprint"/> instance.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the blueprint is not found.</exception>
    public Blueprint BlueprintWithOptions(BlueprintOptions options, Blueprint blueprint)
    {
        if (blueprint is null)
            throw new KeyNotFoundException("Blueprint not found.");

        var builder = new BlueprintBuilder(blueprint);

        if (options.AddDoubleMeatOption)
        {
            builder.AddDoubleMeatOption();
        }

        foreach (var excludedIngredientId in options.ExcludedIngredientIds)
        {
            builder.ExcludeIngredientById(excludedIngredientId);
        }

        return builder.Build();
    }

    /// <summary>
    /// Gets the details of a specified option for a given blueprint.
    /// </summary>
    /// <param name="blueprint">The blueprint for which to get the option details.</param>
    /// <param name="optionName">The name of the option to retrieve details for.</param>
    /// <returns>An <see cref="OptionDetails"/> object representing the option details, or null if the option is not found.</returns>
    //TODO: refactor new AddDoubleMeatOption(blueprint) execute in builder and factory in one use case and call his constructor with calculations twice
    public OptionDetails? GetOptionDetails(Blueprint blueprint, string optionName)
    {
        var option = optionName switch
        {
            nameof(AddDoubleMeatOption) => new AddDoubleMeatOption(blueprint),
            _ => null
        };

        return option?.IsAvailable == true
            ? new OptionDetails(option)
            : null;
    }
}
