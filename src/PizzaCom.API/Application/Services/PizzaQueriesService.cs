using PizzaCom.Domain.Extensions;

namespace PizzaCom.API.Application.Services;

public class PizzaQueriesService : IPizzaQueriesService
{
    private readonly ILogger<PizzaQueriesService> _logger;
    private readonly IServiceProvider _provider;

    public PizzaQueriesService(ILogger<PizzaQueriesService> logger, IServiceProvider provider)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _provider = provider ?? throw new ArgumentNullException(nameof(provider));
    }

    /// <summary>
    /// Applies a list of boilerplate option services.
    /// </summary>
    /// <param name="appliedOptions">List of boilerplate option services to apply.</param>
    public List<IBoilerplateOptionService> ApplyOptions(Boilerplate boilerplate, List<AppliedOptionRequestDTO> appliedOptions)
    {
        var options = appliedOptions
            .Select(o => _provider.ExploreOptionByKeyFromProvider(boilerplate, o.OptionName, o.TimesApplied))
            .ToList();

        if (!options.Any())
        {
            _logger.LogError("AppliedOptions list is null.");
            throw new ArgumentNullException(nameof(appliedOptions));
        }

        try
        {
            foreach (var option in options)
            {
                option.Apply();
            }

            return options;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error applying options.");
            throw;
        }
    }

    /// <summary>
    /// Sets components in the boilerplate based on the provided list of ingredients.
    /// </summary>
    /// <param name="boilerplate">The boilerplate to which components will be added.</param>
    /// <param name="ingredients">List of ingredients based on which components are set.</param>
    public void SetComponents(Boilerplate boilerplate, List<IngredientRequestDTO> ingredients)
    {
        if (!ingredients.Any())
        {
            _logger.LogError("Ingredients list is null.");
            throw new ArgumentNullException(nameof(ingredients));
        }

        try
        {
            foreach (var ingredient in ingredients)
            {
                var component = boilerplate.Components.First(c => c.IngredientId == ingredient.IngredientId);

                boilerplate.AddComponent(component);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting components in the boilerplate.");
            throw;
        }
    }

    public List<IBoilerplateOptionService> GetAvailableOptions(Boilerplate boilerplate)
    {
        try
        {
            var keys = _provider.GetOptionServiceKeys().ToList();
            _logger.LogInformation("Retrieved {Count} option service keys.", keys.Count);
            return CreateBaseOptionInfoWhereApplicable(boilerplate, keys);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving available options.");
            throw;
        }
    }

    public List<IBoilerplateOptionService> GetAvailableOptionsExcept(Boilerplate boilerplate, List<string> exceptKeys)
    {
        if (!exceptKeys.Any())
        {
            _logger.LogError("ExceptKeys list is null.");
            throw new ArgumentNullException(nameof(exceptKeys));
        }

        try
        {
            var keys = _provider.GetOptionServiceKeysExcept(exceptKeys).ToList();
            _logger.LogInformation("Retrieved {Count} option service keys, excluding specified keys.", keys.Count);
            return CreateBaseOptionInfoWhereApplicable(boilerplate, keys);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving available options, excluding specified keys.");
            throw;
        }
    }

    private List<IBoilerplateOptionService> CreateBaseOptionInfoWhereApplicable(Boilerplate boilerplate, List<string> keys)
    {
        return keys.Select(key => _provider.ExploreOptionByKeyFromProvider(boilerplate, key, 1))
            .Where(o => o.IsApplicable)
            .ToList();
    }
}