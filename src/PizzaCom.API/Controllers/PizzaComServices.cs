namespace PizzaCom.API.Controllers;

public class PizzaComServices(
    ILogger<PizzaComServices> logger,
    IMediator mediator,
    IPizzaQueries queries,
    IBoilerplateRepository repository,
    PizzaComContext context)
{
    public IMediator Mediator { get; set; } = mediator;
    public ILogger<PizzaComServices> Logger { get; } = logger;
    public IPizzaQueries Queries { get; } = queries;
}