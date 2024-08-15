namespace PizzaCom.API.Application.Commands.Models;

public record CreatePizzaDTO
{
    public int BoilerplateId { get; init; }
    public string BoilerplateName { get; init; }
    public decimal Price { get; init; }
    public List<ComponentDTO> Components { get; init; }
}
