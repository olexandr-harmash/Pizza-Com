using PizzaCom.Infrastructure;

public class BlueprintRepository : IBlueprintRepository
{
    private readonly PizzaComContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public BlueprintRepository(PizzaComContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Blueprint Add(Blueprint blueprint)
    {
        return _context.Blueprints.Add(blueprint).Entity;
    }
}