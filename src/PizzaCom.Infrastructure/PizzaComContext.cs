using PizzaCom.Infrastructure.EntityConfiguration;

namespace PizzaCom.Infrastructure;

public class PizzaComContext : DbContext, IUnitOfWork
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Blueprint> Blueprints { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
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

        // modelBuilder.Entity<Blueprint>()
        // .HasMany(e => e.IngredientTest)
        // .WithMany(e => e.BlueprintTest)
        // .UsingEntity<Recipe>(
        //     l => l.HasOne(e => e.IngredientTest).WithMany(e => e.RecipeBlueprintTest).HasForeignKey(e => e.IngredientForeignKey),
        //     r => r.HasOne(e => e.BlueprintTest).WithMany(e => e.RecipeBlueprintTest).HasForeignKey(e => e.BlueprintForeignKey));
    }

    public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
