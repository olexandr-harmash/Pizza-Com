

using PizzaCom.Infrastructure.Repositories;

namespace PizzaCom.API.Controllers;

public class PizzaComServices(
    ILogger<PizzaComServices> logger,
    IBlueprintQueries queries,
    IBoilerplateRepository repository,
    PizzaComContext context)
{
    public ILogger<PizzaComServices> Logger { get; } = logger;
    public IBlueprintQueries Queries { get; } = queries;
    public IBoilerplateRepository Repository { get; } = repository;
    public PizzaComContext Context { get; } = context;
}