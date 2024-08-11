namespace PizzaCom.Infrastructure.EntityConfiguration;

class ComponentTypeEntityTypeConfiguration
    : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> recipeTypeConfiguration)
    {
        recipeTypeConfiguration.ToTable("component_type");

        recipeTypeConfiguration.Property(r => r.Id)
            .ValueGeneratedNever();

        recipeTypeConfiguration.Property(r => r.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}