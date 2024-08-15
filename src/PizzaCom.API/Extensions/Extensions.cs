using PizzaCom.API.Application.Behaviors;
using PizzaCom.Domain.BoilerplateOptionServices;
using PizzaCom.Domain.Extensions;
using PizzaCom.Infrastructure.Repositories;

namespace PizzaCom.API.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Program));

        builder.AddNpgsqlDbContext<PizzaComContext>("PizzaComDB");

        builder.Services.AddMigration<PizzaComContext, PizzaComContextSeed>();

        builder.Services.AddScoped<IPizzaQueriesService, PizzaQueriesService>();
        builder.Services.AddScoped<IBoilerplateRepository, BoilerplateRepository>();
        builder.Services.AddScoped<IPizzaQueries, PizzaQueries>();
        builder.Services.AddScoped<PizzaComServices>();

        builder.RegisterOptionKeyInProvider<AddDoubleMeatOptionService>();
        builder.RegisterOptionKeyInProvider<AddVeganOptionService>();
        builder.RegisterOptionKeyInProvider<AddCornOptionService>();
        builder.RegisterOptionKeyInProvider<AddGlutenFreeCrustOptionService>();
        builder.RegisterOptionKeyInProvider<AddCheeseRimOptionService>();

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(Program));

            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
    }
}