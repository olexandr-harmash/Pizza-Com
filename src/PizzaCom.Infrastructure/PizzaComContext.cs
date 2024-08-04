using PizzaCom.Infrastructure.EntityConfiguration;
using PizzaCom.Infrastructure.Models;

namespace PizzaCom.Infrastructure;

public class PizzaComContext : DbContext, IUnitOfWork
{
    public DbSet<RecipeEntity> Recipes { get; set; }
    public DbSet<BlueprintEntity> Blueprints { get; set; }
    public DbSet<IngredientEntity> Ingredients { get; set; }
    public DbSet<RecipeType> RecipeTypes { get; set; }
    public DbSet<IngredientType> IngredientTypes { get; set; }

    public PizzaComContext(DbContextOptions<PizzaComContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("pizza_com");
        modelBuilder.ApplyConfiguration(new BlueprintEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientTypeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeTypeEntityTypeConfiguration());
    }

    public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
