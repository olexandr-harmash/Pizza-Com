namespace PizzaCom.UnitTests;

public class BlueprintFactory
{
    public Blueprint CreateCheesePizza()
    {
        var builder = new BlueprintBuilder()
            .WithId(1)
            .WithName("Cheese Pizza")
            .WithBaseCost(10.0m)
            .WithRecipe(new Recipe(id: 1, ingredientId: 100, costPer100g: 2.50m, weight: 100, name: "Cheese", type: RecipeType.Base, ingredientType: IngredientType.Grain))
            .WithRecipe(new Recipe(id: 2, ingredientId: 101, costPer100g: 1.50m, weight: 50, name: "Tomato Sauce", type: RecipeType.Base, ingredientType: IngredientType.Vegetable));

        return builder.Build();
    }

    public Blueprint CreatePepperoniPizza()
    {
        var builder = new BlueprintBuilder()
            .WithId(2)
            .WithName("Pepperoni Pizza")
            .WithBaseCost(15.0m)
            .WithRecipe(new Recipe(id: 3, ingredientId: 200, costPer100g: 3.00m, weight: 150, name: "Pepperoni", type: RecipeType.Base, ingredientType: IngredientType.Meat))
            .WithRecipe(new Recipe(id: 4, ingredientId: 201, costPer100g: 1.75m, weight: 60, name: "Olives", type: RecipeType.Optional, ingredientType: IngredientType.Vegetable));

        return builder.Build();
    }
}
