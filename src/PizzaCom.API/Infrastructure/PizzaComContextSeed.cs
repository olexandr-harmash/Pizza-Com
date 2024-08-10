using PizzaCom.Domain.AggregatesModel;
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

        if (!context.ComponentTypes.Any())
        {
            context.ComponentTypes.AddRange(GetPredefinedRecipeTypes());

            await context.SaveChangesAsync();
        }

        if (!context.Ingredients.Any())
        {
            context.Ingredients.AddRange(
                new Ingredient("Pepperoni", 1.75m, IngredientType.Meat.Id),
                new Ingredient("Sausage", 2.00m, IngredientType.Meat.Id),
                new Ingredient("Chicken", 2.50m, IngredientType.Meat.Id),
                new Ingredient("Bacon", 2.20m, IngredientType.Meat.Id),
                new Ingredient("Tomato", 1.20m, IngredientType.Vegetable.Id),
                new Ingredient("Onion", 1.10m, IngredientType.Vegetable.Id),
                new Ingredient("Bell Pepper", 1.30m, IngredientType.Vegetable.Id),
                new Ingredient("Olives", 1.40m, IngredientType.Vegetable.Id),
                new Ingredient("Mushrooms", 1.50m, IngredientType.Vegetable.Id),
                new Ingredient("Mozzarella", 3.25m, IngredientType.Dairy.Id),
                new Ingredient("Cheddar", 3.00m, IngredientType.Dairy.Id),
                new Ingredient("Gouda", 3.50m, IngredientType.Dairy.Id),
                new Ingredient("Parmesan", 3.75m, IngredientType.Dairy.Id),
                new Ingredient("Feta", 3.20m, IngredientType.Dairy.Id),
                new Ingredient("Gluten Crust", 2.50m, IngredientType.Grain.Id),
                new Ingredient("Gluten-Free Crust", 3.00m, IngredientType.Grain.Id),
                new Ingredient("Whole Wheat Crust", 2.75m, IngredientType.Grain.Id),
                new Ingredient("Thin Crust", 2.20m, IngredientType.Grain.Id),
                new Ingredient("Shrimp", 3.00m, IngredientType.Seafood.Id),
                new Ingredient("Anchovies", 2.50m, IngredientType.Seafood.Id),
                new Ingredient("Crab", 3.50m, IngredientType.Seafood.Id),
                new Ingredient("Clams", 2.80m, IngredientType.Seafood.Id),
                new Ingredient("Basil", 0.50m, IngredientType.Herbs.Id) // Допустим, что у вас есть тип Herbs
            );
            
            context.SaveChanges();

            await context.SaveChangesAsync();
        }

        await context.SaveChangesAsync();
    }

    private static IEnumerable<IngredientType> GetPredefinedIngredientTypes()
    {
        return Enumeration.GetAll<IngredientType>();
    }

    private static IEnumerable<ComponentType> GetPredefinedRecipeTypes()
    {
        return Enumeration.GetAll<ComponentType>();
    }
}