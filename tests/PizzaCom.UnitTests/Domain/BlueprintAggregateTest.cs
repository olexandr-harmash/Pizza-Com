namespace PizzaCom.UnitTests.Domain;

[TestClass]
public class BlueprintAggregateTest
{
    private readonly BlueprintFactory _factory;

    public BlueprintAggregateTest()
    {
        _factory = new BlueprintFactory();
    }

    [TestMethod]
    public void Ingredient_ShouldInitializeCorrectly()
    {
        // Arrange
        var blueprint = _factory.CreateCheesePizza();

        // Act & Assert
        Assert.IsNotNull(blueprint, "Blueprint should not be null.");
        Assert.AreEqual(1, blueprint.Id, "Blueprint ID does not match.");
        Assert.AreEqual("Cheese Pizza", blueprint.Name, "Blueprint name does not match.");
        Assert.AreEqual(10.0m, blueprint.BaseCost, "Blueprint base cost does not match.");
        Assert.AreEqual(2, blueprint.Recipes.Count, "Number of recipes does not match.");

        // Assert first recipe
        var firstRecipe = blueprint.Recipes.First();
        Assert.AreEqual(1, firstRecipe.Id, "First recipe ID does not match.");
        Assert.AreEqual(100, firstRecipe.IngredientId, "First recipe ingredient ID does not match.");
        Assert.AreEqual(2.50m, firstRecipe.CostPer100g, "First recipe cost per 100g does not match.");
        Assert.AreEqual(100, firstRecipe.Weight, "First recipe weight does not match.");
        Assert.AreEqual("Cheese", firstRecipe.Name, "First recipe name does not match.");
        Assert.AreEqual(RecipeType.Base, firstRecipe.Type, "First recipe type does not match.");
        Assert.AreEqual(IngredientType.Grain, firstRecipe.IngredientType, "First recipe ingredient type does not match.");

        // Assert second recipe
        var secondRecipe = blueprint.Recipes.Last();
        Assert.AreEqual(2, secondRecipe.Id, "Second recipe ID does not match.");
        Assert.AreEqual(101, secondRecipe.IngredientId, "Second recipe ingredient ID does not match.");
        Assert.AreEqual(1.50m, secondRecipe.CostPer100g, "Second recipe cost per 100g does not match.");
        Assert.AreEqual(50, secondRecipe.Weight, "Second recipe weight does not match.");
        Assert.AreEqual("Tomato Sauce", secondRecipe.Name, "Second recipe name does not match.");
        Assert.AreEqual(RecipeType.Base, secondRecipe.Type, "Second recipe type does not match.");
        Assert.AreEqual(IngredientType.Vegetable, secondRecipe.IngredientType, "Second recipe ingredient type does not match.");
    }
}
