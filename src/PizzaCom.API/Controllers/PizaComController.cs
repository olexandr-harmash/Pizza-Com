using Microsoft.AspNetCore.Mvc;
using PizzaCom.API.Application.Commands;

namespace PizzaCom.API.Controllers;

[ApiController]
[Route("/api/pizzas")]
public class PizzaComController : ControllerBase
{
    private readonly PizzaComServices _services;

    public PizzaComController(PizzaComServices services) 
    {
        _services = services;
    }

    /// <summary>
    /// Gets a list of all available boilerplate DTOs.
    /// </summary>
    /// <param name="services">The service to retrieve boilerplate DTOs.</param>
    /// <returns>A list of boilerplate DTOs.</returns>
    [HttpGet()]
    public async Task<ActionResult<List<PizzaDTO>>> GetPizzaDTOs([FromServices] PizzaComServices services)
    {
        var boilerplateDTOs = await services.Queries.GetPizzaDTOs();
        return Ok(boilerplateDTOs);
    }

    /// <summary>
    /// Gets a pizza template DTO based on the specified blueprint ID and options.
    /// </summary>
    /// <param name="id">The ID of the blueprint.</param>
    /// <param name="OptionServices">The request containing options to apply to the blueprint.</param>
    /// <param name="services">The service to retrieve the blueprint builder.</param>
    /// <returns>A pizza template DTO representing the blueprint builder.</returns>
    [HttpGet("template/{id}")]
    public async Task<ActionResult<PizzaTemplateDTO>> GetPizzaTemplate([FromRoute] int id, GetPizzaTemplateDTO request, [FromServices] PizzaComServices services)
    {
        var blueprintBuilder = await services.Queries.GetPizzaTemplate(id, request);
        if (blueprintBuilder == null)
        {
            return NotFound();
        }
        return Ok(blueprintBuilder);
    }

    /// <summary>
    /// Gets detailed information about a specific blueprint by its ID.
    /// </summary>
    /// <param name="id">The ID of the blueprint.</param>
    /// <param name="services">The service to retrieve the blueprint details.</param>
    /// <returns>A blueprint details DTO representing the blueprint details.</returns>
    [HttpGet("details/{id}", Name = "GetPizzaTemplateById")]
    public async Task<ActionResult<PizzaTemplateDTO>> GetPizzaDetails([FromRoute] int id, [FromServices] PizzaComServices services)
    {
        var blueprintBuilder = await services.Queries.GetPizzaDetails(id);
        if (blueprintBuilder == null)
        {
            return NotFound();
        }
        return Ok(blueprintBuilder);
    }

    /// <summary>
    /// Creates a new pizza.
    /// </summary>
    /// <param name="request">The request containing the details of the pizza to be created.</param>
    /// <returns>A redirect to the route that gets the pizza builder by the new pizza ID.</returns>
    [HttpPost()]
    public async Task<IActionResult> CreatePizzaAsync([FromBody] CreatePizzaCommand request)
    {
        var requestCreatePizza = new CreatePizzaCommand(request.Name, request.Price, request.Components);

        _services.Logger.LogInformation(
            "Sending command: {CommandName}: ({@Command})",
            requestCreatePizza.GetGenericTypeName(),
            requestCreatePizza);

        var pizzaId = await _services.Mediator.Send(requestCreatePizza);

        if (pizzaId != 0)
        {
            _services.Logger.LogInformation("CreatePizzaCommand succeeded");
        }
        else
        {
            _services.Logger.LogWarning("CreatePizzaCommand failed");
        }

        return RedirectToRoute("GetPizzaTemplateById", new { id = pizzaId });
    }
}
