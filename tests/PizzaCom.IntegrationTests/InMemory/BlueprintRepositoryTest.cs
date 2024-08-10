using PizzaCom.API.Application;
using PizzaCom.API.Application.Builders;
using PizzaCom.API.Models;
using PizzaCom.Infrastructure.Repositories;
using PizzaCom.IntegrationTests.Factory;

namespace PizzaCom.IntegrationTests.InMemory;

//Use UnitTest Domain project to get test package references and domain factories...
[TestClass]
public class BlueprintRepositoryTests
{
    private readonly PizzaComContext _context;
    private readonly BlueprintRepository _repository;
    private readonly API.Application.BlueprintFactory _factory;

    private readonly UnitTests.BlueprintFactory _templateFactory;

    public TestContext TestContext { get; set; }

    public BlueprintRepositoryTests()
    {
        _context = PizzaComContextFactory.Create();
        _repository = new BlueprintRepository(_context);
        _factory = new  API.Application.BlueprintFactory();
        _templateFactory = new UnitTests.BlueprintFactory();
    }

    //TODO: domain model fabric with ready templates and builder behavior for simplify testing
    [TestMethod]
    public async Task CreateBlueprintWithRecipe_ReturnsBlueprint()
    {
        var blueprint = _templateFactory.CreateCheesePizza();

        _repository.Add(blueprint);

        await _repository.UnitOfWork.SaveChangesAsync();

        var result = await _repository.GetAsync(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(result.Name, blueprint.Name);
        Assert.AreEqual(result.BaseCost, blueprint.BaseCost);
        Assert.AreEqual(result.Recipes.Count, 2);
        Assert.AreEqual(result.Included.Count, 2);
        Assert.AreEqual(result.Recipes.First().Name, blueprint.Recipes.First().Name);
    }

    [TestMethod]
    public async Task GetBlueprintBuilderModel_ReturnsCorrectModel()
    {
        // Arrange
        var pizzaName = "Pepperoni Pizza";
        var recipe = new Recipe(id: 1, ingredientId: 60, costPer100g: 5.50m, weight: 80, name: "Tomato Sauce", type: RecipeType.Base, ingredientType: IngredientType.Meat);
        var blueprint = new Blueprint(1, pizzaName, 2.5m, new List<Recipe> { recipe });
        _repository.Add(blueprint);
        await _repository.UnitOfWork.SaveChangesAsync();

        var OptionServices = new BlueprintOptionServices { Id = 1 }; // Настройте BlueprintOptionServices по необходимости

        // Act
        var result = _factory.BlueprintWithOptionServices(OptionServices, blueprint);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(result.Id, blueprint.Id);
        Assert.AreEqual(result.Name, pizzaName);
        Assert.AreEqual(result.Cost, 4.4m);
        Assert.IsNotNull(_factory.GetOptionServiceDetails(result, nameof(AddDoubleMeatOptionService)));
        Assert.AreEqual(result.Included.Count, 1);
        Assert.AreEqual(result.Excluded.Count, 0); // Если в тесте нет исключенных ингредиентов
        Assert.AreEqual(result.Included.First().Name, "Tomato Sauce");
        Assert.AreEqual(result.Included.First().Id, 60);
    }

    public void Dispose()
    {
        PizzaComContextFactory.Destroy(_context);
    }
}