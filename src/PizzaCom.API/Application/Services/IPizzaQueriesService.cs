namespace PizzaCom.API.Application.Services;

public interface IPizzaQueriesService
{
    /// <summary>
    /// Gets the available options for the specified boilerplate.
    /// </summary>
    /// <param name="boilerplate">The boilerplate for which options are being retrieved.</param>
    /// <returns>A list of available boilerplate option services.</returns>
    List<IBoilerplateOptionService> GetAvailableOptions(Boilerplate boilerplate);

    /// <summary>
    /// Gets the available options for the specified boilerplate, excluding the specified keys.
    /// </summary>
    /// <param name="boilerplate">The boilerplate for which options are being retrieved.</param>
    /// <param name="exceptKeys">A list of keys to be excluded from the options.</param>
    /// <returns>A list of available boilerplate option services, excluding the specified keys.</returns>
    List<IBoilerplateOptionService> GetAvailableOptionsExcept(Boilerplate boilerplate, List<string> exceptKeys);

    /// <summary>
    /// Sets components in the boilerplate based on the provided list of ingredients.
    /// </summary>
    /// <param name="boilerplate">The boilerplate to which components will be added.</param>
    /// <param name="ingredients">List of ingredients based on which components are set.</param>
    void SetComponents(Boilerplate boilerplate, List<IngredientRequestDTO> ingredients);

    /// <summary>
    /// Applies a list of boilerplate option services.
    /// </summary>
    /// <param name="appliedOptions">List of boilerplate option services to apply.</param>
    List<IBoilerplateOptionService> ApplyOptions(Boilerplate boilerplate, List<AppliedOptionRequestDTO> appliedOptions);
}
