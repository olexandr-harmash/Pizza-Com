namespace PizzaCom.UnitTests.Domain;

[TestClass]
public class BlueprintAggregateTest
{
    [TestMethod]
    public void Ingredient_ShouldInitializeCorrectly()
    {
        // Arrange
        var ingredient = new Ingredient("Tomato", 1.0m, IngredientType.Vegetable);

        // Act & Assert
        Assert.IsNotNull(ingredient);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Ingredient_ShouldThrowArgumentNullException_WhenNameIsNull()
    {
        // Arrange & Act
        var ingredient = new Ingredient(null, 1.0m, IngredientType.Meat);
    }

    [TestMethod]
    public void Recipe_ShouldInitializeCorrectly()
    {
        // Arrange
        var ingredient = new Ingredient("Cheese", 1.5m, IngredientType.Dairy);
        var recipe = new Recipe(ingredient, 100, RecipeType.Base);

        // Act & Assert
        Assert.AreEqual(ingredient, recipe.Ingredient);
        Assert.AreEqual(100, recipe.Weight);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Recipe_ShouldThrowArgumentException_WhenWeightIsNegative()
    {
        // Arrange
        var ingredient = new Ingredient("Cheese", 1.5m, IngredientType.Dairy);

        // Act
        var recipe = new Recipe(ingredient, -10, RecipeType.Base);
    }

    [TestMethod]
    public void Blueprint_ShouldInitializeCorrectly()
    {
        var tomato = new Ingredient("Tomato", 1.0m, IngredientType.Vegetable);
        var cheese = new Ingredient("Cheese", 1.5m, IngredientType.Dairy);
        
        // Arrange
        var recipe = new List<Recipe>
        {
            new Recipe(tomato, 100, RecipeType.Base),
            new Recipe(cheese, 50, RecipeType.Optional)
        };

        var blueprint = new Blueprint("Margherita", 5.0m, recipe);

        // Act & Assert
        Assert.AreEqual("Margherita", blueprint.Name);
        Assert.AreEqual(5.0m, blueprint.BaseCost);
        Assert.AreEqual(2, blueprint.Recipe.Count);
        Assert.AreEqual(1, blueprint.Ingredients.Count);
    }
}
