namespace PizzaCom.API.Queries.Models;

public class PizzaDetailsDTO : PizzaDTO
{
    public List<IngredientDTO> Ingredients { get; set; }
    public List<OptionDTO> Options { get; set; }
}
