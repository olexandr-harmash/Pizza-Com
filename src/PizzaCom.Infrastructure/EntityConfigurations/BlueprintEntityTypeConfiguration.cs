namespace PizzaCom.Infrastructure.EntityConfiguration;

class BlueprintEntityTypeConfiguration
    : IEntityTypeConfiguration<Blueprint>
{
    public void Configure(EntityTypeBuilder<Blueprint> blueprintConfiguration)
    {
        blueprintConfiguration.ToTable("blueprint");

        blueprintConfiguration.Ignore(b => b.DomainEvents);

        blueprintConfiguration.Property(b => b.Id)
            .UseHiLo("blueprintseq");

        blueprintConfiguration.Property(b => b.Name)
            .HasMaxLength(200);

        blueprintConfiguration.Property(b => b.BaseCost);

        blueprintConfiguration.HasMany("_ingredients")
            .WithMany("_blueprints")
            .UsingEntity(
                typeof(Recipe), 
                l => l.HasOne("_ingredient").WithMany("_recipe").HasForeignKey("_ingredientId"),
                r => r.HasOne("_blueprint").WithMany("_recipe").HasForeignKey("_blueprintId")
            );
    }
}