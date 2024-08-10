
using PizzaCom.Infrastructure.EntityConfiguration;

namespace PizzaCom.Infrastructure;

public class PizzaComContext : DbContext, IUnitOfWork
{
    public DbSet<Component> Components { get; set; }
    public DbSet<Boilerplate> Boilerplates { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<IngredientType> IngredientTypes { get; set; }

    public PizzaComContext(DbContextOptions<PizzaComContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("pizza_com");
        modelBuilder.ApplyConfiguration(new BoilerplateEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientTypeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ComponentEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ComponentTypeEntityTypeConfiguration());
    }

    public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
