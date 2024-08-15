using AutoMapper;
using PizzaCom.API.Builders;

namespace PizzaCom.API.Queries;

/// <summary>
/// Provides queries for retrieving blueprint-related data.
/// </summary>
public class PizzaQueries : IPizzaQueries
{
    private readonly IBoilerplateRepository _repository;
    private readonly IPizzaQueriesService _queriesService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="PizzaQueries"/> class.
    /// </summary>
    /// <param name="repository">The boilerplate repository to use.</param>
    /// <param name="mapper">The AutoMapper instance to use for object mapping.</param>
    /// <param name="queriesService">The service to use for querying boilerplate options.</param>
    public PizzaQueries(IBoilerplateRepository repository, IMapper mapper, IPizzaQueriesService queriesService)
    {
        _repository = repository;
        _mapper = mapper;
        _queriesService = queriesService;
    }

    /// <summary>
    /// Gets the pizza template builder for the specified blueprint ID.
    /// </summary>
    /// <param name="id">The blueprint ID.</param>
    /// <param name="request">The request containing information to create or update the pizza template.</param>
    /// <returns>The built pizza template DTO.</returns>
    public async Task<PizzaTemplateDTO> GetPizzaTemplate(int id, GetPizzaTemplateDTO request)
    {
        var boilerplate = await _repository.GetBoilerplateDetailsByIdAsync(id);

        var availableOptions = _queriesService.GetAvailableOptionsExcept(boilerplate, request.GetKeys());
        
        _queriesService.SetComponents(boilerplate, request.Ingredients);
        
        var appliedOptions = _queriesService.ApplyOptions(boilerplate, request.AppliedOptions);
  
        var builder = new PizzaTemplateDTOBuilder(_mapper.Map<PizzaTemplateDTO>(boilerplate));

        var pizzaTemplateDTO = builder
            .SetOptions(
                _mapper.Map<List<OptionDTO>>(availableOptions)
                .Concat(_mapper.Map<List<OptionDTO>>(appliedOptions))
            )
            .SetSummary(
                _mapper.Map<List<AppliedOptionDTO>>(appliedOptions),
                _mapper.Map<List<AppliedIngredientSummaryDTO>>(boilerplate.ComponentsWithMultiplier.Keys)
            )
            .Build();

        return pizzaTemplateDTO;
    }

    /// <summary>
    /// Gets the blueprint details for the specified ID.
    /// </summary>
    /// <param name="id">The blueprint ID.</param>
    /// <returns>The blueprint details DTO.</returns>
    public async Task<PizzaDetailsDTO> GetPizzaDetails(int id)
    {
        var boilerplate = await _repository.GetBoilerplateDetailsByIdAsync(id);

        var availableOptions = _queriesService.GetAvailableOptions(boilerplate);

        var builder = new PizzaDetailsDTOBuilder(_mapper.Map<PizzaDetailsDTO>(boilerplate));

        var pizzaTemplateDTO = builder
            .SetOptions(_mapper.Map<List<OptionDTO>>(availableOptions))
            .Build();

        return pizzaTemplateDTO;
    }

    /// <summary>
    /// Gets a list of all boilerplate DTOs.
    /// </summary>
    /// <returns>A list of boilerplate DTOs.</returns>
    public async Task<List<PizzaDTO>> GetPizzaDTOs()
    {
        var boilerplates = await _repository.GetBoilerplateAsync();

        return _mapper.Map<List<PizzaDTO>>(boilerplates);
    }
}