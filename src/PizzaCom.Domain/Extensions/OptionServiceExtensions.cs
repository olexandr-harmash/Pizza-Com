using PizzaCom.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace PizzaCom.Domain.Extensions;

/// <summary>
/// Provides extension methods for registering and exploring option services in the application's dependency injection container.
/// </summary>
public static class OptionServiceExtensions
{
    /// <summary>
    /// Registers an option service of type <typeparamref name="T"/> associated with an interface IBoilerplateOptionService/> 
    /// in the application's service collection.
    /// </summary>
    /// <typeparam name="T">The concrete type of the option service to register.</typeparam>
    /// <param name="builder">The <see cref="IHostApplicationBuilder"/> instance.</param>
    /// <returns>The modified <see cref="IHostApplicationBuilder"/> instance for chaining.</returns>
    public static IHostApplicationBuilder RegisterOptionKeyInProvider<T>(this IHostApplicationBuilder builder)
        where T : IBoilerplateOptionService
    {
        builder.Services.Configure<OptionServiceInfo>(o => {
            o.OptionServiceTypes[typeof(T).Name] = typeof(T);       
        });

        return builder;
    }

    /// <summary>
    /// Creates an instance of an option service based on the specified option key.
    /// </summary>
    /// <param name="serviceProvider">The <see cref="ServiceProvider"/> instance.</param>
    /// <param name="boilerplate">The <see cref="Boilerplate"/> instance to which the option service is applied.</param>
    /// <param name="optionKey">The key that identifies the option service.</param>
    /// <param name="quantity">The quantity or times the option service should be applied.</param>
    /// <returns>An instance of <see cref="IBoilerplateOptionService"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when the option key is not found in the registered services.</exception>
    public static IBoilerplateOptionService ExploreOptionByKeyFromProvider(this IServiceProvider serviceProvider, Boilerplate boilerplate, string optionKey, int quantity)
    {    
        var optionServiceInfo = serviceProvider.GetRequiredService<IOptions<OptionServiceInfo>>().Value;

        if (!optionServiceInfo.OptionServiceTypes.TryGetValue(optionKey, out var optionType))
        {
            throw new ArgumentException($"Option service not found for name: {optionKey}");
        }

        var optionService = (IBoilerplateOptionService)ActivatorUtilities.CreateInstance(serviceProvider, optionType, boilerplate, quantity);
        
        return optionService;
    }
}