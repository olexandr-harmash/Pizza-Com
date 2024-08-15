namespace PizzaCom.API.Queries.Models;

public class GetPizzaTemplateDTO
{
    public List<IngredientRequestDTO> Ingredients { get; set; } // Список ингредиентов
    public List<AppliedOptionRequestDTO> AppliedOptions { get; set; } // Список примененных опций

    public List<string> GetKeys()
    {
        return AppliedOptions.Select(o => o.OptionName).ToList();
    }
}
