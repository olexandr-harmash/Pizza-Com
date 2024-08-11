namespace PizzaCom.IntegrationTests.Factory;

public class PizzaComContextFactory
{
    public static PizzaComContext Create()
    {
        var OptionServices = new DbContextOptionServicesBuilder<PizzaComContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .OptionServices;

        var context = new PizzaComContext(OptionServices);
        
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        return context;
    }

    public static void Destroy(PizzaComContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}