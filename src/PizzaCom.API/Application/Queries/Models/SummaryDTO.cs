namespace PizzaCom.API.Queries.Models;

public class SummaryDTO
{
    public List<AppliedIngredientSummaryDTO> SelectedIngredients { get; set; }
    public List<AppliedOptionDTO> AppliedOptions { get; set; }
}