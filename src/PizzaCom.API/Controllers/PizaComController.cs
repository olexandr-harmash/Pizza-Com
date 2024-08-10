using Microsoft.AspNetCore.Mvc;
using PizzaCom.API.Models;
using PizzaCom.Domain.AggregatesModel;

namespace PizzaCom.API.Controllers;

[ApiController]
[Route("/api/pizza_com")]
public class PizzaComController : ControllerBase
{
    public PizzaComController() {}

    /// <summary>
    /// Gets a list of blueprint cards.
    /// </summary>
    /// <returns>A list of blueprint cards.</returns>
    [HttpGet("blueprints")]
    public async Task<ActionResult<List<BlueprintCard>>> GetBlueprintCards([FromServices] PizzaComServices services)
    {
        var blueprintCards = await services.Queries.GetBlueprintCards();

        return Ok(blueprintCards);
    }

    /// <summary>
    /// Gets a blueprint builder model by blueprint OptionServices.
    /// </summary>
    /// <param name="OptionServices">The blueprint OptionServices.</param>
    /// <returns>A blueprint builder model.</returns>
    [HttpPost("blueprints/builder")]
    public async Task<ActionResult<BlueprintBuilderModel>> GetBlueprintBuilder([FromBody] BuildBoilerplateDTO OptionServices,
    [FromServices] PizzaComServices services)
    {
        var blueprintBuilder = await services.Queries.GetBlueprintBuilder(OptionServices);
        if (blueprintBuilder == null)
        {
            return NotFound();
        }
        return Ok(blueprintBuilder);
    }

    [HttpPost("blueprints/")]
    public async Task<ActionResult<BlueprintBuilderModel>> AddTestBlueprint([FromServices] PizzaComServices services)
    {   
        var components = new List<Component>
        {
            // Основа пиццы
            new Component(IngredientVariant.GlutenCrust.Id, ComponentType.Default.Id, 1),

            // Ингредиенты
            new Component(IngredientVariant.Mozzarella.Id, ComponentType.Default.Id, 150),
            new Component(IngredientVariant.Tomato.Id, ComponentType.Default.Id, 100),

            // Опционально добавляем базилик
            // Убедитесь, что у вас есть базилик в списке ингредиентов, если нет, добавьте его
            new Component(IngredientVariant.Basil.Id, ComponentType.Optional.Id, 10),
            new Component(IngredientVariant.GlutenFreeCrust.Id, ComponentType.Optional.Id, 1),
        };

        // Создание пиццы
        var boilerplate = new Boilerplate
        (
            "Margherita Pizza",
            11.50m, // Цена может измениться в зависимости от цен на ингредиенты
            components
        );

        var created = services.Repository.Add(boilerplate);

        await services.Repository.UnitOfWork.SaveChangesAsync();

        return Ok();
    }

    /// <summary>
    /// Gets a list of ingredients.
    /// </summary>
    /// <returns>A list of ingredients.</returns>
    [HttpGet("ingredients")]
    public async Task<ActionResult<List<IngredientDTO>>> GetIngredients([FromServices] PizzaComServices services)
    {
       // var ingredients = await services.Queries.GetIngredients();
        return Ok();
    }
}