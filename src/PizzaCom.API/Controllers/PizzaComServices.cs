namespace PizzaCom.API.Controllers;

public class PizzaComServices(
    ILogger<PizzaComServices> logger,
    IBlueprintQueries queries)
{
    public ILogger<PizzaComServices> Logger { get; } = logger;
    public IBlueprintQueries Queries { get; } = queries;
}