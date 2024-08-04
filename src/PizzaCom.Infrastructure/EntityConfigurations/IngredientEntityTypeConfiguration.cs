using PizzaCom.Infrastructure.Models;

namespace PizzaCom.Infrastructure.EntityConfiguration;

class IngredientEntityTypeConfiguration
    : IEntityTypeConfiguration<IngredientEntity>
{
    public void Configure(EntityTypeBuilder<IngredientEntity> ingredientConfiguration)
    {
        ingredientConfiguration.ToTable("ingredient");

        ingredientConfiguration.Property(b => b.Id)
            .UseHiLo("ingredientseq");

        ingredientConfiguration.Property(i => i.Name)
            .HasMaxLength(200)
            .IsRequired();

        ingredientConfiguration.Property(i => i.Cost)
            .IsRequired();

        ingredientConfiguration.HasOne(i => i.Type)
          .WithMany()
          .HasForeignKey(i => i.IngredientTypeId);
    }
}