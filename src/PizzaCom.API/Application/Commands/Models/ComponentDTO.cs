namespace PizzaCom.API.Application.Commands.Models;

public record ComponentDTO
{
    public int IngredientId { get; init; }
    public int ComponentTypeId { get; init; }
    public int Weight { get; init; }
}