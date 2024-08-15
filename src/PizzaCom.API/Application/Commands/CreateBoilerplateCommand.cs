namespace PizzaCom.API.Application.Commands;

public record CreatePizzaCommand(string Name, decimal Price, IEnumerable<ComponentDTO> Components) : IRequest<int>;