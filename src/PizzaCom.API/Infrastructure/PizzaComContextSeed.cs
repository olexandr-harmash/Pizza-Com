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
                new Ingredient(IngredientVariant.Pepperoni.Name, 1.75m, IngredientType.Meat.Id),
                new Ingredient(IngredientVariant.Sausage.Name, 2.00m, IngredientType.Meat.Id),
                new Ingredient(IngredientVariant.Chicken.Name, 2.50m, IngredientType.Meat.Id),
                new Ingredient(IngredientVariant.Bacon.Name, 2.20m, IngredientType.Meat.Id),
                new Ingredient(IngredientVariant.Tomato.Name, 1.20m, IngredientType.Vegetable.Id),
                new Ingredient(IngredientVariant.Onion.Name, 1.10m, IngredientType.Vegetable.Id),
                new Ingredient(IngredientVariant.BellPepper.Name, 1.30m, IngredientType.Vegetable.Id),
                new Ingredient(IngredientVariant.Olives.Name, 1.40m, IngredientType.Vegetable.Id),
                new Ingredient(IngredientVariant.Mushrooms.Name, 1.50m, IngredientType.Vegetable.Id),
                new Ingredient(IngredientVariant.Mozzarella.Name, 3.25m, IngredientType.Dairy.Id),
                new Ingredient(IngredientVariant.Cheddar.Name, 3.00m, IngredientType.Dairy.Id),
                new Ingredient(IngredientVariant.Gouda.Name, 3.50m, IngredientType.Dairy.Id),
                new Ingredient(IngredientVariant.Parmesan.Name, 3.75m, IngredientType.Dairy.Id),
                new Ingredient(IngredientVariant.Feta.Name, 3.20m, IngredientType.Dairy.Id),
                new Ingredient(IngredientVariant.GlutenCrust.Name, 2.50m, IngredientType.Grain.Id),
                new Ingredient(IngredientVariant.GlutenFreeCrust.Name, 3.00m, IngredientType.Grain.Id),
                new Ingredient(IngredientVariant.WholeWheatCrust.Name, 2.75m, IngredientType.Grain.Id),
                new Ingredient(IngredientVariant.ThinCrust.Name, 2.20m, IngredientType.Grain.Id),
                new Ingredient(IngredientVariant.Shrimp.Name, 3.00m, IngredientType.Seafood.Id),
                new Ingredient(IngredientVariant.Anchovies.Name, 2.50m, IngredientType.Seafood.Id),
                new Ingredient(IngredientVariant.Crab.Name, 3.50m, IngredientType.Seafood.Id),
                new Ingredient(IngredientVariant.Clams.Name, 2.80m, IngredientType.Seafood.Id),
                new Ingredient(IngredientVariant.Basil.Name, 0.50m, IngredientType.Herbs.Id),
                new Ingredient(IngredientVariant.Corn.Name, 0.50m, IngredientType.Vegetable.Id)
            );

            await context.SaveChangesAsync();
        }

        if (!context.Boilerplates.Any())
        {
            var components = new List<Component>
            {
                // Основа пиццы
                new Component(IngredientVariant.GlutenCrust.Id, ComponentType.Default.Id, 100),

                // Ингредиенты
                new Component(IngredientVariant.Mozzarella.Id, ComponentType.Default.Id, 150),
                new Component(IngredientVariant.Tomato.Id, ComponentType.Default.Id, 100),

                // Опционально добавляем базилик
                // Убедитесь, что у вас есть базилик в списке ингредиентов, если нет, добавьте его
                new Component(IngredientVariant.Basil.Id, ComponentType.Optional.Id, 10),
                new Component(IngredientVariant.GlutenFreeCrust.Id, ComponentType.Optional.Id, 100),
                new Component(IngredientVariant.Corn.Id, ComponentType.Optional.Id, 20),
            };

            // Создание пиццы
            var boilerplate = new Boilerplate
            (
                "Margherita Pizza",
                11.50m, // Цена может измениться в зависимости от цен на ингредиенты
                components
            );

            context.Boilerplates.Add(boilerplate);

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