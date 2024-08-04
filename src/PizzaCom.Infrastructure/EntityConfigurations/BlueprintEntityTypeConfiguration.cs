using PizzaCom.Infrastructure.Models;

namespace PizzaCom.Infrastructure.EntityConfiguration;

class BlueprintEntityTypeConfiguration
    : IEntityTypeConfiguration<BlueprintEntity>
{
    public void Configure(EntityTypeBuilder<BlueprintEntity> blueprintConfiguration)
    {
        blueprintConfiguration.ToTable("blueprint");

        blueprintConfiguration.Property(b => b.Id)
            .UseHiLo("blueprintseq");

        blueprintConfiguration.Property(b => b.Name)
            .HasMaxLength(200)
            .IsRequired();

        blueprintConfiguration.Property(b => b.BaseCost)
            .IsRequired();

        blueprintConfiguration.HasMany(b => b.Ingredients)
            .WithMany(i => i.Blueprints)
            .UsingEntity<RecipeEntity>(
                l => l.HasOne(r => r.Ingredient).WithMany(i => i.Recipe).HasForeignKey(r => r.IngredientId),
                r => r.HasOne(r => r.Blueprint).WithMany(b => b.Recipes).HasForeignKey(r => r.BlueprintId)
            );
    }
}