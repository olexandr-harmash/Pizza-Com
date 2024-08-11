using PizzaCom.Domain.AggregatesModel;

namespace PizzaCom.API.Builders;

public class PizzaTemplateDTOBuilder
{
    private readonly PizzaTemplateDTO _pizzaTemplateDTO;

    public PizzaTemplateDTOBuilder(PizzaTemplateDTO pizzaTemplateDTO)
    {
        _pizzaTemplateDTO = pizzaTemplateDTO;
    }

    public PizzaTemplateDTOBuilder SetOptions(IEnumerable<OptionDTO> options)
    {
        _pizzaTemplateDTO.Options = options.ToList();
        return this;
    }

    public PizzaTemplateDTOBuilder SetSummary(IEnumerable<AppliedOptionDTO> appliedOptionsSummary, IEnumerable<AppliedIngredientSummaryDTO> selectedIngredients)
    {
        _pizzaTemplateDTO.Summary = new SummaryDTO
        {
            AppliedOptions = appliedOptionsSummary.ToList(),
            SelectedIngredients = selectedIngredients.ToList()
        };
        return this;
    }

    public PizzaTemplateDTO Build()
    {
        Validate();
        return _pizzaTemplateDTO;
    }

    private void Validate()
    {
        if (_pizzaTemplateDTO.Options == null)
        {
            throw new InvalidOperationException("Options must be set and cannot be empty.");
        }

        if (_pizzaTemplateDTO.Summary == null)
        {
            throw new InvalidOperationException("Summary must be set.");
        }

        if (_pizzaTemplateDTO.Summary.AppliedOptions == null)
        {
            throw new InvalidOperationException("Summary's AppliedOptions must be set and cannot be empty.");
        }

        if (_pizzaTemplateDTO.Summary.SelectedIngredients == null)
        {
            throw new InvalidOperationException("Summary's SelectedIngredients must be set and cannot be empty.");
        }
    }
}