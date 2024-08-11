namespace PizzaCom.Infrastructure.EntityConfiguration;

class IngredientTypeEntityTypeConfiguration
    : IEntityTypeConfiguration<IngredientType>
{
    public void Configure(EntityTypeBuilder<IngredientType> ingredientTypeConfiguration)
    {
        ingredientTypeConfiguration.ToTable("ingredient_type");

        ingredientTypeConfiguration.Property(t => t.Id)
            .ValueGeneratedNever();

        ingredientTypeConfiguration.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}