namespace PizzaCom.Infrastructure.EntityConfiguration;

class IngredientEntityTypeConfiguration
    : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> ingredientConfiguration)
    {
        ingredientConfiguration.ToTable("ingredient");

        ingredientConfiguration.Ignore(b => b.DomainEvents);

        ingredientConfiguration.Property(b => b.Id)
            .UseHiLo("ingredientseq");

        ingredientConfiguration.Property(i => i.Name)
            .HasMaxLength(200);

        ingredientConfiguration.Property(i => i.Cost);

        ingredientConfiguration.HasOne(i => i.Type)
          .WithMany()
          .HasForeignKey("_ingredientTypeId");
    }
}