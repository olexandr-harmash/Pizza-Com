namespace PizzaCom.API.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<PizzaComContext>("PizzaComDB");

        builder.Services.AddMigration<PizzaComContext, PizzaComContextSeed>();

        builder.Services.AddTransient<IBlueprintRepository, BlueprintRepository>();

        builder.Services.AddTransient<PizzaComServices>();
    }
}