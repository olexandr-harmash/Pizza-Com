using PizzaCom.Domain.SeedWork;

namespace PizzaCom.API.Infrastructure.Services;

public class PizzaComContextSeed : IDbSeeder<PizzaComContext>
{
    public async Task SeedAsync(PizzaComContext context)
    {
        if (!context.IngredientTypes.Any())
        {
            context.IngredientTypes.AddRange(GetPredefinedIngredientTypes());

            await context.SaveChangesAsync();
        }

        if (!context.RecipeTypes.Any())
        {
            context.RecipeTypes.AddRange(GetPredefinedRecipeTypes());

            await context.SaveChangesAsync();
        }

        await context.SaveChangesAsync();
    }

    private static IEnumerable<IngredientType> GetPredefinedIngredientTypes()
    {
        return Enumeration.GetAll<IngredientType>();
    }

    private static IEnumerable<RecipeType> GetPredefinedRecipeTypes()
    {
        return Enumeration.GetAll<RecipeType>();
    }
}