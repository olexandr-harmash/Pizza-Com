using Microsoft.EntityFrameworkCore.Diagnostics;
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

    public async Task<Blueprint> GetAsync(int blueprintId)
    {
        var blueprint = await _context.Blueprints
            .Include(b => b.Recipe)
            .ThenInclude(r => r.Ingredient)      
            .FirstOrDefaultAsync(b => b.Id == blueprintId);

        return blueprint;
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}