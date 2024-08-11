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

    public async Task<List<Boilerplate>> GetBoilerplateDTOsAsync()
    {
        return await _context.Boilerplates
            .Include(b => b.Components)
                .ThenInclude(c => c.Ingredient)
            .ToListAsync();
    }

    public async Task<Boilerplate> GetBoilerplateDetailsByIdAsync(int id)
    {
        var result = await _context.Boilerplates
            .Include(b => b.Components)
                .ThenInclude(c => c.ComponentType)
            .Include(b => b.Components)
                .ThenInclude(c => c.Ingredient)
                    .ThenInclude(i => i.IngredientType)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (result == null)
        {
            throw new KeyNotFoundException("Boilerplate not found");
        }

        return result;
    }
}