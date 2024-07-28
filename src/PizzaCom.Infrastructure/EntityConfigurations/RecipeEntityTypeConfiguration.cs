namespace PizzaCom.Infrastructure.EntityConfiguration;

class RecipeEntityTypeConfiguration
    : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> recipeConfiguration)
    {
        recipeConfiguration.ToTable("recipe");

        recipeConfiguration.Ignore(b => b.DomainEvents);

        recipeConfiguration.Property(b => b.Id)
            .UseHiLo("recipeseq");

        recipeConfiguration.Property(b => b.Weight);

        recipeConfiguration.HasOne<RecipeType>()
          .WithMany()
          .HasForeignKey("_recipeTypeId");
    }
}