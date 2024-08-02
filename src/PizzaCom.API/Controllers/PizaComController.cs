using Microsoft.AspNetCore.Mvc;
using PizzaCom.API.Models;

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
        Console.WriteLine(blueprintCards);
        return Ok(blueprintCards);
    }

    /// <summary>
    /// Gets a blueprint builder model by blueprint options.
    /// </summary>
    /// <param name="options">The blueprint options.</param>
    /// <returns>A blueprint builder model.</returns>
    [HttpPost("blueprints/builder")]
    public async Task<ActionResult<BlueprintBuilderModel>> GetBlueprintBuilder([FromBody] BlueprintOptions options,
    [FromServices] PizzaComServices services)
    {
        services.Logger.LogInformation(options.Id.ToString() + "sdflgmkslgjklsg");
        var blueprintBuilder = await services.Queries.GetBlueprintBuilder(options);
        if (blueprintBuilder == null)
        {
            return NotFound();
        }
        return Ok(blueprintBuilder);
    }

    /// <summary>
    /// Gets a list of ingredients.
    /// </summary>
    /// <returns>A list of ingredients.</returns>
    [HttpGet("ingredients")]
    public async Task<ActionResult<List<BlueprintBuilderRecipeItem>>> GetIngredients([FromServices] PizzaComServices services)
    {
        var ingredients = await services.Queries.GetIngredients();
        return Ok(ingredients);
    }
}