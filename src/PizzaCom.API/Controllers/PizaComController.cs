using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<List<BoilerplateDTO>>> GetBoilerplateDTOs([FromServices] PizzaComServices services)
    {
        var BoilerplateDTOs = await services.Queries.GetBoilerplateDTOs();

        return Ok(BoilerplateDTOs);
    }

    /// <summary>
    /// Gets a blueprint builder model by blueprint OptionServices.
    /// </summary>
    /// <param name="OptionServices">The blueprint OptionServices.</param>
    /// <returns>A blueprint builder model.</returns>
    [HttpGet("blueprints/details/{id}")]
    public async Task<ActionResult<PizzaTemplateDTO>> GetBlueprintBuilder([FromRoute] int id, [FromBody] CreateOrUpdatePizzaTemplateRequestDTO OptionServices,
    [FromServices] PizzaComServices services)
    {
        var blueprintBuilder = await services.Queries.GetBlueprintBuilder(id, OptionServices);
        if (blueprintBuilder == null)
        {
            return NotFound();
        }
        return Ok(blueprintBuilder);
    }
}