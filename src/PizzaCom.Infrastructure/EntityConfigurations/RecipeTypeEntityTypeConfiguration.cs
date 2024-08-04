namespace PizzaCom.Infrastructure.EntityConfiguration;

class RecipeTypeEntityTypeConfiguration
    : IEntityTypeConfiguration<RecipeType>
{
    public void Configure(EntityTypeBuilder<RecipeType> recipeTypeConfiguration)
    {
        recipeTypeConfiguration.ToTable("recipe_type");

        recipeTypeConfiguration.Property(r => r.Id)
            .ValueGeneratedNever();

        recipeTypeConfiguration.Property(r => r.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}