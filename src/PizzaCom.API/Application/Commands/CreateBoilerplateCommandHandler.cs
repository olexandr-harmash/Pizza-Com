namespace PizzaCom.API.Application.Commands;

public class CreatePizzaCommandHandler
    : IRequestHandler<CreatePizzaCommand, int>
{
    private readonly IBoilerplateRepository _boilerplateRepository;
    private readonly IMediator _mediator;
    private readonly ILogger<CreatePizzaCommandHandler> _logger;

    public CreatePizzaCommandHandler(IMediator mediator,
        IBoilerplateRepository boilerplateRepository,
        ILogger<CreatePizzaCommandHandler> logger)
    {
        _boilerplateRepository = boilerplateRepository ?? throw new ArgumentNullException(nameof(boilerplateRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int> Handle(CreatePizzaCommand message, CancellationToken cancellationToken)
    {
        List<Component> components = new();

        foreach (var component in message.Components)
        {
            components.Add(new Component(component.IngredientId, component.ComponentTypeId, component.Weight));
        } 

        var boilerplate = new Boilerplate(message.Name, message.Price, components);

        _boilerplateRepository.Add(boilerplate);

        await _boilerplateRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return boilerplate.Id;
    }
}


