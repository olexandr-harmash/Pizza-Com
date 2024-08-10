namespace PizzaCom.API.Models;

public class BoilerplateCreateBuilderOptions
{
    public int Id { get; set; }
    public List<OptionCreateDto> Options { get; set; }
    public List<IngredientDTO2> Components { get; set; }

    
}