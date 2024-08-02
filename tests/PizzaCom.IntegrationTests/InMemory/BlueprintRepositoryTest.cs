using PizzaCom.IntegrationTests.Factory;

namespace PizzaCom.IntegrationTests.InMemory;

//Use UnitTest Domain project to get test package references and domain factories...
[TestClass]
public class BlueprintRepositoryTests
{
    private readonly PizzaComContext _context;
    private readonly BlueprintRepository _repository;

    public TestContext TestContext { get; set; }

    public BlueprintRepositoryTests()
    {
        _context = PizzaComContextFactory.Create();
        _repository = new BlueprintRepository(_context);
    }

    //TODO: domain model fabric with ready templates and builder behavior for simplify testing
    [TestMethod]
    public async Task CreateBlueprintWithRecipe_ReturnsBlueprint()
    {
        var pizzaName = "Pepperoni Pizza";
        var ingredientName = "Pepperoni";

        // Arrange
        var ingredient = new Ingredient(ingredientName, 0.5m, IngredientType.Meat);
        var recipe = new Recipe(ingredient, 60, RecipeType.Base);
        var blueprint = new Blueprint(pizzaName, 2.5m, new List<Recipe> { recipe });

        _repository.Add(blueprint);

        await _repository.UnitOfWork.SaveChangesAsync();

        var result = await _context.Blueprints.FindAsync(blueprint.Id);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(result.Name, pizzaName);
        Assert.AreEqual(result.BaseCost, 2.5m);
        Assert.AreEqual(result.Recipe.Count, 1);
    }

    public void Dispose()
    {
        PizzaComContextFactory.Destroy(_context);
    }
}