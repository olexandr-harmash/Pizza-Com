using PizzaCom.Domain.AggregatesModel;

namespace PizzaCom.API.Controllers;

public class PizzaComServices(
    ILogger<PizzaComServices> logger,
    IBlueprintRepository repository)
{
    public ILogger<PizzaComServices> Logger { get; } = logger;
    public IBlueprintRepository Repository { get; } = repository;
}