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

    [TestMethod]
    public void AddIngredient_ShouldAddIngredient_WhenIngredientIsInRecipe()
    {
        // Arrange
        var ingredient = new Ingredient("Tomato", 0.5m, IngredientType.Vegetable);
        var recipe = new Recipe(ingredient, 50, RecipeType.Base);
        var blueprint = new Blueprint("Veggie Pizza", 10m, new List<Recipe> { recipe });

        // Act
        blueprint.AddIngredient(recipe);

        // Assert
        Assert.IsTrue(blueprint.Ingredients.Contains(recipe));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddIngredient_ShouldThrowException_WhenIngredientIsNotInRecipe()
    {
        // Arrange
        var ingredient = new Ingredient("Cheese", 1.5m, IngredientType.Dairy);
        var recipe = new Recipe(ingredient, 50, RecipeType.Optional);
        var blueprint = new Blueprint("Veggie Pizza", 10m, new List<Recipe>());

        // Act
        blueprint.AddIngredient(recipe);
    }

    // Тесты для метода ChangeIngredientWeight

    [TestMethod]
    public void ChangeIngredientWeight_ShouldChangeWeight_WhenIngredientIsInIncluded()
    {
        // Arrange
        var ingredient = new Ingredient("Pepperoni", 2.0m, IngredientType.Meat);
        var recipe = new Recipe(ingredient, 50, RecipeType.Base);
        var blueprint = new Blueprint("Pepperoni Pizza", 15m, new List<Recipe> { recipe });
        blueprint.AddIngredient(recipe);

        // Act
        blueprint.ChangeIngredientWeight(recipe, 75);

        // Assert
        var updatedRecipe = blueprint.Ingredients.FirstOrDefault(i => i.Equals(recipe));
        Assert.IsNotNull(updatedRecipe);
        Assert.AreEqual(75, updatedRecipe.Weight);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ChangeIngredientWeight_ShouldThrowException_WhenIngredientIsNotInIncluded()
    {
        // Arrange
        var ingredient = new Ingredient("Mushroom", 1.0m, IngredientType.Vegetable);
        var recipe = new Recipe(ingredient, 50, RecipeType.Base);
        var blueprint = new Blueprint("Mushroom Pizza", 12m, new List<Recipe> { recipe });

        var fakeIngredient = new Ingredient("Potato", 1.0m, IngredientType.Vegetable);
        var fakeRecipe = new Recipe(fakeIngredient, 50, RecipeType.Base);
        
        // Act
        blueprint.ChangeIngredientWeight(fakeRecipe, 75);
    }
}
