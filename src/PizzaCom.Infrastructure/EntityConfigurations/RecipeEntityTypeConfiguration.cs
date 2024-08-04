using PizzaCom.Infrastructure.Models;

namespace PizzaCom.Infrastructure.EntityConfiguration;

class RecipeEntityTypeConfiguration
    : IEntityTypeConfiguration<RecipeEntity>
{
    public void Configure(EntityTypeBuilder<RecipeEntity> recipeConfiguration)
    {
        recipeConfiguration.ToTable("recipe");

        recipeConfiguration.Property(b => b.Id)
            .UseHiLo("recipeseq");

        recipeConfiguration.Property(b => b.Weight)
            .IsRequired();

        recipeConfiguration.HasOne(r => r.Type)
          .WithMany()
          .HasForeignKey(r => r.RecipeTypeId);
    }
}