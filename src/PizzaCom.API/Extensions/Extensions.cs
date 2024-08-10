using PizzaCom.API.Factories;
using PizzaCom.Infrastructure.Repositories;

namespace PizzaCom.API.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<PizzaComContext>("PizzaComDB");

        builder.Services.AddMigration<PizzaComContext, PizzaComContextSeed>();

        builder.Services.AddScoped<IBoilerplateFactory, BoilerplateFactory>();
        builder.Services.AddScoped<IBlueprintQueries, BlueprintQueries>();
        builder.Services.AddScoped<IBoilerplateRepository, BoilerplateRepository>();
        builder.Services.AddScoped<PizzaComServices>();
    }
}