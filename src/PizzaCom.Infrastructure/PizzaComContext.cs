
using PizzaCom.Infrastructure.EntityConfiguration;
using PizzaCom.Infrastructure.Extensions;

namespace PizzaCom.Infrastructure;

public class PizzaComContext : DbContext, IUnitOfWork
{
    public DbSet<Component> Components { get; set; }
    public DbSet<Boilerplate> Boilerplates { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<IngredientType> IngredientTypes { get; set; }

    private readonly IMediator _mediator;

    public PizzaComContext(DbContextOptions<PizzaComContext> options, IMediator mediator) : base(options) 
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this);

        await base.SaveChangesAsync(cancellationToken);

        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("pizza_com");
        modelBuilder.ApplyConfiguration(new BoilerplateEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientTypeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ComponentEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ComponentTypeEntityTypeConfiguration());
    }
}
