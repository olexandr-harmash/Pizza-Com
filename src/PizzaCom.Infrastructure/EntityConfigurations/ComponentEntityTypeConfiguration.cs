namespace PizzaCom.Infrastructure.EntityConfiguration;

class ComponentEntityTypeConfiguration
    : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> recipeConfiguration)
    {
        recipeConfiguration.ToTable("component");

        recipeConfiguration.Property(c => c.Id)
            .UseHiLo("recipeseq");

        recipeConfiguration.Ignore(c => c.DomainEvents);

        recipeConfiguration.Property(c => c.Weight)
            .IsRequired();

        recipeConfiguration.HasOne(c => c.ComponentType)
            .WithMany()
            .HasForeignKey(r => r.ComponentTypeId);

        recipeConfiguration.HasOne(c => c.Ingredient)
            .WithMany()
            .HasForeignKey(c => c.IngredientId);
    }
}