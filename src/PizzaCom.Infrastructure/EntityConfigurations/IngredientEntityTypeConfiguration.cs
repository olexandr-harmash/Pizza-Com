

namespace PizzaCom.Infrastructure.EntityConfiguration;

class IngredientEntityTypeConfiguration
    : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> ingredientConfiguration)
    {
        ingredientConfiguration.ToTable("ingredient");

        ingredientConfiguration.Property(i => i.Id)
            .UseHiLo("ingredientseq");

        ingredientConfiguration.Ignore(i => i.DomainEvents);

        ingredientConfiguration.Property(i => i.Name)
            .HasMaxLength(200)
            .IsRequired();

        ingredientConfiguration.Property(i => i.CostPer100g)
            .IsRequired();

        ingredientConfiguration.HasOne(i => i.IngredientType)
          .WithMany()
          .HasForeignKey(i => i.IngredientTypeId);
    }
}