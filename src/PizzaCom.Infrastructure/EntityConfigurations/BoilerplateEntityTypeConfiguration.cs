namespace PizzaCom.Infrastructure.EntityConfiguration;

class BoilerplateEntityTypeConfiguration
    : IEntityTypeConfiguration<Boilerplate>
{
    public void Configure(EntityTypeBuilder<Boilerplate> blueprintConfiguration)
    {
        blueprintConfiguration.ToTable("boilerplate");

        blueprintConfiguration.Property(b => b.Id)
            .UseHiLo("blueprintseq");
        
        blueprintConfiguration
            .Ignore(b => b.DomainEvents);

        blueprintConfiguration
            .Ignore(b => b.Recipe);

        blueprintConfiguration
            .HasKey(b => b.Id);

        blueprintConfiguration.Property(b => b.Title)
            .HasMaxLength(200)
            .IsRequired();

        blueprintConfiguration.Property(b => b.Price)
            .IsRequired();

        blueprintConfiguration.HasMany(b => b.Components)
            .WithOne();
    }
}