namespace PizzaCom.API.Queries.Models;

public class PizzaDTO
{
    public int PizzaTemplateId  { get; init; }
    public string PizzaTemplateName { get; init; }
    public string Recipe { get; init; }
    public decimal TotalCost { get; init; }
}