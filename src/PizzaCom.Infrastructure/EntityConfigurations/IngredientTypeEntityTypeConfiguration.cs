namespace PizzaCom.Infrastructure.EntityConfiguration;

class IngredientTypeEntityTypeConfiguration
    : IEntityTypeConfiguration<IngredientType>
{
    public void Configure(EntityTypeBuilder<IngredientType> ingredientTypeConfiguration)
    {
        ingredientTypeConfiguration.ToTable("ingredient_type");

        ingredientTypeConfiguration.Property(bp => bp.Id)
            .ValueGeneratedNever();

        ingredientTypeConfiguration.Property(bp => bp.Name)
            .HasMaxLength(200);
    }
}