namespace PizzaCom.Infrastructure.Repositories;

public class BoilerplateRepository : IBoilerplateRepository
{
    private readonly PizzaComContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public BoilerplateRepository(PizzaComContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Boilerplate Add(Boilerplate boilerplate)
    {
        return _context.Boilerplates.Add(boilerplate).Entity;
    }
}