namespace PizzaCom.API.Builders;

public class PizzaDetailsDTOBuilder
{
    private readonly PizzaDetailsDTO _pizzaTemplateDTO;

    public PizzaDetailsDTOBuilder(PizzaDetailsDTO pizzaTemplateDTO)
    {
        _pizzaTemplateDTO = pizzaTemplateDTO;
    }

    public PizzaDetailsDTOBuilder SetOptions(IEnumerable<OptionDTO> options)
    {
        _pizzaTemplateDTO.Options = options.ToList();
        return this;
    }

    public PizzaDetailsDTO Build()
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
    }
}