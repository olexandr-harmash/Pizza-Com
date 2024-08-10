

using PizzaCom.API.Models;
using PizzaCom.Domain.AggregatesModel;

namespace PizzaCom.Domain.BoilerplateOptionServices;

public class BoilerplateOptionBuilderService
{
    private Boilerplate _boilerplate;
    private readonly BuildBoilerplateDTO _buildBoilerplateDto;
    private List<IBoilerplateOptionService> _allOptionServices;

    private readonly PizzaComContext _context;


    /// <summary>
    /// Initializes a new instance of the <see cref="PizzaCustomizationService"/> class.
    /// </summary>
    /// <param name="pizzaDto">The DTO representing the pizza with selected components and options.</param>
    public BoilerplateOptionBuilderService(Boilerplate boilerplate, BuildBoilerplateDTO buildBoilerplateDto, PizzaComContext context)
    {
        _boilerplate = boilerplate;
        _buildBoilerplateDto = buildBoilerplateDto;
        _context = context;
    }

    public List<IBoilerplateOptionService> InitializeAllOptions(List<OptionDto> currentOptions)
    {
        var optionServices = new List<Func<Boilerplate, int, IBoilerplateOptionService>>
        {
            (boilerplate, times) => new AddDoubleMeatOptionService(boilerplate, times),
            (boilerplate, times) => new AddCheeseRimOptionService(boilerplate, times),
            (boilerplate, times) => new AddCornOptionService(boilerplate, times),
            (boilerplate, times) => new AddGlutenFreeCrustOptionService(boilerplate, times)
        };

        _allOptionServices = optionServices
            .Select(createOptionService =>
            {
                var option = currentOptions.FirstOrDefault(o => o.Name == createOptionService.Method.ReturnType.Name);
                return createOptionService(_boilerplate, option?.CurrentTimesApplied ?? 1);
            })
            .ToList();

        return _allOptionServices;
    }

    /// <summary>
    /// Configures the boilerplate based on the selected components and options.
    /// </summary>
    public async Task<Boilerplate> ConfigureBoilerplate(BuildBoilerplateDTO buildBoilerplateDto)
    {
        var components = await _context.Components
            .Include(c => c.ComponentType)
            .Include(c => c.Ingredient)
            .ThenInclude(i => i.IngredientType)
            .Where(c => buildBoilerplateDto.Components.Select(d => d.Id).Contains(c.Id))
            .ToListAsync();

        if (components.Count != buildBoilerplateDto.Components.Count)
            throw new Exception("dsadada");
            
        foreach (var component in components)
        {
            _boilerplate.AddComponent(component);
        }

        // Apply selected options
        foreach (var option in _allOptionServices)
        {
            if (option.IsApplicable)
            {
                option.Apply();
            }
        }

        return _boilerplate;
    }

    /// <summary>
    /// Gets the list of available options based on the current state of the boilerplate.
    /// </summary>
    /// <returns>List of available option DTOs.</returns>
    public List<OptionDto> GetAvailableOptions()
    {
        return _allOptionServices
            .Where(o => o.IsApplicable)
            .Select(option => new OptionDto
            {
                Name = option.Name,
                Cost = option.Cost,
                Applies = option.IsApplicable,
                CanApplyAgain = option.Times < option.MaxTimes,
                MaxTimes = option.MaxTimes,
                CurrentTimesApplied = option.Times
            })
            .ToList();
    }
}