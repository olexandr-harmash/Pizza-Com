namespace PizzaCom.IntegrationTests.Factory;

public class PizzaComContextFactory
{
    public static PizzaComContext Create()
    {
        var options = new DbContextOptionsBuilder<PizzaComContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .Options;

        var context = new PizzaComContext(options);
        
        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();

        return context;
    }

    public static void Destroy(PizzaComContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}